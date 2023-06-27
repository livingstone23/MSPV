using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{
    [Table("General-Service", Schema = "dbo")]
    public class GeneralService
    {

        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string EmailPersonResponsibleService { get; set; }
        public string Directory { get; set; }



        //Campos de control
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }



    }
}
