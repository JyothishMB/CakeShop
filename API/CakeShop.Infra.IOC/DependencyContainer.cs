using CakeShop.Application.Interfaces;
using CakeShop.Application.Services;
using CakeShop.Domain.Interfaces;
using CakeShop.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CakeShop.Infra.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application layer
            services.AddScoped<ICakeService, CakeService>();

            //Infra.Data layer
            services.AddScoped<ICakeRepository, CakeRepository>();
        }
    }
}