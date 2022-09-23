using CinemaProject.Handlers.Query;
using CinemaProject.Installelrs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaProject.Web.UI.ServiceExtenstion
{
    public class MediatrInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.InstallMediatRAndHandlers();
        }
    }
}
