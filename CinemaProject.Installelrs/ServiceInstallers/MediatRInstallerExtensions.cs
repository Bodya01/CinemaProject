using CinemaProject.Handlers.Command.Installers;
using CinemaProject.Handlers.Query.Installers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaProject.Installelrs.ServiceInstallers
{
    public static class MediatRInstallerExtensions
    {
        public static void InstallMediatRAndHandlers(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().OrderBy(x => x.FullName).ToArray();

            assemblies.LoadQueryHandlersAssembly();
            assemblies.LoadCommandHandlersAssembly();

            services.AddMediatR(assemblies);
        }
    }
}
