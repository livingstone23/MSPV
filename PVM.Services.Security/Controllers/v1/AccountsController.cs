using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PVM.Services.Security.DbContexts;
using PVM.Services.Security.Model;
using PVM.Services.Security.Model.Dto;
using PVM.Services.Security.Utility;
using Microsoft.Extensions.Options;
using PVM.Services.Security;

namespace PVM.Service.Security.Controllers.v1
{
    [Route("api/v1/account")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly UserManager<PolicyUser> _userManager;
        private readonly SignInManager<PolicyUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        //Variables para habilitar la encriptacion
        private readonly IDataProtector _dataProtector;

        //Seccion para utilizar el grupo de variables "APISettings"
        private readonly APISettings _aPISettings;


        public AccountsController(UserManager<PolicyUser> userManager,
                                    SignInManager<PolicyUser> signInManager,
                                    IConfiguration configuration,
                                    ApplicationDbContext context,
                                    IMapper mapper,
                                    IDataProtectionProvider dataProtectionProvider,
                                    IOptions<APISettings> options)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
            _context = context;
            _dataProtector = dataProtectionProvider.CreateProtector("aqui_debe_Registrarse_valor_unico_y_secreto");
            _aPISettings = options.Value;
        }




        [HttpPost("SignUp", Name = "SignUp")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] UserRequestDTO userRequestDTO)
        {
  
            if (userRequestDTO == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new PolicyUser()
            {
                UserName = userRequestDTO.Name,
                Email = userRequestDTO.Email,
                SurName = userRequestDTO.Name,
                PhoneNumber = userRequestDTO.PhoneNo
            };

            var result = await _userManager.CreateAsync(user, userRequestDTO.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegisterationResponseDTO { Errors = errors, IsRegisterationSuccessful = false });
            }
            var roleResult = await _userManager.AddToRoleAsync(user, SD.Role_Customer);
            if (!roleResult.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegisterationResponseDTO
                    { Errors = errors, IsRegisterationSuccessful = false });
            }
            return StatusCode(201);
           
        }



        [HttpPost("SignIn", Name = "SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] AuthenticationDTO authenticationDTO)
        {
            var userName = await _userManager.FindByEmailAsync(authenticationDTO.UserName);
            if (userName == null)
            {
                return Unauthorized(new AuthenticationResponseDTO
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "Invalid Email"
                });
            }

            //Habilitar seccion de ultimo false si se quiere bloquear por intentos fallidos
            var result = await _signInManager.PasswordSignInAsync(userName, authenticationDTO.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(authenticationDTO.UserName);
                if (user == null)
                {
                    return Unauthorized(new AuthenticationResponseDTO
                    {
                        IsAuthSuccessful = false,
                        ErrorMessage = "Invalid Authentication"
                    });
                }

                //everything is valid and we need to login the user

                var signinCredentials = GetSigningCredentials();
                var claims = await GetClaims((PolicyUser)user);

                //Section for Create token
                var tokenOptions = new JwtSecurityToken(
                    issuer: _aPISettings.ValidIssuer,
                    audience: _aPISettings.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                //Return token
                return Ok(new AuthenticationResponseDTO
                {
                    IsAuthSuccessful = true,
                    Token = token,
                    userDTO = new UserDTO
                    {
                        Name = user.UserName,
                        Id = user.Id,
                        Email = user.Email,
                        PhoneNo = user.PhoneNumber
                    }
                });
            }
            else
            {
                return Unauthorized(new AuthenticationResponseDTO
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "Invalid Authentication"
                });
            }
        }



        private SigningCredentials GetSigningCredentials()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_aPISettings.SecretKey));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }



        private async Task<List<Claim>> GetClaims(PolicyUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("Id",user.Id),

            };
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        #region MyRegion

        ///// <summary>
        ///// Metodo para ingresar como usuario
        ///// </summary>
        ///// <param name="credentialUser"></param>
        ///// <returns></returns>
        //[HttpPost("login", Name = "Login")]
        //public async Task<ActionResult<AuthenticationAnswer>> Login(UserCredential credentialUser)
        //{
        //    //Controla condiciones por ejemplo uso de cookies o fallos por intento de login.
        //    var result = await _signInManager.PasswordSignInAsync(credentialUser.Email, credentialUser.Password, isPersistent: false, lockoutOnFailure: false);

        //    if (result.Succeeded)
        //    {
        //        return await CreateToken(credentialUser);
        //    }
        //    else
        //    {
        //        //Se limita respuesta para evitar identificar vulnerabilidades del sistema.
        //        return BadRequest("Login not correct");
        //    }

        //}


        ///// <summary>
        ///// Metodo para generar token
        ///// </summary>
        ///// <param name="userCredential"></param>
        ///// <returns></returns>
        //private async Task<AuthenticationAnswer> CreateToken(AuthenticationDTO userCredential)
        //{
        //    //Variable se añade al tokenm
        //    var claims = new List<Claim>()
        //    {
        //        new Claim(ClaimTypes.Name, userCredential.UserName),
        //        new Claim(ClaimTypes.Email, userCredential.UserName)
        //        //new Claim("Lo que yo quiera", "Valor a agregar en el claim")

        //    };


        //    var user = await _userManager.FindByEmailAsync(userCredential.UserName);
        //    var claimsDB = await _userManager.GetClaimsAsync(user);
        //    claims.AddRange(claimsDB);


        //    //Construimos el JasonWebToken (jwt)
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["KeyJwt"]));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //    var expiration = DateTime.UtcNow.AddYears(1);

        //    var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
        //        expires: expiration, signingCredentials: creds);

        //    return new AuthenticationAnswer()
        //    {
        //        Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
        //        Expiration = expiration
        //    };

        //}



        //[HttpGet("RenewToken", Name = "RenewToken")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //public async Task<ActionResult<AuthenticationAnswer>> Renew()
        //{
        //    var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
        //    var email = emailClaim.Value;
        //    var userCredential = new UserCredential()
        //    {
        //        Email = email
        //    };

        //    //Construimos nuevo token con renovacion de token
        //    return await CreateToken(userCredential);

        //}


        //[HttpPost("BecomeAdmin", Name = "BecomeAdmin")]
        //public async Task<ActionResult> BecomeAdmin(EditAdminDTO editAdminDTO)
        //{

        //    var user = await _userManager.FindByEmailAsync(editAdminDTO.Email);
        //    await _userManager.AddClaimAsync(user, new Claim("IsAdmin", "1"));
        //    return NoContent();

        //}

        //[HttpPost("RemoveAdmin", Name = "RemoveAdmin")]
        //public async Task<ActionResult> RemoveAdmin(EditAdminDTO editAdminDTO)
        //{

        //    var user = await _userManager.FindByEmailAsync(editAdminDTO.Email);
        //    await _userManager.RemoveClaimAsync(user, new Claim("IsAdmin", "1"));
        //    return NoContent();

        //}


        //[HttpPost("Encriptar", Name = "Encriptar")]
        //public async Task<ActionResult> Encriptar()
        //{

        //    var textoPlano = "Livingstone Cano";
        //    var textoCifrado = _dataProtector.Protect(textoPlano);
        //    var textoDescrifado = _dataProtector.Unprotect(textoCifrado);


        //    return Ok(new
        //    {
        //        textoPlano,
        //        textoCifrado,
        //        textoDescrifado
        //    });
        //}


        //[HttpGet("Users", Name = "Users")]
        ////[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //public async Task<ActionResult<List<UserDTO>>> Get([FromQuery] PaginationDTO paginationDto)
        //{

        //    var queryable = _context.Users.AsQueryable();
        //    await HttpContext.InsertPararmetersPagination(queryable, paginationDto.RegisterByPage);
        //    var entities = await _context.Users.Paginar(paginationDto).ToListAsync();
        //    return _mapper.Map<List<UserDTO>>(entities);

        //}


        //[HttpPost("AssingRole", Name = "AssingRole")]
        ////[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //public async Task<ActionResult> AssingRole([FromQuery] EditRolDTO editRolDto)
        //{

        //    var user = await _userManager.FindByIdAsync(editRolDto.Id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, editRolDto.RoleName));
        //    return NoContent();


        //}


        //[HttpPost("RemoveRole", Name = "RemoveRole")]
        ////[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //public async Task<ActionResult> RemoveRole([FromQuery] EditRolDTO editRolDto)
        //{

        //    var user = await _userManager.FindByIdAsync(editRolDto.Id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    await _userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, editRolDto.RoleName));
        //    return NoContent();


        //}










        #endregion


        #region MyRegionControles

        

        



       



        

        #endregion

    }
}
