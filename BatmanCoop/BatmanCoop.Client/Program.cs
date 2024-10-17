using BatmanCoop.Client.Helper;
using BatmanCoop.Client.Services.AccountService;
using BatmanCoop.Client.Services.LendService;
using BatmanCoop.Client.Services.ManpowerService;
using BatmanCoop.Client.Services.TransactionService;
using BatmanCoopShared.Interfaces.AccountInterface;
using BatmanCoopShared.Interfaces.LendInterface;
using BatmanCoopShared.Interfaces.ManpowerInterface;
using BatmanCoopShared.Interfaces.TransactionInterface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddDataGridEntityFrameworkAdapter();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddFluentUIComponents();


builder.Services.AddScoped<IDialogService, DialogService>();
builder.Services.AddScoped<IToastService, ToastService>();
builder.Services.AddScoped<IMemberInt, MemberService>();
builder.Services.AddScoped<IAttachmentInt, AttachmentService>();
builder.Services.AddScoped<IBuyerInt, BuyerService>();
builder.Services.AddScoped<IBuyerDetailsInt, BuyerDetailsService>();
builder.Services.AddScoped<ITransactionInt, TransactionLogsService>();
builder.Services.AddScoped<IUserAccountInt, UserAccountService>();


builder.Services.AddTransient<TokenHelpers>();
builder.Services.AddTransient<TokenService>();

await builder.Build().RunAsync();
