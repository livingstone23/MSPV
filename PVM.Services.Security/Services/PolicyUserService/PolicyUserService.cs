using Microsoft.EntityFrameworkCore;
using PVM.Services.Security.DbContexts;
using PVM.Services.Security.Model;
using PVM.SharedLibrary;

namespace PVM.Services.Security.Services.PolicyUserService
{
    //public class PolicyUserService: IPolicyUserService
    //{


    //    private readonly ApplicationDbContext _context;
    //    private readonly IHttpContextAccessor _httpContextAccessor;


    //    public PolicyUserService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    //    {
    //        _context = context;
    //        _httpContextAccessor = httpContextAccessor;
    //    }



    //    ///Metodo para implementar la paginacion
    //    //public async Task<ServiceResponse<PolicyUserSearchResult>> SearchPolicyUser(string searchText, int page)
    //    //{

    //    //    var pageResults = 2f;
    //    //    var pageCount = Math.Ceiling((await FindPolicyUserBySearchText(searchText)).Count / pageResults);
    //    //    var policyUsers = await _context.PolicyUsers.Where(p => p.Email.ToLower().Contains(searchText.ToLower()) ||
    //    //                                                         p.UserName.ToLower().Contains(searchText.ToLower()))
    //    //                                                        .Include(p => p.Roles)
    //    //                                                        .Skip((page - 1) * (int)pageResults)
    //    //                                                        .Take((int)pageResults)
    //    //                                                        .ToListAsync();

    //    //    var response = new ServiceResponse<PolicyUserSearchResult>
    //    //    {
    //    //        Data = new PolicyUserSearchResult
    //    //        {
    //    //            PolicyUsers = policyUsers,
    //    //            CurrentPage = page,
    //    //            Pages = (int)pageCount
    //    //        }
    //    //    };

    //    //    return response;

    //    //}


    //    //public async Task<ServiceResponse<PolicyUser>> GetPolicyUserAsync(int userId)
    //    //{

    //    //    var response = new ServiceResponse<PolicyUser>();

    //    //    PolicyUser policyUser = null;


    //    //    policyUser = await _context.PolicyUsers
    //    //        .Include(p => p.Roles)
    //    //        .FirstOrDefaultAsync(p => p.Oid == userId);


    //    //    if (policyUser == null)
    //    //    {
    //    //        response.Success = false;
    //    //        response.Message = "Sorry, but this user does not exist.";
    //    //    }
    //    //    else
    //    //    {
    //    //        response.Data = policyUser;
    //    //    }

    //    //    return response;

    //    //}


    //    private async Task<List<PolicyUser>> FindPolicyUserBySearchText(string searchText)
    //    {
    //        return await _context.PolicyUsers
    //            .Where(p => p.Email.ToLower().Contains(searchText.ToLower()) ||
    //                        p.UserName.ToLower().Contains(searchText.ToLower()))
    //            .Include(p => p.Roles)
    //            .ToListAsync();


    //    }



    //    //public async Task<ServiceResponse<List<PolicyUser>>> GetFeaturedPolicyUser()
    //    //{

    //    //    var response = new ServiceResponse<List<PolicyUser>>
    //    //    {
    //    //        Data = await _context.PolicyUsers
    //    //            .Where(p => p.IsActive)
    //    //            .Include(p => p.Roles)
    //    //            .ToListAsync()
    //    //    };

    //    //    return response;

    //    //}


        
    //    public async Task<ServiceResponse<List<PolicyUser>>> GetPolicyUsers()
    //    {

    //        var response = new ServiceResponse<List<PolicyUser>>
    //        {
    //            Data = await _context.PolicyUsers.Where(p => !p.IsActive)
    //                .Include(p => p.Roles.Where(v => !v.IsActive))
    //                .ToListAsync()
    //        };

    //        return response;

    //    }



    //    //public async Task<ServiceResponse<PolicyUser>> CreatePolicyUser(PolicyUser user)
    //    //{

