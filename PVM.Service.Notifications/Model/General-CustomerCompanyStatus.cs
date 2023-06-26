namespace PVM.Service.Notifications.Model
{
    public class General_CustomerCompanyStatus
    {
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public Guid Subscription { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid Company { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public string SubStatus { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string PGestSubscriptionSequence { get; set; }
        public Guid Type { get; set; }
    }
}
