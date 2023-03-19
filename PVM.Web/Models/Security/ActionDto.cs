namespace PVM.Web.Models.Security
{
    public class ActionDto
    {

        public Guid Oid { get; set; }
        public String Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }




        //Campos de control
        public bool IsActive { get; set; }
        public int? OptimisticLockField { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int? GCRecord { get; set; }

    }
}
