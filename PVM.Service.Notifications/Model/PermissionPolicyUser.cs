namespace PVM.Service.Notifications.Model
{
    public class PermissionPolicyUser
    {
        public Guid Oid { get; set; }
        public string StoredPassword { get; set; }
        public bool ChangePasswordOnFirstLogon { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public int OptimisticLockField { get; set; }
        public int GCRecord { get; set; }
        public int ObjectType { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
        public string secondName { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Guid CurrentSubscription { get; set; }
        public bool WelcomeMailSent { get; set; }
        public string APIKey { get; set; }
        public string ContactAddressLine { get; set; }
        public string ContactAddressNumber { get; set; }
        public string ContactAddressNumberWithinBuilding { get; set; }
        public string ContactAddressCity { get; set; }
        public string ContactAddressRegion { get; set; }
        public Guid ContactAddressCountryCode { get; set; }
        public string ContactAddressPostalCode { get; set; }
        public Guid Subscription { get; set; }
        public string Empresa { get; set; }
        public string Oficina { get; set; }
        public bool UserEfactura { get; set; }
        public string Nif { get; set; }
    }
}
