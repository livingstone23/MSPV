using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PVM.Services.Gestpro.DbContexts;
using PVM.Services.Gestpro.Model;
using PVM.Services.Gestpro.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Services.ClientService
{
    public class ClientService : IClientService
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;


        public ClientService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ClientDto>>> GetClientsAsync()
        {
            var response = new ServiceResponse<List<ClientDto>> { };

            try
            {

                List<Client> ClientList = await _db.Clients.ToListAsync();
                var responseDto = _mapper.Map<List<ClientDto>>(ClientList);
                response.Data = responseDto;

                return response;

            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessages = new List<string>() { e.ToString() };
                return response;
            }
        }

        public async Task<ServiceResponse<ClientDto>> GetClientById(int IdCli)
        {

            var response = new ServiceResponse<ClientDto> { };

            try
            {

                Client client = await _db.Clients.Where(x => x.IdCli == IdCli).FirstOrDefaultAsync();
                var responseDto = _mapper.Map<ClientDto>(client);
                response.Data = responseDto;
                return response;

            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessages = new List<string>() { e.ToString() };
                return response;
            }

        }
    }
}
