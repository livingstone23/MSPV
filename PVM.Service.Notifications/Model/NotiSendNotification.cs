using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{

    [Table("Noti-SendNotifications", Schema = "dbo")]
    public class NotiSendNotification
    {
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public Guid Subscription { get; set; }
        public string Code { get; set; }
        public string Text { get;set;}
        public Guid Recipient { get; set; }
        public string OriginOffice { get; set; }
        public string DestinyOffice { get; set; }
        public string ContractType { get; set; }
        public string ContractNumber { get; set; }
        public Guid OfficeUser { get; set; }
        public Guid NotificationFile { get; set; }
        public Guid Mail { get; set; }
        public string Status { get; set; }
        public Guid InvoiceHeader { get; set; }
        public Guid FTP { get; set; }
        public Guid ClaveFactura { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public string Product { get; set; }
        public bool Remitted { get; set; }
        public Guid Subservice { get; set; }
        public int ProvimadStatusNotification { get; set; }
        public string Zone { get; set; }
        public string AddressType { get; set; }
        public DateTime CreationDate { get; set; }
        public string NotificationType { get; set; }
        public Guid ProviderZone { get; set; }
        public string CustomerReference { get; set; }
        public string TypeLetter { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public string ID_REFCLI2 { get; set; }
        public int LengthNumber { get; set; }
        public DateTime DateCustomer { get; set; }


}

}
