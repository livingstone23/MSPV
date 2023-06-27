using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{
    [Table("Base-Subscriptions", Schema = "dbo")]
    public class Base_Subscriptions
    {
        [Key]
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public string Name { get; set; }

        public DateTime Date {get;set;}
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string URLLogo { get; set; }
        public Guid OidUNICA { get; set; }
}
}
