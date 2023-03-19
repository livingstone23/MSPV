using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using PVM.Web.Models.Security;
using PVM.Web.Services.Authentication;

namespace PVM.Web.Service.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _client;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _authStateProvider;

    public AuthenticationService(HttpClient client, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
    {
        _client = client;
        _authStateProvider = authStateProvider;
        ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
        _localStorage = localStorage;
    }

    public async Task<AuthenticationResponseDTO> Login(AuthenticationDTO userFromAuthentication)
    {
        var content = JsonConvert.SerializeObject(userFromAuthentication);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("api/v1/account/SignIn", bodyContent);
        var contentTemp = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<AuthenticationResponseDTO>(contentTemp);

        if (response.IsSuccessStatusCode)
        {
            await _localStorage.SetItemAsync(SD.Local_Token, result.Token);
            await _localStorage.SetItemAsync(SD.Local_UserDetails, result.userDTO);
            ((AuthStateProvider)_authStateProvider).NotifyUserLoggedIn(result.Token);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            return new AuthenticationResponseDTO { IsAuthSuccessful = true };
        }
        else
        {
            return result;
        }
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync(SD.Local_Token);
        await _localStorage.RemoveItemAsync(SD.Local_UserDetails);
        _client.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<RegisterationResponseDTO> RegisterUser(UserRequestDTO userForRegisteration)
    {
        var content = JsonConvert.SerializeObject(userForRegisteration);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("api/v1/account/SignUp", bodyContent);
        var contentTemp = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<RegisterationResponseDTO>(contentTemp);

        if (response.IsSuccessStatusCode)
        {

            return new RegisterationResponseDTO { IsRegisterationSuccessful = true };
        }
        else
        {
            return result;
        }
    }
}