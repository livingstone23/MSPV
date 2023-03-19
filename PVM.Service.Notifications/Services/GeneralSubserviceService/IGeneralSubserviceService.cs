using PVM.Service.Notifications.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Notifications.Services.GeneralSubservice
{
    public interface IGeneralSubserviceService
    {

        Task<ServiceResponse<List<GeneralSubserviceDto>>> GetGeneralSubservicesAsync();

        Task<ServiceResponse<GeneralSubserviceDto>> GetGeneralSubserviceById(Guid id);

    }
}
