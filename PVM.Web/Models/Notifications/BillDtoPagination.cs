namespace PVM.Web.Models.Notifications
{
    public class BillDtoPagination
    {

        public int TotalRecords { get; set; }
        public IEnumerable<BillDto> Data { get; set; }

    }
}
