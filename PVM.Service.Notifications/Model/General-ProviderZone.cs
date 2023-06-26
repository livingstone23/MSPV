namespace PVM.Service.Notifications.Model
{
    public class General_ProviderZone
    {
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Guid Provider { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public string PGestBaseObjectType { get; set; }
    }
}
