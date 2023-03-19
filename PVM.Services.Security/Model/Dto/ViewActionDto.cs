using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Security.Model.Dto;


public class ViewActionDto
{

    public Guid Oid { get; set; }

    public ActionDto Action { get; set; }

    public Guid ActiondId { get; set; }

    public Guid ViewId { get; set; }




    //Campos de control
    public bool IsActive { get; set; }
    public int? OptimisticLockField { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public int? GCRecord { get; set; }

}
