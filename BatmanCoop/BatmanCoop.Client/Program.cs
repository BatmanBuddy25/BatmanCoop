using BatmanCoop.Client.Services.LendService;
using BatmanCoop.Client.Services.ManpowerService;
using BatmanCoop.Client.Services.TransactionService;
using BatmanCoopShared.Interfaces.LendInterface;
using BatmanCoopShared.Interfaces.ManpowerInterface;
using BatmanCoopShared.Interfaces.TransactionInterface;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddDataGridEntityFrameworkAdapter();
builder.Services.AddFluentUIComponents();
builder.Services.AddOptions();



builder.Services.AddScoped<IDialogService, DialogService>();
builder.Services.AddScoped<IToastService, ToastService>();
builder.Services.AddScoped<IMemberInt, MemberService>();
builder.Services.AddScoped<IAttachmentInt, AttachmentService>();
builder.Services.AddScoped<IBuyerInt, BuyerService>();
builder.Services.AddScoped<IBuyerDetailsInt, BuyerDetailsService>();
builder.Services.AddScoped<ITransactionInt, TransactionLogsService>();

await builder.Build().RunAsync();
