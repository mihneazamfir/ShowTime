using ShowTime.Components;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using ShowTime.Context;
using Microsoft.EntityFrameworkCore;
using ShowTime.Repositories.Interfaces;
using ShowTime.Repositories.Implementation;
using AuthApp.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using ShowTime.Components.Account;
using ShowTime.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ShowTimeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

builder.Services
    .AddBlazorise( options =>
    {
        options.Immediate = true;
    } )
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

builder.Services.AddScoped<IRepositoryBand, RepositoryBand>();
builder.Services.AddScoped<IRepositoryBooking, RepositoryBooking>();
builder.Services.AddScoped<IRepositoryFestival, RepositoryFestival>();
builder.Services.AddScoped<IRepositoryFestivalBand, RepositoryFestivalBand>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ShowTimeContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddAuthorizationCore();
builder.Services.AddAntiforgery();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();
app.Run();