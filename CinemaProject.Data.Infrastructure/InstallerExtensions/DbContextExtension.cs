using CinemaProject.Data.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaProject.Data.Infrastructure.InstallerExtensions
{
    public static class DbContextExtension
    {
        public static void InstallDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CinemaConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly(typeof(DbContextExtension).Assembly.GetName().FullName)));
        }
    }
}
