using PVM.Services.Gestpro.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Services.EstatTramitacioMestre
{
    public interface IEstatTramitacioMestreService
    {

        Task<ServiceResponse<List<EstatTramitacioMestreDto>>> GetEstatTramitacioMestresAsync();

        Task<ServiceResponse<EstatTramitacioMestreDto>> GetEstatTramitacioMestreById(int IdCli);

    }
}