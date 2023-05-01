using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVM.Services.Security.Model;
using PVM.Services.Security.Services.AuthService;
using PVM.SharedLibrary;

namespace PVM.Service.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;

        }


        //[HttpPost("register")]
        //public async Task<ActionResult<ServiceResponse<int>>> Register(PolicyUserRegister request)
        //{
        //    var response = await _authService.Register(new PolicyUser
        //    {
        //                                                    Email = request.Email
        //                                                },
        //                                                request.Password);

        //    if (!response.Success)
        //    {
        //        return BadRequest(response);
        //    }

        //    return Ok(response);
        //}


        //[HttpPost("login")]
        //public async Task<ActionResult<ServiceResponse<string>>> Login(PolicyUserLogin request)
        //{
        //    var response = await _authService.Login(request.Email, request.Password);
        //    if (!response.Success)
        //    {
        //        return BadRequest(response);
        //    }

        //    return Ok(response);
        //}


        ///// <summary>
        ///// Solo los autorizados pueden llamar al metodo
        ///// </summary>
        ///// <param name="newPassword"></param>
        ///// <returns></returns>
        //[HttpPost("change-password"), Authorize]
        //public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var response = await _authService.ChangePassword(int.Parse(userId), newPassword);

        //    if (!response.Success)
        //    {
        //        return BadRequest(response);
        //    }

        //    return Ok(response);
        //}

    }
}
