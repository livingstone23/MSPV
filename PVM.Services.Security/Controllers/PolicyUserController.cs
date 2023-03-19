using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVM.Services.Security.Model;
using PVM.Services.Security.Services.AuthService;
using PVM.Services.Security.Services.PolicyUserService;
using PVM.SharedLibrary;

namespace PVM.Services.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PolicyUserController : ControllerBase
    {

        private readonly IPolicyUserService _policyUserService;


        public PolicyUserController(IPolicyUserService policyUserService)
        {
            _policyUserService = policyUserService;

        }



        //[HttpGet]
        //public async Task<ActionResult<ServiceResponse<List<PolicyUser>>>> GetUsers()
        //{
        //    var result = await _policyUserService.GetPolicyUsers();

        //    return Ok(result);
        //}



        //[HttpGet("{userId}")]
        //public async Task<ActionResult<ServiceResponse<PolicyUser>>> GetUser(int userId)
        //{
        //    var result = await _policyUserService.GetPolicyUserAsync(userId);
        //    return Ok(result);
        //}



        //[HttpGet("search/{searchText}/{page}")]
        //public async Task<ActionResult<ServiceResponse<PolicyUserSearchResult>>> Searchproducts(string searchText, int page = 1)
        //{
        //    var result = await _policyUserService.SearchPolicyUser(searchText, page);
        //    return Ok(result);
        //}



        //[HttpPost("register")]
        //public async Task<ActionResult<ServiceResponse<int>>> Register(PolicyUser request)
        //{
        //    var response = await _policyUserService.CreatePolicyUser(request);

        //    if (!response.Success)
        //    {
        //        return BadRequest(response);
        //    }

        //    return Ok(response);
        //}



        //[HttpPut("update")]
        //public async Task<ActionResult<ServiceResponse<int>>> Update(PolicyUser request)
        //{
        //    var response = await _policyUserService.UpdatePolicyUser(request);

        //    if (!response.Success)
        //    {
        //        return BadRequest(response);
        //    }

        //    return Ok(response);
        //}



        //[HttpDelete("delete")]
        //public async Task<ActionResult<ServiceResponse<int>>> delete(int PolicyUserId)
        //{
        //    var response = await _policyUserService.DeletePolicyUser(PolicyUserId);

        //    if (!response.Success)
        //    {
        //        return BadRequest(response);
        //    }

        //    return Ok(response);
        //}

    }

}
