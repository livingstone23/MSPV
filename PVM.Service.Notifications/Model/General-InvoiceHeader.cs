namespace PVM.Service.Notifications.Model
{
    public class General_InvoiceHeader
    {
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public Guid Subscription { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public double ProviderPrice { get; set; }
        public string Serie { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid OfficeUser { get; set; }
        public Guid ClaveFactura { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public double VAT { get; set; }
        public double TotalVAT { get; set; }
        public double TotalInvoice { get; set; }
        public double Discount { get; set; }
        public int InvoiceStatus { get; set; }
        public int MethodPayment { get; set; }
        public string Observations { get; set; }
        public double Supplied { get; set; }
        public string SuppliedInvoiceNumber { get; set; }
        public Guid Company { get; set; }
        public Guid AccountNumber { get; set; }
        public double TaxBase { get; set; }
        public double Tax { get; set; }
        public DateTime ExpirationInvoiceDate { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public DateTime PayDate { get; set; }
        public Guid InvoiceSeries { get; set; }
        public bool InvoiceCredit { get; set; }
        public bool Rectified { get; set; }
        public string RectifiedInvoiceNumber { get; set; }
        public string DestinyOffice { get; set; }
        public string CIF { get; set; }
        public string CompanyName { get; set; }
        public string Direction { get; set; }
        public string Town { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public Guid Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string RectificationCriteria { get; set; }
        public string MotiveOfRectification { get; set; }
        public int CodeRectified { get; set; }
        public string CodeCriteria { get; set; }
        public DateTime RectificationInvoiceDate { get; set; }
    }
}
