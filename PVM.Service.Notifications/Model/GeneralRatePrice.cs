using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{
    [Table("General-RatePrices", Schema = "dbo")]
    public class GeneralRatePrice
    {
        
        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public string Code { get; set; }
        public double? Price { get; set; }
        public double? ProviderPrice { get; set; }
        public Guid? Rate { get; set; }
        public Guid? Channel { get; set; }
        public Guid? Service { get; set; }
        public Guid? Concept { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public double? Discount { get; set; }
        public Guid? ProviderZone { get; set; }
        public Guid? Ratio { get; set; }
        public string Type { get; set; }
        public string PGestBaseObjectType { get; set; }
        public int? TypeRate { get; set; }
        public int? IncludedPages { get; set; }
        public int? IncludeCopyPages { get; set; }

    }
}
