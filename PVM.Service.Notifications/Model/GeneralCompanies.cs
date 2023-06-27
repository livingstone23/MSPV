using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Service.Notifications.Model
{
    [Table("General-Companies", Schema = "dbo")]
    public class GeneralCompanies
    {
        [Key]
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public Guid Subscription { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string DeliveryCode { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public Guid PostalProvider { get; set; }
        public Guid ElectronicProvider { get; set; }
        public string CorreosCode { get; set; }
        public string CorreosLabelingCode { get; set; }
        public string MassiveSendCorreos { get; set; }
        public string Detailed { get; set; }
        public string LastRemittanceCode { get; set; }
        public string LastBarCode { get; set; }
        public string CorreosContract { get; set; }
        public bool NotificationSendingDelay { get; set; }
        public bool LegalActionPeriod { get; set; }
        public bool NotificationDocumentAlert { get; set; }
        public bool CancelationNotification { get; set; }
        public bool SentResponseToClient { get; set; }
        public string Observations { get; set; }
        public string CodeMasive { get; set; }
        public bool MandatoryNotificationChecking { get; set; }
        public Guid InternationalPostalProvider { get; set; }
        public bool SendFTPWarnings { get; set; }
        public string LastRemittanceCodeOrdinary { get; set; }
        public string LastRemittanceInternational { get; set; }
        public string LatestInternational { get; set; }
        public string InternationalCharterRank { get; set; }
        public string InternationalProductCorreos { get; set; }
        public string IdentificationNumber { get; set; }
        public string RecInvoiceSerie { get; set; }
        public int LastInvoiceNumber { get; set; }
        public int RecLastInvoiceNumber { get; set; }
        public int MethodPayment { get; set; }
        public Guid VATs { get; set; }
        public string StreetOne { get; set; }
        public string StreetTwo { get; set; }
        public string Province { get; set; }
        public string Town { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid CountryISO { get; set; }
        public string InvoiceName { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public Guid InvoiceSeries { get; set; }
        public Guid InvoiceSeriesRe { get; set; }
        public int TypeOfCover { get; set; }
        public bool GenerateSummary { get; set; }
        public string CertificateCompanyName { get; set; }
        public string CorreosCompanyName { get; set; }
        public string CorreosCompanyNif { get; set; }
        public bool GenerateConciliation { get; set; }
        public string LogaltyHelpEmail { get; set; }
        public bool DefaultNomenclatureNotificationFiles { get; set; }
        public bool RenameNotificationFile { get; set; }
        public bool GenerateDocsInResponseXML { get; set; }
        public bool UsedMultichannelNotification { get; set; }
        public string PasswordModel { get; set; }
        public bool OnlyFinishingResponses { get; set; }
        public bool UseWSBurofaxCorreos { get; set; }
        public string UserWSBurofaxCorreos { get; set; }
        public string PassWSBurofaxCorreos { get; set; }
        public string CorreosServiceCode { get; set; }
        public bool GenerateSummaryDocLGT { get; set; }
        public bool duplicadosPEE { get; set; }
        public bool AddLabelPEE { get; set; }
        public int BurofaxProduct { get; set; }
        public Guid PopUpGenerateReportsNotification { get; set; }
        public bool reenvioAuto { get; set; }
        public Guid proveedorReenvio { get; set; }
        public bool PostageProvimad { get; set; }
        public bool ExtractFiles { get; set; }
        public string DayReminder { get; set; }
        public string NameFileSend { get; set; }
        public string NameFileConcilation { get; set; }
        public string NameFileResponseZip { get; set; }
        public bool Multicast { get; set; }
        public bool SimpleSumary { get; set; }
        public bool GlobalSumary { get; set; }
        public bool CalculateCost { get; set; }
        public bool ConciliatonSendProvider { get; set; }
        public bool GenerateProvimadCertificate { get; set; }
        public bool IncorrectDirReview { get; set; }
        public string ClaimCompany { get; set; }
        public string FilesRootPath { get; set; }
        public string FilesPathSegment { get; set; }
    }
}
