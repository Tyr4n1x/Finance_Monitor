using Finance_Monitor.Components;
using Finance_Monitor.Data;
using Finance_Monitor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Finance_Monitor.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using Finance_Monitor.Services;

var builder = WebApplication.CreateBuilder(args);

// Configures the DbContextFactory for the ApplicationUserContext with a SQL Server connection string from the app settings.
builder.Services.AddDbContextFactory<ApplicationUserContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection") ??
        throw new InvalidOperationException(
            "Connection string 'DefaultConnection' not found.")));


// Configures the DbContextFactory for the ExpenseContext with a SQL Server connection string from the app settings.
builder.Services.AddDbContextFactory<ExpenseContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection") ??
        throw new InvalidOperationException(
            "Connection string 'DefaultConnection' not found.")));


// Configures the DbContextFactory for the IncomeContext with a SQL Server connection string from the app settings.
builder.Services.AddDbContextFactory<IncomeContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection") ??
        throw new InvalidOperationException(
            "Connection string 'DefaultConnection' not found.")));


// Enables database-related exception pages during development to assist with troubleshooting Entity Framework Core issues
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Adds the QuickGrid Entity Framework adapter to the service collection
builder.Services.AddQuickGridEntityFrameworkAdapter();

// Configures authentication schemes and identity cookies for user sign-in.
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
}).AddIdentityCookies();

// Configures Identity with required account confirmation, EF Core stores, sign-in manager, and token providers.
builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationUserContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

// Configures Identity options to require unique email addresses for user accounts.
builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.RequireUniqueEmail = true;
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Radzen services to the container.
builder.Services.AddRadzenComponents();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IdentityUserAccessor>();

builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

// Add services for data processing to the container.
builder.Services.AddScoped<IDataService, DataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity Razor components (/Account)
app.MapAdditionalIdentityEndpoints();;

app.Run();
