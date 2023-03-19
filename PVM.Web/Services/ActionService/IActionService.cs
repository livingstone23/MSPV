using PVM.SharedLibrary.Models;
using PVM.Web.Models.Security;

namespace PVM.Web.Services.ActionService;

public interface IActionService
{

    event Action ActionsChanged;

    string Message { get; set; }

    List<ActionDto> ListActions { get; set; }
    Task  GetActions();

    Task<ServiceResponse<ActionDto>> GetActionById(Guid actiontId);

    Task<ActionDto> UpdateAction(ActionDto action);

    Task<ActionDto> CreateAction(ActionDto action);

    Task DeleteAction(ActionDto action);



}