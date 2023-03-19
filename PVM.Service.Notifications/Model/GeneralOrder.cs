using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{
    [Table("General-Orders", Schema = "dbo")]
    public class GeneralOrder
    {

        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public string PGestBaseObjectType { get; set; }
        public Guid? Subscription { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public string DocumentCode { get; set; }
        public double? Price { get; set; }
        public double? ProviderPrice { get; set; }
        public Guid? OfficeUser { get; set; }
        public Guid? Project { get; set; }
        public int? Status { get; set; }
        public DateTime? EntryDate { get; set; }
        public Guid? ClaveFactura { get; set; }
        public double? VAT { get; set; }
        public double? TotalVAT { get; set; }
        public double? IRPF { get; set; }
        public string Observations { get; set; }
        public double? TotalOrder { get; set; }
        public Guid? SendNotificationDetail { get; set; }
        public Guid? InvoiceHeader { get; set; }
        public double? Discount { get; set; }
        public double? Supplied { get; set; }
        public double? TaxBase { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public Guid? Service { get; set; }
        public Guid? Company { get; set; }
        public Guid? Presupuesto { get; set; }
        public Guid? Provider { get; set; }
        public Guid? ProviderZone { get; set; }
        public string Proposal { get; set; }

    }
}
