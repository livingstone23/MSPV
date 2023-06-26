namespace PVM.Service.Notifications.Model
{
    public class Base_Subscriptions
    {
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public string Name { get; set; }

        public DateTime Date {get;set;}
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public string PGestBaseObjectType { get; set; }
        public string URLLogo { get; set; }
        public Guid OidUNICA { get; set; }
}
}
