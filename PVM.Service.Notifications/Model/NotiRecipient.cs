using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{

    [Table("Noti-Recipients", Schema = "dbo")]
    public class NotiRecipient
    {


        [Key]
        public Guid Oid { get; set; }
        public DateTime? LastChange { get; set; }
        public Guid? LastUser { get; set; }
        public Guid? Subscription { get; set; }
        public string Identifier { get; set; }
        public string IdentifierType { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LastName2 { get; set; }
        public string RecipientCompany { get; set; }
        public string CountryName { get; set; }
        public string Province { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string StreetType { get; set; }
        public string StreetNum { get; set; }
        public string DoorNumber { get; set; }
        public string Floor { get; set; }
        public string Portal { get; set; }
        public string Block { get; set; }
        public string Stairs { get; set; }
        public string ContactPerson { get; set; }
        public string PostalCode { get; set; }
        public string postOfficeBox { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Phax { get; set; }
        public string CompanyName { get; set; }
        public string KM { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public Guid? CountryISO { get; set; }
        public Guid? Consignment { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public Guid? SendNotificationDetail { get; set; }

    }

}
