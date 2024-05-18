using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.Extensions.DependencyInjection;
using Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Migrations.Design;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Design
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
