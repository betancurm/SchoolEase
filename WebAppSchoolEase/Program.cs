using Blazored.Menu;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAppSchoolEase;
using WebAppSchoolEase.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var apiSchoolEase = builder.Configuration.GetValue<string>("apiSchoolEase");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiSchoolEase) });
builder.Services.AddScoped<IPeriodoAcademicoService, PeriodoAcademicoService>();

await builder.Build().RunAsync();
