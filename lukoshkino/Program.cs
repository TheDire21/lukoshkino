using lukoshkino.Components;
using lukoshkino.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    }).AddIdentityCookies();

builder.Services.AddDbContext<ApplicationContext>
    (options => options.UseSqlite("Data Source=lukoshkino.db"));


builder.Services.AddDbContextFactory<ApplicationContext>(
    opt => opt.UseSqlite("Data Source=lukoshkino.db"), ServiceLifetime.Scoped);

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
}
    )
    .AddRoles<ApplicationRole>() // +++ Add roles
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddServerSideBlazor();
builder.Services.AddRazorPages();

builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Logging.AddConsole();

var app = builder.Build();


await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>();
await DatabaseUtility.EnsureDbCreatedAndSeedAsync(options);

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// +++Map the SignalR hub and define its URL (endpoint)
app.MapBlazorHub(options =>
{
    options.CloseOnAuthenticationExpiration = true;
}).WithOrder(-1);

// Add additional endpoints required by the Identity /Account Razor components.



app.Run();


