using Microsoft.EntityFrameworkCore;
using congestion_tax_calculator.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaxDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaxDbContext")));

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CongestionTaxCalculator>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
