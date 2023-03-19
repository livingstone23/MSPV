using PVM.Web.Models;
using PVM.Web.Models.Notifications;

namespace PVM.Web.Services.BillService;

public interface IBillService
{

    Task<IEnumerable<BillDto>> GetBills();

    Task<BillDtoPagination> GetByPaginationDto(int currentPage, int pagesize);

    Task<BillDto> GetByNumFact(string numFact);






}