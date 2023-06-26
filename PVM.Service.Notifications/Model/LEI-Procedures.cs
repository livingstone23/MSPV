namespace PVM.Service.Notifications.Model
{
    public class LEI_Procedures
    {
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public string PGestBaseObjectType { get; set; }
        public Guid Subscription { get; set; }
        public string Code { get; set; }
        public string CorpmeCode { get; set; }
        public DateTime ProcedureDate { get; set; }
        public int ProcedureType { get; set; }
        public Guid Customer { get; set; }
        public Guid Empowered { get; set; }
        public Guid BaseUser { get; set; }
        public DateTime PayDate { get; set; }
        public Guid ProcedureBatch { get; set; }
        public DateTime ProvimadInvoiceDate { get; set; }
        public DateTime CORPMEInvoiceDate { get; set; }
        public int ProvimadStatus { get; set; }
        public int LEICORPMEStatus { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public DateTime PayDateCustomer { get; set; }
        public bool SendLEI { get; set; }
        public string Observations { get; set; }
    }
}
