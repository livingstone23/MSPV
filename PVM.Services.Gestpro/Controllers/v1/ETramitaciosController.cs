using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PVM.Service.Gestpro.Model.Dto;
using PVM.Services.Gestpro.Model.Dto;
using PVM.Services.Gestpro.Services.ETramitacioService;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Controllers.v1
{
    [Route("api/v1/etramitacios")]
    [ApiController]
    public class ETramitaciosController : ControllerBase
    {

        private IETramitacioService _etramitacioService;

        private readonly IMapper _mapper;


        public ETramitaciosController(IETramitacioService etramitacioService, IMapper mapper)
        {
            _etramitacioService = etramitacioService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<RegisterDto>>>> GetActions()
        {

            var response = await _etramitacioService.GetEtramitaciosAsync();
            return Ok(response);

        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<RegisterDto>>>> GetActions(int id)
        {

            var response = await _etramitacioService.GetEtramitacioById(id);
            return Ok(response);

        }


        [HttpGet("ETramitacioPagination", Name = "ETramitacioPagination")]
        public async Task<ActionResult<ServiceResponse<ETramitacioSearchResult>>> ETramitacioPagination([FromQuery] PaginationDTO paginationDto)
        {

            var result = await _etramitacioService.SearchETramitacio(paginationDto);
            return Ok(result);

        }


    }
}
