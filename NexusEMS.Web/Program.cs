using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NexusEMS.Web.Services;
using NexusEMS.Web.Test;
using Syncfusion.Blazor;

namespace NexusEMS.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<TestDataService>();
            builder.Services.AddSingleton<AuthService>();

            builder.Services.AddSyncfusionBlazor();

            await builder.Build().RunAsync();
        }
    }
}
