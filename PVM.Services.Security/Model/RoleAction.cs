using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PVM.Services.Security.Model.Dto;

namespace PVM.Services.Security.Model;

[Table("RoleAction", Schema = "Security")]
public class RoleAction
{
    [Key]
    public Guid Oid { get; set; }



    [ForeignKey("UserRole")]
    public string RoleId { get; set; }

    public View View { get; set; }

    [ForeignKey("View")]
    public Guid ViewId { get; set; }

    public Action Action { get; set; }
    [ForeignKey("Action")]

    public Guid ActionId { get; set; }




    //Campos de control
    public bool IsActive { get; set; }
    public int? OptimisticLockField { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public int GCRecord { get; set; }

}