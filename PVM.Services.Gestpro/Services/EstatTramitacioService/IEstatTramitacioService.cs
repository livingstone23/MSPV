using PVM.Services.Gestpro.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Services.EstatTramitacioService
{
    public interface IEstatTramitacioService
    {

        Task<ServiceResponse<List<EstatTramitacioDto>>> GetEstatTramitaciosAsync();

        Task<ServiceResponse<EstatTramitacioDto>> GetEstatTramitacioById(int IdCli);

    }
}