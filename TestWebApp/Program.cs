using TestWebAppLib;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Data;
using TestWebApp.Areas.Identity.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDBContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDBContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql(connectionString, c => c.MigrationsAssembly("TestWebApp")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDBContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<Class1>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

Console.WriteLine($"Running in environment: {builder.Environment.EnvironmentName}");

app.Run();
