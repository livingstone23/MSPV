using PVM.Services.Security.Model;
using PVM.SharedLibrary;

namespace PVM.Services.Security.Services.PolicyUserService;

public interface IPolicyUserService
{

    /// <summary>
    /// Metodo para implementar la paginacion
    /// </summary>
    /// <param name="searchText"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    //Task<ServiceResponse<PolicyUserSearchResult>> SearchPolicyUser(string searchText, int page);

    ////Task<ServiceResponse<List<PolicyUser>>> GetPolicyUserByCategory(string categoryUrl);


    //Task<ServiceResponse<PolicyUser>> GetPolicyUserAsync(int userId);

    //Task<ServiceResponse<List<PolicyUser>>> GetFeaturedPolicyUser();



    ////Metodos para la administracion 
    //Task<ServiceResponse<List<PolicyUser>>> GetPolicyUsers();
    //Task<ServiceResponse<PolicyUser>> CreatePolicyUser(PolicyUser product);
    //Task<ServiceResponse<PolicyUser>> UpdatePolicyUser(PolicyUser product);
    //Task<ServiceResponse<bool>> DeletePolicyUser(int userId);

}