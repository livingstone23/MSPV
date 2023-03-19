using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{
    [Table("General-OfficeUser", Schema = "dbo")]
    public class GeneralOfficeUser
    {


        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public Guid? Subscription { get; set; }
        public string nif { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string MobilePhone { get; set; }
        public string Phax { get; set; }
        public string userIdentifier { get; set; }
        public string originCenter { get; set; }
        public string destinyCenter { get; set; }
        public bool? gimActivate { get; set; }
        public string contrateType { get; set; }
        public string product { get; set; }
        public string contract { get; set; }
        public string expenseType { get; set; }
        public string demandNumber { get; set; }
        public string courtroom { get; set; }
        public string courtNumber { get; set; }
        public string autos { get; set; }
        public string contractNumber { get; set; }
        public Guid? Office { get; set; }
        
        public string PGestBaseObjectType { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }


        //Campos de control
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }



    }
}
