using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVM.Service.Notifications.Model.Dto;
using PVM.Service.Notifications.Services.GeneralOfficeUserService;
using PVM.Service.Notifications.Services.GeneralService;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Notifications.Controllers.v1
{
    [Route("api/v1/generalservice")]
    [ApiController]
    public class GeneralServicesController : ControllerBase
    {


        private IGeneralServiceService _generalServiceService;

        private readonly IMapper _mapper;


        public GeneralServicesController(IGeneralServiceService generalServiceService, IMapper mapper)
        {
            _generalServiceService = generalServiceService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GeneralServiceDto>>>> GetActions()
        {

            var response = await _generalServiceService.GetGeneralServicesAsync();
            return Ok(response);

        }


    }
}
