//*************************************************************************************
//   !!! Generated by the fmp-cli.  DO NOT EDIT!
//*************************************************************************************

using fmp_startkit_web_blazor;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.StartKit.LIB.MVCS;

var channel = GrpcChannel.ForAddress("https://localhost:19000/", new GrpcChannelOptions
{
    HttpHandler = new GrpcWebHandler(new HttpClientHandler())
});

var framework = new Framework();
framework.setConfig(new Config());
framework.setLogger(new Logger());
framework.Initialize();

framework.Setup();

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => framework);

var entry = new Entry();
var options = new Options();
options.setChannel(channel);
framework.PushUserData("XTC.FMP.MOD.StartKit.LIB.MVCS.Entry", entry);
framework.PushUserData("XTC.FMP.MOD.StartKit.LIB.MVCS.Options", options);
entry.Inject(framework, options);
entry.DynamicRegister();

await builder.Build().RunAsync();




framework.Dismantle();
entry.StaticCancel();
framework.Release();
