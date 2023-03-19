using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVM.Services.Gestpro.Model.Dto;
using PVM.Services.Gestpro.Services.RegisterService;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Controllers.v1
{
    [Route("api/v1/registers")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private IRegisterService _registerService;

        private readonly IMapper _mapper;

        public RegistersController(IRegisterService registerService, IMapper mapper)
        {
            _registerService = registerService;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<RegisterDto>>>> GetActions()
        {

            var response = await _registerService.GetRegisterAsync();
            return Ok(response);

        }




    }
}
