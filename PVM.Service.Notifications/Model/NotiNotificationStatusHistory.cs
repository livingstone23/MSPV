using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{

    [Table("Noti-NotificationStatusHistory", Schema = "dbo")]
    public class NotiNotificationStatusHistory
    {

        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public Guid? Subscription { get; set; }
        public Guid? SendNotificationDetail { get; set; }
        public Guid? ProviderStatus { get; set; }
        public DateTime? Date {get;set;}
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public string Remark { get; set; }
        public Guid? Status { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public Guid? CustomerStatus { get; set; }

    }
}
