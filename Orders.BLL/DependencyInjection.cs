using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.DAL.UnitOfWork.Interfaces;

namespace Orders.BLL
{
    public static class DependencyInjection
    {
        public static void AddBLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))); 

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
