using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{
    [Table("General-ProviderStatus", Schema = "dbo")]
    public class GeneralProviderStatus
    {
        [Key]
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid Provider { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public string Observation { get; set; }
        public Guid CustomerCompanyStatus { get; set; }
        public Guid ProvimadStatus { get; set; }
        public string PGestBaseObjectType { get; set; }
    }
}
