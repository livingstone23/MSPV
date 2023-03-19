using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PVM.Services.Gestpro.Model.Dto;
using PVM.Services.Gestpro.Services.ClientService;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Controllers.v1
{
    [Route("api/v1/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private IClientService _clientService;

        private readonly IMapper _mapper;

        public ClientsController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ClientDto>>>> GetActions()
        {

            var response = await _clientService.GetClientsAsync();
            return Ok(response);

        }



    }
}
