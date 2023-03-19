using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVM.Service.Notifications.Model.Dto;
using PVM.Service.Notifications.Services.GeneralOfficeService;
using PVM.Service.Notifications.Services.GeneralOfficeUserService;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Notifications.Controllers.v1
{
    [Route("api/v1/generalofficeuser")]
    [ApiController]
    public class GeneralOfficeUsersController : ControllerBase
    {


        private IGeneralOfficeUserService _generalOfficeUserService;

        private readonly IMapper _mapper;

        public GeneralOfficeUsersController(IGeneralOfficeUserService generalOfficeUserService, IMapper mapper)
        {
            _generalOfficeUserService = generalOfficeUserService;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GeneralOfficeUserDto>>>> GetActions()
        {

            var response = await _generalOfficeUserService.GetGeneralOfficeUsersAsync();
            return Ok(response);

        }


    }
}
