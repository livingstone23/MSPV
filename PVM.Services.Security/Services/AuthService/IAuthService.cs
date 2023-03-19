using PVM.Services.Security.Model;
using PVM.SharedLibrary;

namespace PVM.Services.Security.Services.AuthService;

public interface IAuthService
{

    //Task<ServiceResponse<int>> Register(PolicyUser user, string password);
    //Task<bool> UserExists(string email);

    //Task<ServiceResponse<string>> Login(string email, string password);

    //Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);

    int GetUserId();
    string GetUserEmail();

}