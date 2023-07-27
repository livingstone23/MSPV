using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Web;
using PVM.Websftp;

//namespace PVM.Websftp
//{
//    public class Program
//    {
//        public static async Task Main(string[] args)
//        {
//            var builder = WebAssemblyHostBuilder.CreateDefault(args);
//            builder.RootComponents.Add<App>("#app");

//            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//            builder.Services.AddMudServices();

//            await builder.Build().RunAsync();
//        }
//    }
//}


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7010/") });

await builder.Build().RunAsync();