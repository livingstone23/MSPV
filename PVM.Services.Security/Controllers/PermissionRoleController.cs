using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVM.Services.Security.Model;
using PVM.Services.Security.Services.RoleService;
using PVM.SharedLibrary;

namespace PVM.Service.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionRoleController : ControllerBase
    {

        private readonly IPermissionRoleService _permissionRoleService;

        public PermissionRoleController(IPermissionRoleService permissionRoleService)
        {
            _permissionRoleService = permissionRoleService;
        }



        //[HttpGet]
        //public async Task<ActionResult<ServiceResponse<List<PermissionRole>>>> GetRoles()
        //{
        //    var result = await _permissionRoleService.GetPermissionRoles();

        //    return Ok(result);
        //}



        //[HttpGet("{roleId}")]
        //public async Task<ActionResult<ServiceResponse<PermissionRole>>> GetRole(Guid roleId)
        //{
        //    var result = await _permissionRoleService.GetPermissionRoleAsync(roleId);
        //    return Ok(result);
        //}



        //[HttpGet("search/{searchText}/{page}")]
        //public async Task<ActionResult<ServiceResponse<PermissionRoleSearchResult>>> SearchRoles(string searchText, int page = 1)
        //{
        //    var result = await _permissionRoleService.SearchPermissionRole(searchText, page);
        //    return Ok(result);
        //}



        //[HttpPost("register")]
        //public async Task<ActionResult<ServiceResponse<int>>> Register(PermissionRole request)
        //{
        //    var response = await _permissionRoleService.CreatePermissionRole(request);

        //    if (!response.Success)
        //    {
        //        return BadRequest(response);
        //    }

        //    return Ok(response);
        //}



        //[HttpPut("update")]
        //public async Task<ActionResult<ServiceResponse<int>>> Update(PermissionRole request)
        //{
        //    var response = await _permissionRoleService.UpdatePermissionRole(request);

        //    if (!response.Success)
        //    {
        //        return BadRequest(response);
        //    }

        //    return Ok(response);
        //}



        //[HttpDelete("delete")]
        //public async Task<ActionResult<ServiceResponse<int>>> delete(Guid permissionRoleId)
        //{
        //    var response = await _permissionRoleService.DeletePermissionRole(permissionRoleId);

        //    if (!response.Success)
        //    {
        //        return BadRequest(response);
        //    }

        //    return Ok(response);
        //}


    }


}
