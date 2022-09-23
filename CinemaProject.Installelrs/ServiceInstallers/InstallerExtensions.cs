using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaProject.Installers.ServiceInstallers
{
    public static class InstallerExtensions
    {
        public static void InstallAllServices(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(InstallerExtensions).Assembly.ExportedTypes
                .Where(x => typeof(IServiceInstaller).IsAssignableFrom(x)
                            && !x.IsInterface
                            && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>()
                .ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}

