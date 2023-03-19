using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{
    [Table("General-Concepts", Schema = "dbo")]
    public class GeneralConcept
    {

        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public Guid? Subservice { get; set; }
        public Guid? Channel { get; set; }
        public Guid? Service { get; set; }
        public Guid? Provider { get; set; }
        public string PGestBaseObjectType { get; set; }
        public Guid? TranslateInvoiceConcepts { get; set; }

    }
}
