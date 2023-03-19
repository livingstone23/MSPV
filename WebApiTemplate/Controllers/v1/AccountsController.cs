using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Context;
using WebApiTemplate.DTOs;
using WebApiTemplate.Helpers;

namespace WebApiTemplate.Controllers.v1
{
    [Route("api/v1/account")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        //Variables para habilitar la encriptacion
        private readonly IDataProtector _dataProtector;


        public AccountsController(  UserManager<IdentityUser> userManager,
                                    SignInManager<IdentityUser> signInManager,
                                    IConfiguration configuration,
                                    ApplicationDbContext context,
                                    IMapper mapper,
                                    IDataProtectionProvider dataProtectionProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
            _context = context;
            _dataProtector = dataProtectionProvider.CreateProtector("aqui_debe_Registrarse_valor_unico_y_secreto");

        }


        /// <summary>
        /// Metodo para registrar usuarios
        /// </summary>
        /// <param name="userCredential"></param>
        /// <returns></returns>
        [HttpPost("register", Name = "Register")]
        public async Task<ActionResult<AuthenticationAnswer>> Register([FromBody] UserCredential userCredential)
        {
            var user = new IdentityUser { UserName = userCredential.Email, Email = userCredential.Email };
            var answer = await _userManager.CreateAsync(user, userCredential.Password);

            if (answer.Succeeded)
            {

                return await CreateToken(userCredential);

            }
            else
            {
                return BadRequest(answer.Errors);
            }



        }


        /// <summary>
        /// Metodo para ingresar como usuario
        /// </summary>
        /// <param name="credentialUser"></param>
        /// <returns></returns>
        [HttpPost("login", Name = "Login")]
        public async Task<ActionResult<AuthenticationAnswer>> Login(UserCredential credentialUser)
        {
            //Controla condiciones por ejemplo uso de cookies o fallos por intento de login.
            var result = await _signInManager.PasswordSignInAsync(credentialUser.Email, credentialUser.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await CreateToken(credentialUser);
            }
            else
            {
                //Se limita respuesta para evitar identificar vulnerabilidades del sistema.
                return BadRequest("Login not correct");
            }

        }


        /// <summary>
        /// Metodo para generar token
        /// </summary>
        /// <param name="userCredential"></param>
        /// <returns></returns>
        private async Task<AuthenticationAnswer> CreateToken(UserCredential userCredential)
        {
            //Variable se añade al tokenm
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userCredential.Email),
                new Claim(ClaimTypes.Email, userCredential.Email)
                //new Claim("Lo que yo quiera", "Valor a agregar en el claim")

            };


            var user = await _userManager.FindByEmailAsync(userCredential.Email);
            var claimsDB = await _userManager.GetClaimsAsync(user);
            claims.AddRange(claimsDB);


            //Construimos el JasonWebToken (jwt)
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["KeyJwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddYears(1);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiration, signingCredentials: creds);

            return new AuthenticationAnswer()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration
            };

        }



        [HttpGet("RenewToken", Name = "RenewToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<AuthenticationAnswer>> Renew()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;
            var userCredential = new UserCredential()
            {
                Email = email
            };

            //Construimos nuevo token con renovacion de token
            return await CreateToken(userCredential);

        }


        [HttpPost("BecomeAdmin", Name = "BecomeAdmin")]
        public async Task<ActionResult> BecomeAdmin(EditAdminDTO editAdminDTO)
        {

            var user = await _userManager.FindByEmailAsync(editAdminDTO.Email);
            await _userManager.AddClaimAsync(user, new Claim("IsAdmin", "1"));
            return NoContent();

        }

        [HttpPost("RemoveAdmin", Name = "RemoveAdmin")]
        public async Task<ActionResult> RemoveAdmin(EditAdminDTO editAdminDTO)
        {

            var user = await _userManager.FindByEmailAsync(editAdminDTO.Email);
            await _userManager.RemoveClaimAsync(user, new Claim("IsAdmin", "1"));
            return NoContent();

        }


        [HttpPost("Encriptar", Name = "Encriptar")]
        public async Task<ActionResult> Encriptar()
        {

            var textoPlano = "Livingstone Cano";
            var textoCifrado = _dataProtector.Protect(textoPlano);
            var textoDescrifado = _dataProtector.Unprotect(textoCifrado);


            return Ok(new
            {
                textoPlano,
                textoCifrado,
                textoDescrifado
            });
        }


        [HttpGet("Users", Name = "Users")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<UserDTO>>> Get([FromQuery] PaginationDTO paginationDto)
        {
            
            var queryable = _context.Users.AsQueryable();
            await HttpContext.InsertPararmetersPagination(queryable, paginationDto.RegisterByPage);
            var entities = await _context.Users.Paginar(paginationDto).ToListAsync();
            return _mapper.Map<List<UserDTO>>(entities);

        }


        [HttpPost("AssingRole", Name = "AssingRole")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> AssingRole([FromQuery] EditRolDTO editRolDto)
        {

            var user = await _userManager.FindByIdAsync(editRolDto.Id);
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, editRolDto.RoleName));
            return NoContent();


        }


        [HttpPost("RemoveRole", Name = "RemoveRole")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> RemoveRole([FromQuery] EditRolDTO editRolDto)
        {

            var user = await _userManager.FindByIdAsync(editRolDto.Id);
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, editRolDto.RoleName));
            return NoContent();


        }


    }
}
