using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Entites;
using Products.Application.Interfaces.IServiceResponse;
using Products.Application.Interfaces.IServices;
using Products.Domain.Models.Services;
using Products.Persistence.Services.ServiceResponse;
using Products.Persistence.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Persistence.Services
{
    public static class DependencyInjection
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddPersistenceEntites(configuration);

            services.AddSingleton<IResponse, Response>();

            services.AddScoped<IProductService, ProductService>();


            services.AddAutoMapper(typeof(DependencyInjection));
        }
    }
}