    //    //    //_context.PolicyUsers.Add(user);
    //    //    //await _context.SaveChangesAsync();
    //    //    //return new ServiceResponse<PolicyUser> { Data = user };

    //    //}



    //    //public async Task<ServiceResponse<PolicyUser>> UpdatePolicyUser(PolicyUser policyUser)
    //    //{

    //    //    var dbPolicyUser = await _context.PolicyUsers
    //    //                                .Include(p => p.Roles)
    //    //                                .FirstOrDefaultAsync(p => p.Oid == policyUser.Oid);

    //    //    if (dbPolicyUser == null)
    //    //    {
    //    //        return  new ServiceResponse<PolicyUser>
    //    //        {
    //    //            Success = false, Message = "User not found for update."
    //    //        };
    //    //    }

    //    //    dbPolicyUser.ChangePasswordOnFirstLogon = policyUser.ChangePasswordOnFirstLogon;

    //    //    dbPolicyUser.UserName = policyUser.UserName;
    //    //    dbPolicyUser.FirstName = policyUser.FirstName;
    //    //    dbPolicyUser.SurName = policyUser.SurName;
    //    //    dbPolicyUser.LastName = policyUser.LastName;
    //    //    dbPolicyUser.SecondName = policyUser.SecondName;
    //    //    dbPolicyUser.Email = policyUser.Email;
    //    //    dbPolicyUser.Telephone = policyUser.Telephone;
    //    //    dbPolicyUser.Subscription = policyUser.Subscription;
    //    //    dbPolicyUser.WelcomeMailSent = policyUser.WelcomeMailSent;
    //    //    dbPolicyUser.APIKey = policyUser.APIKey;
    //    //    dbPolicyUser.Empresa = policyUser.Empresa;
    //    //    dbPolicyUser.Oficina = policyUser.Oficina;
    //    //    dbPolicyUser.Nif = policyUser.Nif;
    //    //    dbPolicyUser.IsActive = policyUser.IsActive;
    //    //    dbPolicyUser.OptimisticLockField =+1;
    //    //    dbPolicyUser.DateModified = DateTime.Now;
    //    //    dbPolicyUser.GCRecord = policyUser.GCRecord;

    //    //    //Pendiente funcionalidad que eliminar el rol por usuario.
    //    //    //???????????????????????????????
    //    //    //???????????????????????????????

    //    //    foreach (var roles in policyUser.Roles)
    //    //    {

    //    //        var dbUserRole = await _context.UserRoles.SingleOrDefaultAsync(v => v.UserRoleId == roles.UserRoleId);

    //    //        if (dbUserRole == null)
    //    //        {

    //    //        }
    //    //        else
    //    //        {

    //    //            dbUserRole.PolicyUserId = policyUser.Oid;
    //    //            dbUserRole.UserRoleId = roles.UserRoleId;
    //    //            dbUserRole.DateCreated = DateTime.Now;
    //    //            dbUserRole.DateModified = DateTime.Now;
    //    //            dbUserRole.IsActive = true;

    //    //        }
    //    //    }


    //    //    await _context.SaveChangesAsync();
    //    //    return new ServiceResponse<PolicyUser> { Data = policyUser };

    //    //}



    //    //public async Task<ServiceResponse<bool>> DeletePolicyUser(int userId)
    //    //{

    //    //    var dbPolicyUser = await _context.PolicyUsers.FirstOrDefaultAsync(p =>p.Oid == userId);

    //    //    if (dbPolicyUser == null)
    //    //    {
    //    //        return new ServiceResponse<bool>
    //    //        {
    //    //            Success = false,
    //    //            Data = false,
    //    //            Message = "User not found."
    //    //        };
    //    //    }

    //    //    //Pendiente registrar la fecha en formato numerico
    //    //    //año, mes, dia
    //    //    string varPendiente = DateTime.Now.Date.ToShortDateString();
    //    //    dbPolicyUser.GCRecord = 1;

    //    //    await _context.SaveChangesAsync();
    //    //    return new ServiceResponse<bool> { Data = true };

    //    //}

        
    //}
}
