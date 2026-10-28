using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using CampusCuisine.Client;
using CampusCuisine.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["ApiBaseAddress"]!)
});
builder.Services.AddScoped<RecipeService>();
builder.Services.AddLocalization();

var host = builder.Build();

// The language chosen in the LanguageSelector, stored in the browser
var js = host.Services.GetRequiredService<IJSRuntime>();
var language = await js.InvokeAsync<string?>("localStorage.getItem", "culture");
var culture = new CultureInfo(language ?? "en");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
