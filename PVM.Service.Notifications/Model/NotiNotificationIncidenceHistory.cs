using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{

    [Table("Noti-NotificationIncidenceHistory", Schema = "dbo")]
    public class NotiNotificationIncidenceHistory
    {

        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public string PGestBaseObjectType { get; set; }
        public Guid? Subscription { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public DateTime? IncidenceDate { get; set; }
        public string Comment { get; set; }
        public string User { get; set; }
        public Guid? SendNotificationDetail { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public Guid? Consignment { get; set; }


    }

}
