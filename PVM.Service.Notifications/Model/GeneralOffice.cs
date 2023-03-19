using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{


    [Table("General-Office", Schema = "dbo")]
    public class GeneralOffice
    {


        [Key]
        public Guid Oid { get; set; }
        
        public Guid? LastUser { get; set; }
        public Guid? Subscription { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? Customer { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public int? TypeOffice { get; set; }



        public DateTime? LastChange { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }


    }
}
