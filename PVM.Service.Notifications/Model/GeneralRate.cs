using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{
    [Table("General-Rates", Schema = "dbo")]
    public class GeneralRate
    {

        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? Provider { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public Guid? Company { get; set; }
        public int? IncludedPages { get; set; }
        public string PGestBaseObjectType { get; set; }
        public int? IncludeCopyPages { get; set; }
        public bool? PEEInclude { get; set; }
        public bool? CCEInclude { get; set; }
        public Guid? Customer { get; set; }

    }
}
