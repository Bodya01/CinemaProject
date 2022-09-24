using CinemaProject.Handlers.Command.Installers;
using CinemaProject.Handlers.Query.Installers;
using CinemaProject.Installers.ServiceInstallers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaProject.Installelrs.ServiceInstallers
{
    public class MediatRInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().OrderBy(x => x.FullName).ToArray();

            assemblies.LoadQueryHandlersAssembly();
            assemblies.LoadCommandHandlersAssembly();

            services.AddMediatR(assemblies);
        }
    }
}
