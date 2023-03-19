using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{

    [Table("General-Office", Schema = "dbo")]
    public class NotiIntermediateSubservice
    {

        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public string PGestBaseObjectType { get; set; }
        public Guid? SendNotificationDetail { get; set; }
        public Guid? Subservice { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }

    }
}
