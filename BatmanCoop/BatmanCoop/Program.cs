using BatmanCoop.Client.Helper;
using BatmanCoop.Components;
using BatmanCoop.DatabaseContext;
using BatmanCoop.Repository.AccountRepository;
using BatmanCoop.Repository.LendRepository;
using BatmanCoop.Repository.ManpowerRepository;
using BatmanCoop.Repository.TransactionRepository;
using BatmanCoopShared.Interfaces.AccountInterface;
using BatmanCoopShared.Interfaces.LendInterface;
using BatmanCoopShared.Interfaces.ManpowerInterface;
using BatmanCoopShared.Interfaces.TransactionInterface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseAddress").Value!)
});

builder.Services.AddDbContext<DataBaseConfiguration>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthorization();
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.Cookie.Name = "batman_token";
        option.LoginPath = "/";
        //option.Cookie.MaxAge = TimeSpan.FromMinutes(10);
        option.AccessDeniedPath = "/access-error";
    });


builder.Services.AddFluentUIComponents();
builder.Services.AddDataGridEntityFrameworkAdapter();

builder.Services.AddServerSideBlazor().AddCircuitOptions(option => { option.DetailedErrors = true; });

builder.Services.AddControllers();


builder.Services.AddScoped<IDialogService, DialogService>();
builder.Services.AddScoped<IToastService, ToastService>();

//Manpower
builder.Services.AddScoped<IMemberInt, MemberRepo>();
builder.Services.AddScoped<IAttachmentInt, AttachmentRepo>();

builder.Services.AddScoped<IBuyerInt, BuyerRepo>();
builder.Services.AddScoped<IBuyerDetailsInt, BuyerDetailsRepo>();
builder.Services.AddScoped<ITransactionInt, TransactionLogsRepo>();

builder.Services.AddScoped<IUserAccountInt, UserAccountRepo>();

builder.Services.AddTransient<TokenHelpers>();
builder.Services.AddTransient<TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllers();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BatmanCoop.Client._Imports).Assembly);

app.Run();
