using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PVM.Services.Security.Model.Dto;
using PVM.Services.Security.Services.ActionService;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Security.Controllers.v1
{
    [Route("api/v1/actionsL")]
    [ApiController]
    [Authorize]
    public class ActionsController : ControllerBase
    {



        private IActionService _actionService;

        private readonly IMapper _mapper;

        public ActionsController(IActionService actionService, IMapper mapper)
        {
            _actionService = actionService;
            _mapper = mapper;
        }

        [HttpGet]
        
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ServiceResponse<List<ActionDto>>>> GetActions()
        {

            var response = await _actionService.GetActionsAsync(); 
            return Ok(response);
           
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("{id}", Name = "GetById")]
        public async Task<ActionResult<ServiceResponse<ActionDto>>> GetById(Guid id)
        {

            var result = await _actionService.GetActionById(id);
            return Ok(result);

        }



        [HttpPost]
        [Route("Insert", Name = "Insert")]
        public async Task<ActionResult<ServiceResponse<ActionDto>>> Insert([FromBody]ActionDto action)
        {

            var result = await _actionService.CreateUpdateAction(action);
            return Ok(result);
        }


        [HttpPut]
        [Route("Update", Name = "Put")]
        public async Task<ActionResult<ServiceResponse<ActionDto>>> Put([FromBody] ActionDto action)
        {

            var result = await _actionService.CreateUpdateAction(action);
            return Ok(result);
        }


        [HttpDelete]
        [Route("Delete", Name = "Delete")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(Guid actionId)
        {

            var result = await _actionService.DeleteAction(actionId);
            return Ok(result);
           
        }

    }
}
