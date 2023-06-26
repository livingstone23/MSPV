namespace PVM.Service.Notifications.Model
{
    public class General_ProvimadStatus
    {
        public Guid Oid { get; set; }
        public DateTime LastChange { get; set; }
        public Guid LastUser { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public string PGestBaseObjectType { get; set; }
        public bool IsClosedState { get; set; }
        public bool AllowUpdateProviderStatus { get; set; }
    }
}
