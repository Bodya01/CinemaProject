using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CinemaProject.Web.UI.ServiceExtenstion
{
    public class MediatrInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(assembly => assembly.FullName.Contains("CinemaProject"))
                .ToArray();

            services.AddMediatR(assemblies);
        }
    }
}
