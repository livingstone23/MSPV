using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PVM.Service.Bills.Interface;
using PVM.Service.Bills.Model.Dto;
using PVM.SharedLibrary.Models;


namespace PVM.Service.Notifications.Controllers.v1
{
    [Route("api/v1/bills")]
    [ApiController]
    [Authorize]
    public class BillsController : ControllerBase
    {

        private readonly IBillRepository _billRepository;

        public BillsController(IBillRepository billRepository)
        {

            _billRepository = billRepository;

        }



        [HttpGet]
        public async Task<ActionResult<List<BillDto>>> Get()
        {

            var bills = await _billRepository.GetAll();
            return Ok(bills);

        }



        [HttpGet("GetByPagination/{currentPageNumber}/{pageSize}")]
        public async Task<PagingResponseModel<List<BillDto>>> GetByPagination(int currentPageNumber, int pageSize)
        {
            return await _billRepository.GetBillsByPagination(currentPageNumber, pageSize);
        }



        //[HttpGet]
        //[Route("{id}", Name = "GetById")]
        //public async Task<ActionResult<ServiceResponse<BillDto>>> GetById(Guid id)
        //{

        //    var result = await _billRepository.GetById(id);
        //    return Ok(result);

        //}

        [HttpGet]
        [Route("{NumFactura}", Name = "GetByNumFactura")]
        public async Task<ActionResult<ServiceResponse<BillDto>>> GetByNumFactura(string NumFactura)
        {

            var result = await _billRepository.GetByNumFactura(NumFactura);
            return Ok(result);

        }



    }


}
