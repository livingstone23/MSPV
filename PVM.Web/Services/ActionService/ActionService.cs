using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using PVM.SharedLibrary.Models;
using PVM.Web.Models.Security;
using PVM.Web.Services.Authentication;

namespace PVM.Web.Services.ActionService
{
    public class ActionService : IActionService
    {
        //Llamado a la api Gateway
        private const string BaseUrl = "https://localhost:7170/";
        private readonly HttpClient _httpClient;
        //private readonly AuthenticationStateProvider _authStateProvider;

        //Evento que permite indicar cuando se ha realizado un cambio
        public event Action ActionsChanged;

        public List<ActionDto> ListActions { get; set; }

        public string Message { get; set; } = "Loading products...";

        public ActionService(HttpClient httpClient)//, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new(SD.ApiSecurity);
        }

        public string GetBaseUrl()
        {
            return _httpClient.BaseAddress.ToString();
        }

        public async Task GetActions()
        {

            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<ActionDto>>>("api/v1/actions");
            if (result != null && result.Data != null)
            {
                ListActions = result.Data;
            }

            if(ListActions.Count == 0)
                Message = "No products found";

            ActionsChanged.Invoke();
        }

        public async Task<ServiceResponse<ActionDto>> GetActionById(Guid actiontId)
        {

            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<ActionDto>>($"{BaseUrl}api/v1/actions/{actiontId}");
            return result;
        }

        public async Task<ActionDto> UpdateAction(ActionDto action)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/product", action);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ActionDto>>();
            return content.Data;
        }

        public async Task<ActionDto> CreateAction(ActionDto action)
        {

            var result = await _httpClient.PostAsJsonAsync("api/v1/actions", action);
            var newActiont = (await result.Content.ReadFromJsonAsync<ServiceResponse<ActionDto>>()).Data;
            return newActiont;

        }



        public async Task DeleteAction(ActionDto action)
        {
            var result = await _httpClient.DeleteAsync($"api/v1/actions/{action.Oid}");
        }
    }
}
