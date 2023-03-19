using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{

    [Table("Noti-Bundle", Schema = "dbo")]
    public class NotiBundle
    {

        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public Guid? Subscription { get; set; }
        public int? NumberBundle { get; set; }
        public int? Weight { get; set; }
        public int? Long { get; set; }
        public int? High { get; set; }
        public int? Width { get; set; }
        public string TagBase64 { get; set; }
        public Guid? SendNotificationDetail { get; set; }
        public string CodeSend { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string PGestSubscriptionSequence { get; set; }

    }

}
