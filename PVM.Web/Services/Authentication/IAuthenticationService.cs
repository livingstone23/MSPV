

using PVM.Web.Models.Security;

namespace PVM.Web.Service.Authentication;

public interface IAuthenticationService
{
    Task<RegisterationResponseDTO> RegisterUser(UserRequestDTO userForRegisteration);

    Task<AuthenticationResponseDTO> Login(AuthenticationDTO userFromAuthentication);

    Task Logout();
}