namespace PVM.Service.Notifications.Model
{
    public class NotiConsignment
    {
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public Guid Subscription { get; set; }
        public string Code { get; set; }
        public DateTime CreationDate { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public bool Sent { get; set; }
        public bool GenerateCover { get; set; }
        public Guid ProvimadStatus { get; set; }
        public int TotalD1 { get; set; }
        public int TotalD2 { get; set; }
        public int TotalI1 { get; set; }
        public int TotalI2 { get; set; }
        public string Observations { get; set; }
        public string TypeLetter { get; set; }
        public string Zone { get; set; }
        public bool PrintDoubleLeaf { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public Guid Company { get; set; }
        public Guid ConfigurationPrinter { get; set; }
        public Guid Printer { get; set; }
    }
}
