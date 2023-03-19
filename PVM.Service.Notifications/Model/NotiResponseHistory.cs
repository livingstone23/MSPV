using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{

    [Table("Noti-ResponseHistory", Schema = "dbo")]
    public class NotiResponseHistory
    {

        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public string PGestBaseObjectType { get; set; }
        public Guid? Subscription { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public DateTime? Date {get;set;}
        public string FileName { get; set; }
        public Guid? SendNotificationDetail { get; set; }
        public string Status { get; set; }
        public string SubStatus { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }

    }

}
