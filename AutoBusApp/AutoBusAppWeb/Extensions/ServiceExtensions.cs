using AutoBusAppBLL.Services.Implementations;
using AutoBusAppBLL.Services.Interfaces;
using AutoBusAppDAL.Repositories.Implementations;
using AutoBusAppDAL.Repositories.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace AutoBusAppWeb.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("AutoBusApp");

            services.AddDbContext<UrlDbContext>(
            options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUrlRepository, EFUrlRepository>();

            services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            services.AddScoped<IUrlModelService, UrlModelService>();    
        }
    }
}
