using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PVM.Service.Notifications.Model.Dto;
using PVM.Service.Notifications.Services.GeneralOfficeService;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Notifications.Controllers.v1
{
    [Route("api/v1/generaloffice")]
    [ApiController]
    public class GeneralOfficesController : ControllerBase
    {

        private IGeneralOfficeService _generalOfficeService;

        private readonly IMapper _mapper;

        public GeneralOfficesController(IGeneralOfficeService generalOfficeService, IMapper mapper)
        {
            _generalOfficeService = generalOfficeService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GeneralOfficeDto>>>> GetActions()
        {

            var response = await _generalOfficeService.GetGeneralOfficesAsync();
            return Ok(response);

        }


    }
}
