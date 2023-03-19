using PVM.Service.Bills.Model.Dto;
using PVM.SharedLibrary.Models;

namespace PVM.Service.Bills.Interface;

public interface IBillRepository
{

    Task<IEnumerable<BillDto>> GetAll();

    Task<PagingResponseModel<List<BillDto>>> GetBillsByPagination(int currentPageNumber, int pageSize);

    //Task<BillDto> GetById(Guid id);
    Task<BillDto> GetByNumFactura(string numFactura);

}