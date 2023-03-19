using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTemplate.DTOs
{
    [Route("api")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RootController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        public RootController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }


        [HttpGet(Name = "GetRoot")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DataHATEOAS>>> Get()
        {

            var dataHateoas = new List<DataHATEOAS>();

            var IsAdmin = await _authorizationService.AuthorizeAsync(User, "IsAdmin");

            dataHateoas.Add(new DataHATEOAS(link: Url.Link("GetRoot", new {}), description:"Self", method: "Get" ));
            
            //Rutas de obtener y crear
            dataHateoas.Add(new DataHATEOAS(link: Url.Link("GetAll",               new {}), description:"Get"                , method: "Get"));
            dataHateoas.Add(new DataHATEOAS(link: Url.Link("Configurations",       new {}), description: "Get Configurations", method: "Get"));
            dataHateoas.Add(new DataHATEOAS(link: Url.Link("GetAuthorById",        new {}), description: "Get Author by Id"  , method: "Get"));
            
            if(IsAdmin.Succeeded)
            {
                dataHateoas.Add(new DataHATEOAS(link: Url.Link("FirstAuthor",          new {}), description: "Get First Author"  , method: "Get"));
                dataHateoas.Add(new DataHATEOAS(link: Url.Link("CreateAuthor",         new {}), description: "Create Author"     , method: "Post"));
            }

            return dataHateoas;

        }

    }
}
