using BatmanCoop.Client.Services.ManpowerService;
using BatmanCoopShared.Interfaces.ManpowerInterface;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddFluentUIComponents();
builder.Services.AddOptions();
builder.Services.AddDataGridEntityFrameworkAdapter();


builder.Services.AddScoped<IDialogService, DialogService>();
builder.Services.AddScoped<IToastService, ToastService>();
builder.Services.AddScoped<IMemberInt, MemberService>();

await builder.Build().RunAsync();
