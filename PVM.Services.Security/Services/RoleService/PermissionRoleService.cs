using Microsoft.EntityFrameworkCore;
using PVM.Services.Security.DbContexts;
using PVM.Services.Security.Model;
using PVM.Services.Security.Services.PolicyUserService;
using PVM.SharedLibrary;

namespace PVM.Services.Security.Services.RoleService
{
    public class PermissionRoleService //: IPermissionRoleService
    {


        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public PermissionRoleService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        ///Metodo para implementar la paginacion
        //public async Task<ServiceResponse<PermissionRoleSearchResult>> SearchPermissionRole(string searchText, int page)
        //{

        //    var pageResults = 2f;
        //    var pageCount = Math.Ceiling((await FindPermissionRoleBySearchText(searchText)).Count / pageResults);
        //    var permissionRoles = await _context.PermissionRoles.Where(p => p.Name.ToLower().Contains(searchText.ToLower()))
        //        .Include(p => p.Roles)
        //        .Skip((page - 1) * (int)pageResults)
        //        .Take((int)pageResults)
        //        .ToListAsync();

        //    var response = new ServiceResponse<PermissionRoleSearchResult>
        //    {
        //        Data = new PermissionRoleSearchResult
        //        {
        //            PermissionRoles = permissionRoles,
        //            CurrentPage = page,
        //            Pages = (int)pageCount
        //        }
        //    };

        //    return response;


        //}

        //public async Task<ServiceResponse<PermissionRole>> GetPermissionRoleAsync(Guid roleId)
        //{

        //    var response = new ServiceResponse<PermissionRole>();

        //    PermissionRole permissionRole = null;


        //    permissionRole = await _context.PermissionRoles
        //        .Include(p => p.Roles)
        //        .FirstOrDefaultAsync(p => p.Oid == roleId);


        //    if (permissionRole == null)
        //    {
        //        response.Success = false;
        //        response.Message = "Sorry, but the role does not exist.";
        //    }
        //    else
        //    {
        //        response.Data = permissionRole;
        //    }

        //    return response;

        //}


        //private async Task<List<PermissionRole>> FindPermissionRoleBySearchText(string searchText)
        //{
        //    return await _context.PermissionRoles
        //        .Where(p => p.Name.ToLower().Contains(searchText.ToLower()))
        //        .ToListAsync();


        //}



        //public async Task<ServiceResponse<List<PermissionRole>>> GetPermissionRoles()
        //{

        //    var response = new ServiceResponse<List<PermissionRole>>
        //    {
        //        Data = await _context.PermissionRoles.Where(p => !p.IsActive)
        //            .ToListAsync()
        //    };

        //    return response;

        //}



        //public async Task<ServiceResponse<PermissionRole>> CreatePermissionRole(PermissionRole role)
        //{

        //    _context.PermissionRoles.Add(role);
        //    await _context.SaveChangesAsync();
        //    return new ServiceResponse<PermissionRole> { Data = role };

        //}



        //public async Task<ServiceResponse<PermissionRole>> UpdatePermissionRole(PermissionRole role)
        //{

        //    var dbPermissionRole  = await _context.PermissionRoles
        //        .FirstOrDefaultAsync(p => p.Oid == role.Oid);

        //    if (dbPermissionRole == null)
        //    {
        //        return new ServiceResponse<PermissionRole>
        //        {
        //            Success = false,
        //            Message = "Role not found for update."
        //        };
        //    }

        //    dbPermissionRole.Name = role.Name;
        //    dbPermissionRole.IsAdministrative = role.IsAdministrative;

        //    dbPermissionRole.IsActive = role.IsActive;
        //    dbPermissionRole.OptimisticLockField += 1;
        //    dbPermissionRole.DateModified = DateTime.Now;
        //    dbPermissionRole.GCRecord = role.GCRecord;

        //    await _context.SaveChangesAsync();
        //    return new ServiceResponse<PermissionRole> { Data = role };

        //}



        //public async Task<ServiceResponse<bool>> DeletePermissionRole(Guid userId)
        //{

        //    var dbPermissionRole = await _context.PermissionRoles.FirstOrDefaultAsync(p=>p.Oid ==userId);

        //    if (dbPermissionRole == null)
        //    {
        //        return new ServiceResponse<bool>
        //        {
        //            Success = false,
        //            Data = false,
        //            Message = "Role not found."
        //        };
        //    }

        //    //Pendiente registrar la fecha en formato numerico
        //    //año, mes, dia
        //    string varPendiente = DateTime.Now.Date.ToShortDateString();
        //    dbPermissionRole.GCRecord = 1;

        //    await _context.SaveChangesAsync();
        //    return new ServiceResponse<bool> { Data = true };

        //}



    }

}
