using PVM.Services.Gestpro.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Services.Gestpro.Services.RegisterService
{
    public interface IRegisterService
    {
        Task<ServiceResponse<List<RegisterDto>>> GetRegisterAsync();

        Task<ServiceResponse<RegisterDto>> GetRegisterById(Guid actionId);

        //Task<ServiceResponse<RegisterDto>> CreateUpdateRegister(RegisterDto actionDto);

        //Task<ServiceResponse<bool>> DeleteRegister(Guid actionId);
    }
}