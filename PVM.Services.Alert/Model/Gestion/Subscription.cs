using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Services.Alert.Gestion
{
    [Table("Base-Subscriptions", Schema = "dbo")]
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Oid { get; set; }
	    public DateTime LastChange { get; set; }
        //public PolicyUser LastUser { get; set; }
        //[ForeignKey("LastUser")]
        public Guid LastUserId { get; set; }
        public string Namen { get; set; }
        public DateTime Date { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public string URLLogo { get; set; }
        public string PGestBaseObjectType { get; set; }
    }
}
