using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{
    [Table("General-Subservice", Schema = "dbo")]
    public class GeneralSubservice
    {


        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
       
        public string PGestBaseObjectType { get; set; }
        public bool? ExcludeCalculateOrder { get; set; }


        //Campos de control
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }


    }

}
