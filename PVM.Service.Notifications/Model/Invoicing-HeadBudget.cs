using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{
    [Table("Invoicing-HeadBudget", Schema = "dbo")]
    public class Invoicing_HeadBudget
    {
        [Key]
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public string PGestBaseObjectType { get; set; }
        public Guid Subscription { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public string motiveRefuse { get; set; }
        public string Code { get; set; }
        public DateTime datebudget { get; set; }
        public DateTime DateStartBudget { get; set; }
        public DateTime DateEndtBudget { get; set; }
        public Guid Company { get; set; }
        public Guid Customer { get; set; }
        public Guid User { get; set; }
        public int BudgetStatus { get; set; }
        public string MotiveRefuse { get; set; }
        public double PercentajeDiscount { get; set; }
        public double PriceDiscount { get; set; }
        public double Total { get; set; }
        public bool Visor { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public Guid ClaveFactura { get; set; }
        public string TrabajosRealizar { get; set; }
        public string Observaciones { get; set; }
    }
}
