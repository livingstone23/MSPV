using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PVM.Service.Notifications.Model.Dto;
using PVM.Service.Notifications.Services.GeneralSubservice;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Notifications.Controllers.v1
{
    [Route("api/v1/generalsubservice")]
    [ApiController]
    public class GeneralSubServicesController : ControllerBase
    {

        private IGeneralSubserviceService _generalSubserviceService;

        private readonly IMapper _mapper;

        public GeneralSubServicesController(IGeneralSubserviceService generalSubServiceService, IMapper mapper)
        {
            _generalSubserviceService = generalSubServiceService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GeneralServiceDto>>>> GetActions()
        {

            var response = await _generalSubserviceService.GetGeneralSubservicesAsync();
            return Ok(response);

        }


    }
}
