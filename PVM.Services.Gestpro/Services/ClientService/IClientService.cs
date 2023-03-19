using PVM.Services.Gestpro.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Services.ClientService
{
    public interface IClientService
    {
        Task<ServiceResponse<List<ClientDto>>> GetClientsAsync();

        Task<ServiceResponse<ClientDto>> GetClientById(int IdCli);


    }
}