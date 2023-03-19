using PVM.Service.Notifications.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Notifications.Services.GeneralService
{
    public interface IGeneralServiceService
    {

        Task<ServiceResponse<List<GeneralServiceDto>>> GetGeneralServicesAsync();

        Task<ServiceResponse<GeneralServiceDto>> GetGeneralServiceById(Guid id);

    }
}