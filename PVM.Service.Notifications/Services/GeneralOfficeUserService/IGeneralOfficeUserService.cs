using PVM.Service.Notifications.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Notifications.Services.GeneralOfficeUserService
{
    public interface IGeneralOfficeUserService
    {

        Task<ServiceResponse<List<GeneralOfficeUserDto>>> GetGeneralOfficeUsersAsync();

        Task<ServiceResponse<GeneralOfficeUserDto>> GetGeneralOfficeUserById(Guid id);

    }
}