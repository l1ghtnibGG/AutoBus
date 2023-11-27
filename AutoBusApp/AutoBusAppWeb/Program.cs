using AutoBusAppBLL.AutoMapperHelper;
using AutoBusAppWeb.Extensions;
using AutoBusAppWeb.Models.Data;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.ConfigureSqlServer(config);

builder.Services.AddControllersWithViews();

builder.Services.AddServices();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

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

SeedData.EnsureData(app);

app.Run();
