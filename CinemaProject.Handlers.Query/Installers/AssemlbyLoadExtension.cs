using System.Reflection;

namespace CinemaProject.Handlers.Query.Installers
{
    public static class AssemlbyLoadExtension
    {
        public static void LoadQueryHandlersAssembly(this Assembly[] assemblies)
        {
            var currentAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName.Contains("CinemaProject.Handlers.Query"));

            assemblies.ToList().Add(currentAssembly);
            assemblies.ToArray();
        }
    }
}
