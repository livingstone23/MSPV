using PVM.Services.Security.Model;
using PVM.Services.Security.Model.Dto;
using PVM.SharedLibrary.Models;
using Action = PVM.Services.Security.Model.Action;

namespace PVM.Services.Security.Services.ActionService;




public interface IActionService
{

    Task<ServiceResponse<List<ActionDto>>> GetActionsAsync();

    Task<ServiceResponse<ActionDto>> GetActionById(Guid actionId);

    Task<ServiceResponse<ActionDto>> CreateUpdateAction(ActionDto actionDto);

    Task<ServiceResponse<bool>> DeleteAction(Guid actionId);

}