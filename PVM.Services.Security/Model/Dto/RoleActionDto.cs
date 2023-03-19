using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PVM.Services.Security.Model.Dto;

namespace PVM.Services.Security.Model.dto;


public class RoleActionDto
{

    public Guid Oid { get; set; }



    public int RoleId { get; set; }

    public ViewDto View { get; set; }

    public Guid ViewId { get; set; }

    public Guid ActionId { get; set; }





    //Campos de control
    public bool IsActive { get; set; }
    public int? OptimisticLockField { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public int GCRecord { get; set; }

}