using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVM.Services.Gestpro.Model.Dto;
using PVM.Services.Gestpro.Services.ClientService;
using PVM.Services.Gestpro.Services.EstatTramitacioMestre;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Controllers.v1
{
    [Route("api/v1/EstatTramitacioMestres")]
    [ApiController]
    public class EstatTramitacioMestresController : ControllerBase
    {

        private IEstatTramitacioMestreService _estatTramitacioMestreService;

        private readonly IMapper _mapper;

        public EstatTramitacioMestresController(IEstatTramitacioMestreService estatTramitacioMestreService, IMapper mapper)
        {
            _estatTramitacioMestreService = estatTramitacioMestreService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EstatTramitacioMestreDto>>>> GetActions()
        {

            var response = await _estatTramitacioMestreService.GetEstatTramitacioMestresAsync();
            return Ok(response);

        }




    }
}
