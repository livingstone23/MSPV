using PVM.Web.Models;
using PVM.Web.Models.Notifications;
using System.Net.Http;
using System.Net.Http.Json;

namespace PVM.Web.Services.BillService
{
    public class BillService: IBillService
    {
        //Llamado a la api Gateway
        private const string BaseUrl = "https://localhost:7170/";
        private readonly HttpClient _httpClient;

        public BillService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public string GetBaseUrl()
        {
            return _httpClient.BaseAddress.ToString();
        }

        public async Task<IEnumerable<BillDto>> GetBills()
        {

            var result = await _httpClient.GetFromJsonAsync<IEnumerable<BillDto>>($"{BaseUrl}api/v1/bills");
            return result;
        }

        
        public async Task<BillDtoPagination> GetByPaginationDto(int page, int pagesize)
        {
            var answer = await _httpClient.GetFromJsonAsync<BillDtoPagination>($"{BaseUrl}api/v1/bills/getbypagination/{page}/{pagesize}");
            return answer;
        }


        public async Task<BillDto> GetByNumFact(string numFact)
        {
            return await _httpClient.GetFromJsonAsync<BillDto>($"{BaseUrl}api/pospay/GetById/{numFact}");
        }




        

    }
}
