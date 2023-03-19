using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Context;
using WebApiTemplate.DTOs;
using WebApiTemplate.Filter;
using WebApiTemplate.Models;

namespace WebApiTemplate.Controllers.v2
{
    [Route("api/v2/autores")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]   //Para validar que usuario este autenticado
    public class TestController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        private readonly ILogger<TestController> _logger;

        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        //Inyectamos identity para poder acceder a los datos de estos componentes.
        private readonly UserManager<IdentityUser> _userManager;


        public TestController(ApplicationDbContext context,
                                ILogger<TestController> logger,
                                IMapper mapper,
                                IConfiguration configuration,
                                UserManager<IdentityUser> userManager
                             )
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
            _userManager = userManager;

        }



        [HttpGet(Name = "GetAll")]

        [ServiceFilter(typeof(MyFilterAction))] //Agregamos el filtro personalizado.
        public async Task<ActionResult<List<Author>>> Get()
        {
            _logger.LogInformation("Estamos realizando esta prueba");
            return await _context.Autores.ToListAsync();

        }


        [HttpGet("Configuraciones", Name = "Configurationsv2")]
        [ServiceFilter(typeof(MyFilterAction))] //Agregamos el filtro personalizado.
        public ActionResult<string> Configuraciones()
        {

            return _configuration["SecretTest01"];

        }


        [AllowAnonymous]
        [HttpGet("{id:int}", Name = "GetAuthorByIdv2")]
        //[ServiceFilter(typeof(MyFilterAction))] //Agregamos el filtro personalizado.
        public async Task<ActionResult<Author>> GetAuthorById(int id)
        {
            //Linea para confirmar que se ejecuta el MyFilterException
            //throw new NotImplementedException();

            var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);

        }


        [HttpGet("primero", Name = "FirstAuthorv2")]
        [AllowAnonymous]
        public async Task<ActionResult<Author>> PrimerAutor()
        {

            return await _context.Autores.FirstOrDefaultAsync();

        }


        [HttpPost(Name = "CreateAuthorv2")]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] AuthorCreationDTO authorCreation)
        {

            var bookExist = await _context.Autores.AnyAsync(x => x.Name == authorCreation.Name);

            if (bookExist)
            {
                return BadRequest($"The book already exist {authorCreation.Name}");
            }

            var author = _mapper.Map<Author>(authorCreation);

            _context.Autores.Add(author);
            await _context.SaveChangesAsync();
            return Ok();

        }


        [HttpPut("{id:int}", Name = "UpdateAuthorv2")]
        [AllowAnonymous]
        public async Task<ActionResult> Put([FromBody] Author autor, int id)
        {

            //Obtenemos el claim para poder llegar al userId
            //var emailClaim2 = HttpContext.User.Claims;
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;
            var user = await _userManager.FindByEmailAsync(email);
            var usuarioId = user.Id;

            if (autor.Id != id)
            {
                return BadRequest("El id del autor no coincide con el id de la URL");
            }

            var exist = await _context.Autores.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            _context.Update(autor);
            await _context.SaveChangesAsync();
            return Ok();

        }


        [HttpDelete("{id:int}", Name = "DeleteAuthorv2")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]      //
        public async Task<ActionResult> Delete(int id)
        {

            var exist = await _context.Autores.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            _context.Remove(new Author() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();

        }


    }
}
