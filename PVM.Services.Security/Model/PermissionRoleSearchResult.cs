namespace PVM.Services.Security.Model
{
    public class PermissionRoleSearchResult
    {


        public int Pages { get; set; }
        public int CurrentPage { get; set; }

        public List<PermissionRole> PermissionRoles  { get; set; } = new List<PermissionRole>();


    }
}
