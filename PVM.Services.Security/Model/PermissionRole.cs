using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PVM.Services.Security.Model;


[Index(nameof(Name), IsUnique = true)]
[Table("PermissionRole", Schema = "Security")]
public class PermissionRole
{
    [Key]
    public Guid Oid { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public bool IsAdministrative { get; set; }




    //Campos de control
    public bool IsActive { get; set; }
    public int? OptimisticLockField { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime DateModified { get; set; }
    public int? GCRecord { get; set; }

    public List<PolicyUserRol> Roles { get; set; }

    public List<RoleAction> RoleAction { get; set; }

}