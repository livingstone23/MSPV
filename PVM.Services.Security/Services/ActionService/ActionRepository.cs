using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PVM.Services.Security.DbContexts;
using PVM.Services.Security.Model.Dto;
using PVM.SharedLibrary.Models;
using Action = PVM.Services.Security.Model.Action;

namespace PVM.Services.Security.Services.ActionService;




public class ActionService : IActionService
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ActionService(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<ActionDto>>> GetActionsAsync()
    {
        var response = new ServiceResponse<List<ActionDto>> { };

        try
        {
            
            List<Action> actionList = await _db.Actions.ToListAsync();
            var responseDto = _mapper.Map<List<ActionDto>>(actionList);
            response.Data = responseDto;
            
            return response;
            
        }
        catch (Exception e)
        {
            response.Success = false;
            response.ErrorMessages = new List<string>() { e.ToString() };
            return response;
        }

    }



    public async Task<ServiceResponse<ActionDto>> GetActionById(Guid actionId)
    {
        var response = new ServiceResponse<ActionDto> {};

        try
        {

            Action action = await _db.Actions.Where(x => x.Oid == actionId).FirstOrDefaultAsync();
            var responseDto = _mapper.Map<ActionDto>(action);
            response.Data = responseDto;
            return response;

        }
        catch (Exception e)
        {
            response.Success = false;
            response.ErrorMessages = new List<string>() { e.ToString() };
            return response;
        }

    }

    public async Task<ServiceResponse<ActionDto>> CreateUpdateAction(ActionDto actionDto)
    {

        var response = new ServiceResponse<ActionDto> { };

        try
        {
            Action action = _mapper.Map<ActionDto, Action>(actionDto);
            
            if (action is not null)
            {
                _db.Actions.Update(action);
            }
            else
            {
                _db.Actions.Add(action);
            }

            await _db.SaveChangesAsync();
            var responseDto = _mapper.Map<Action, ActionDto>(action);
            response.Data = responseDto;
            return response;
        }
        catch (Exception e)
        {
            response.Success = false;
            response.ErrorMessages = new List<string>() { e.ToString() };
            return response;
        }
    }

    public async Task<ServiceResponse<bool>> DeleteAction(Guid actionId)
    {

        var response = new ServiceResponse<bool> { };

        try
        {

            Action action = await _db.Actions.FirstOrDefaultAsync(u => u.Oid == actionId);
            if (action == null)
            {
                response.Data = false;
            }
            _db.Actions.Remove(action);
            await _db.SaveChangesAsync();
            response.Data = true;
            return response;

        }
        catch (Exception e)
        {
            response.Success = false;
            response.ErrorMessages = new List<string>() { e.ToString() };
            return response;
        }

    }
}