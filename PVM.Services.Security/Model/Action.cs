using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PVM.Services.Security.Model.Dto;

namespace PVM.Services.Security.Model;

[Table("Action", Schema = "Security")]
public class Action
{
    [Key]
    public Guid Oid { get; set; }
    public String Code { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }




    //Campos de control
    public bool IsActive { get; set; }
    public int? OptimisticLockField { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public int? GCRecord { get; set; }

    public List<View> Views { get; set; }
    public List<RoleAction> RoleAction { get; set; }

}