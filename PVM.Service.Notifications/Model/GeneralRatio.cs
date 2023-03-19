using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{
    [Table("General-Ratios", Schema = "dbo")]
    public class GeneralRatio
    {

        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public Guid? Subscription { get; set; }
        public string Code { get; set; }
        public int? MinimumQuantity { get; set; }
        public int? MaximumQuantity { get; set; }
        public double? TotalDiscounted { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public string Description { get; set; }
        public Guid? Provider { get; set; }
        public Guid? Channel { get; set; }
        public Guid? Service { get; set; }
        public Guid? Company { get; set; }
        public int? Units { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string PGestSubscriptionSequence { get; set; }


    }
}
