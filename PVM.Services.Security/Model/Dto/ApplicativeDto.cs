using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Security.Model.Dto;


public class ApplicativeDto
{
    [Key]
    public Guid Oid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string Url { get; set; }



    //Campos de control
    public bool IsActive { get; set; }
    public int? OptimisticLockField { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public int GCRecord { get; set; }

    public List<ViewActionDto> ViewActions { get; set; }
    public List<View> Views { get; set; }

}