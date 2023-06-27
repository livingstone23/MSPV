using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{

    [Table("Noti-SendNotificationDetails", Schema = "dbo")]
    public class NotiSendNotificationDetail
    {
        [Key]
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public Guid Subscription { get; set; }
        public string Code { get; set; }
        public Guid SendNotification { get; set; }
        public DateTime ActivationDate { get; set; }
        public string Cause { get; set; }
        public string RelatedDoc { get; set; }
        public string FileType { get; set; }
        public string MessageText { get; set; }
        public int PagesNumber { get; set; }
        public Guid Channel { get; set; }
        public Guid Service { get; set; }
        public Guid ProviderStatus { get; set; }
        public Guid Provider { get; set; }
        public string RemittanceCode { get; set; }
        public string CodeSend { get; set; }
        public string LGTParCode { get; set; }
        public int RetriesNumber { get; set; }
        public int DaysToClose { get; set; }
        public Guid CustomerCompanyStatus { get; set; }
        public Guid Company { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public string CorreosFileSend { get; set; }
        public string ThirdPartyStatus { get; set; }
        public Guid Consignment { get; set; }
        public string CfsCodeMRW { get; set; }
        public bool PEE { get; set; }
        public DateTime AdmisionDate { get; set; }
        public bool CCE { get; set; }
        public string CCEID { get; set; }
        public string PEEID { get; set; }
        public int DaysLegalAction { get; set; }
        public DateTime DateLegalAction { get; set; }
        public bool SendEmailLegalAction { get; set; }
        public DateTime CancelationDate { get; set; }
        public Guid OfficeUser { get; set; }
        public Guid ProvimadStatus { get; set; }
        public decimal NotificationPrice { get; set; }
        public string Observations { get; set; }
        public bool NotificationReturned { get; set; }
        public bool NotificationRefunded { get; set; }
        public bool PEEDischarged { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string ActivationStatus { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public Guid Procedure { get; set; }
        public DateTime LastDateStatus { get; set; }
        public bool AnonymousLogaltyEntry { get; set; }
        public bool LogaltyAcceptanceCheckbox { get; set; }
        public string LogaltyRejectionCode { get; set; }
        public string LogaltyRejectionReason { get; set; }
        public bool OrderCreate { get; set; }
        public bool InvoiceCreate { get; set; }
        public string UploadInvoiceRef { get; set; }
        public string StatusCertificate { get; set; }
        public bool Reclaimed { get; set; }
        public DateTime LastClaimDate { get; set; }
        public string ClaimObservation { get; set; }
        public bool LetterReturned { get; set; }
        public DateTime ReceptionDate { get; set; }
        public string Warnings { get; set; }
        public Guid NotificationDelivered { get; set; }
        public DateTime DateNotificationDelivered { get; set; }
        public DateTime DateAlert { get; set; }
        public int ReasonAlert { get; set; }
        public string IncidenceLogalty { get; set; }
        public string IncidenceCorreos { get; set; }
        public string CodeLogaltyError { get; set; }
        public string CorreosCodeError { get; set; }
        public bool Compensated { get; set; }
        public int CompensationType { get; set; }
        public bool Resending { get; set; }
        public bool ReclaimFinished { get; set; }
        public bool FTPOrigin { get; set; }
        public bool ConciliationNew { get; set; }
        public bool ConciliationResponse { get; set; }
        public string ReceivedAck { get; set; }
        public Guid StatusConciliation { get; set; }
        public string DocumentationStatus { get; set; }
        public int IntegrationType { get; set; }
        public bool SlaOutime { get; set; }
        public string LogaltySendingError { get; set; }
        public DateTime ReshipmentDate { get; set; }
        public string CompensationNumbre { get; set; }
        public double CompensationAmount { get; set; }
        public string LiquidationNumber { get; set; }
        public DateTime LiquidationDate { get; set; }
        public DateTime ResolutionDate { get; set; }
        public int NumberDeliveryAttempts { get; set; }
        public Guid Presupuesto { get; set; }
        public Guid InvoiceHeader { get; set; }
        public int StatusOrder { get; set; }
        public int InvoiceStatus { get; set; }
        public bool RquestedPEE { get; set; }
        public bool RquestedCCE { get; set; }
        public bool ResolutionCorreos { get; set; }
        public string DocumentSFTP { get; set; }
        public string LogaltyRejectionOption { get; set; }
        public string Locale { get; set; }
        public Guid RelatedNotification { get; set; }
        public DateTime pEEReceptionDate { get; set; }
        public Guid ProviderZone { get; set; }
        public bool ConciliationSendProvider { get; set; }

    }

}
