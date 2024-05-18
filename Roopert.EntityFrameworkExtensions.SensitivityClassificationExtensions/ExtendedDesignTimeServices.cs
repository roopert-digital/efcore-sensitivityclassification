using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions
{
    public class ExtendedDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            Debugger.Launch();
            serviceCollection.AddSingleton<IMigrationsCodeGenerator, ExtendedCSharpMigrationsGenerator>();
            serviceCollection.AddSingleton<ICSharpMigrationOperationGenerator, ExtendedCSharpMigrationOperationGenerator>();
            serviceCollection.AddSingleton<ICSharpHelper, ExtendedCSharpHelper>();
        }
    }
}
