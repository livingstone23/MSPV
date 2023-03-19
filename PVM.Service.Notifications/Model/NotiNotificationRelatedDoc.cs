using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{


    [Table("Noti-NotificationRelatedDocs", Schema = "dbo")]
    public class NotiNotificationRelatedDoc
    {

        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public Guid? Subscription { get; set; }
        public Guid? SendNotificationDetail { get; set; }
        public int? Type { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? Date {get;set;}
        public bool? SentToFTP { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public Guid? Bundle { get; set; }
        public Guid? Consignment { get; set; }
        public string PGestBaseObjectType { get; set; }
        public bool? Download { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public bool? Obsolete { get; set; }

    }

}
