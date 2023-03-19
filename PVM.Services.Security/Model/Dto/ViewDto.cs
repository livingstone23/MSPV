using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PVM.Services.Security.Model.dto;

namespace PVM.Services.Security.Model.Dto;


public class ViewDto
{

    public Guid Oid { get; set; }

    public Guid ApplicativeId { get; set; }
    public String AssemblyName { get; set; }
    public String ClassName { get; set; }
    public String Name { get; set; }
    public String Caption { get; set; }
    public Guid? Parent { get; set; }




    //Campos de control
    public bool IsActive { get; set; }
    public int? OptimisticLockField { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public int? GCRecord { get; set; }

    public List<RoleActionDto> RoleAction { get; set; }

}