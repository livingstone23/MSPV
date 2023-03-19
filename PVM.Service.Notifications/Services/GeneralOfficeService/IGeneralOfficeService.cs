using PVM.Service.Notifications.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Notifications.Services.GeneralOfficeService
{
    public interface IGeneralOfficeService
    {


        Task<ServiceResponse<List<GeneralOfficeDto>>> GetGeneralOfficesAsync();

        Task<ServiceResponse<GeneralOfficeDto>> GetGeneralOfficeById(Guid id);


    }
}