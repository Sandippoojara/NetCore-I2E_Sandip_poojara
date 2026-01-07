using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetCore_I2E_Sandip_poojara.Data;
using NetCore_I2E_Sandip_poojara.Services.Interfaces;
using NetCore_I2E_Sandip_poojara.Services.Implementations;
using NetCore_I2E_Sandip_poojara.Repositories.Interfaces;
using NetCore_I2E_Sandip_poojara.Repositories.Implementations;
using NetCore_I2E_Sandip_poojara.Middleware;
using EventManagementSystem.Filters;
using EventManagementSystem.Data;
using EventManagementSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NetCore_I2E_Sandip_poojara.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<ValidateModelFilter>();

// Identity with Roles
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages(); // Required for Identity

var app = builder.Build();

// Middleware
app.UseRequestLogging();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Routes
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Events}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Identity Pages

// Seed Admin & Roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await IdentitySeed.SeedRolesAndAdminAsync(services);
}

app.Run();
