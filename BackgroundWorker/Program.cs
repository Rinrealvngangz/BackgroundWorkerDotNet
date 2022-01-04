using Microsoft.Extensions.DependencyInjection;
using BackgroundWorker;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureServices((_, service) =>
{

    service.AddHostedService<BackgroundLogger>();
    service.AddHostedService<BgLoggerWithHostService>();
    service.AddSingleton<IWorker, WorkerBg>();
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/test", () => "Testing");
await app.RunAsync();



  
 