using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PVM.Services.Security.Model.Dto;

namespace PVM.Services.Security.Model;

[Table("ViewAction", Schema = "Security")]
public class ViewAction
{
    [Key]
    public Guid Oid { get; set; }

    public Action Action { get; set; }

    [ForeignKey("Action")]
    
    public Guid ActiondId { get; set; }

    public View View { get; set; }

    [ForeignKey("View")]
    public Guid ViewId { get; set; }




    //Campos de control
    public bool IsActive { get; set; }
    public int? OptimisticLockField { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public int? GCRecord { get; set; }

}
