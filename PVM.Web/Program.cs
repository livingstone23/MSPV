using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PVM.Web;
using MudBlazor.Services;
using PVM.Web.Services.ActionService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PVM.Web.Services.Authentication;
using PVM.Web.Service.Authentication;
using PVM.Web.Services.BillService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

//Original
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//SD.ApiSecurity      = builder.Configuration.GetSection("ServiceUrls:APISecurity");
//SD.ApiNotifications = builder.Configuration["ServiceUrls:APINotification"];

//var ApiRoute = builder.Configuration.GetSection("");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7010/") });






//builder.Services.AddHttpClient("ApiSecurity", httpClient => httpClient.BaseAddress = new("https://localhost:7035/"));
//builder.Services.AddHttpClient("APINotificacion", httpClient => httpClient.BaseAddress = new("http://localhost:7170"));


//builder.Services.AddHttpClient<IActionService, ActionService>();


//SD.SecurityApiBase = builder.Configuration["ServiceUrls:SecurityApi"];

//Habilitamos el LocalStorage
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();



//Registro de servicios
builder.Services.AddScoped<IActionService, ActionService>();
builder.Services.AddScoped<IBillService, BillService>();







await builder.Build().RunAsync();
