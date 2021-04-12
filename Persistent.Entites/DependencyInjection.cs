using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Interfaces.IRepositories;
using Products.Application.Interfaces.IUnitOfWork;
using Products.Persistence.Entites.Broker;
using Products.Persistence.Entites.Repositories;
using Products.Persistence.Entites.UOW;

namespace Persistence.Entites
{
    public static class DependencyInjection
    {
        public static void AddPersistenceEntites(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped<IProductRepository, ProductRepository>();


            var rabbitConfig = configuration.GetSection("rabbit");
            services.Configure<RabbitOptions>(rabbitConfig);

            services.AddHostedService<ConsumerRabbitManager>();



            
        }
    }
}
