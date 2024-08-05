using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PriceLists.Controllers;
using PriceLists.Data;
using PriceLists.Data.Repositories;
using PriceLists.Services;
using Serilog;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.WriteTo.Console();
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});
builder.Services.AddSignalR();
// Add services to the container.
builder.Services.AddControllersWithViews();
string connectionString = builder.Configuration.GetSection("ConnectionString").Value;
builder.Services.AddDbContext<ApplicationContext>(options=> options.UseSqlServer(connectionString));
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<PriceListServices>();
builder.Services.AddScoped<ProductServices>();
builder.Services.AddScoped<ColumnServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors(policy => policy.WithOrigins("https://localhost:7027").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
app.UseRouting();

app.UseAuthorization();
app.MapHub<PriceListHub>("/PriceListhub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PriceList}/{action=Index}/{id?}");

app.Run();
