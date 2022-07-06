using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using AntDesign.ProLayout;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.StartKit.LIB.MVCS;

namespace fmp_startkit_web_blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:19000/", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            });
            

            Logger logger = new ConsoleLogger();
            Framework framework = new Framework();
            framework.setConfig(new Config());
            framework.setLogger(logger);
            framework.Initialize();

            framework.Setup();
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => framework);
            builder.Services.AddScoped(sp => logger);
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAntDesign();
            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));

            var entry = new Entry();
            var options = new Options();
            options.setChannel(channel);
            framework.PushUserData("XTC.FMP.MOD.StartKit.LIB.MVCS.Entry", entry);
            entry.Inject(framework, options);
            entry.DynamicRegister(logger);
            await builder.Build().RunAsync();

            framework.Dismantle();
            entry.StaticCancel(logger);
            framework.Release();
        }
    }
}