namespace CinemaProject.Installelrs
{
    public static class AssemblyNamesConstants
    {
        public const string BaseName = "CinemaProject";

        public const string DataAssemblies = $"{BaseName}.Data";

        public const string MigrationAssembly = $"{BaseName}.Data.Infrastructure";

        public const string MediatRCommandHandlersAssembly = $"{BaseName}.CommandHandlers";

        public const string MediatRQueryHandlersAssembly = $"{BaseName}.QueryHandlers";

        public const string WebUIConnectionString = "CinemaConnection";
    };
}
