using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PVM.Services.Security.Model;

[Index(nameof(Email), IsUnique = true)]
[Table("PolicyUser", Schema = "Security")]
public class PolicyUser : IdentityUser
{
   
    
    public bool ChangePasswordOnFirstLogon { get; set; }
    
    public string FirstName { get; set; }
    public string SurName { get; set; }
    public string LastName { get; set; }
    public string SecondName { get; set; }


    //Campos de control
    public bool IsActive { get; set; }
    public int? OptimisticLockField { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime DateModified { get; set; }
    public int? GCRecord { get; set; }


    public List<PolicyUserRol> Roles { get; set; }


}