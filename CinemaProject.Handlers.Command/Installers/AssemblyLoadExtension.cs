using System.Reflection;

namespace CinemaProject.Handlers.Command.Installers
{
    public static class AssemblyLoadExtension
    {
        public static void LoadCommandHandlersAssembly(this Assembly[] assemblies)
        {
            var currentAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName.Contains("CinemaProject.Handlers.Command"));

            assemblies.ToList().Add(currentAssembly);
            assemblies.ToArray();
        }
    }
}
