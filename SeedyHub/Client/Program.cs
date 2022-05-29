global using SeedyHub.Client.Services.PeopleService;
global using SeedyHub.Client.Services.ItemService;
global using SeedyHub.Shared;
global using System.Net.Http.Json;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SeedyHub.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IItemService, ItemService>();

//builder.Services.AddIgniteUIBlazor();

builder.Services.AddMudServices();

builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
