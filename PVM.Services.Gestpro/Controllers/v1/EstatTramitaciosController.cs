using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVM.Services.Gestpro.Model.Dto;
using PVM.Services.Gestpro.Services.ClientService;
using PVM.Services.Gestpro.Services.EstatTramitacioService;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Controllers.v1
{
    [Route("api/v1/EstatTramitacios")]
    [ApiController]
    public class EstatTramitaciosController : ControllerBase
    {

        private IEstatTramitacioService _estatTramitacioService;

        private readonly IMapper _mapper;

        public EstatTramitaciosController(IEstatTramitacioService estatTramitacioService, IMapper mapper)
        {

            _estatTramitacioService = estatTramitacioService;
            _mapper = mapper;

        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EstatTramitacioDto>>>> GetActions()
        {

            var response = await _estatTramitacioService.GetEstatTramitaciosAsync();
            return Ok(response);

        }



    }
}
