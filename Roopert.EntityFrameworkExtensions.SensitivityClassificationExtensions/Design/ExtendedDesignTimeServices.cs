using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.Extensions.DependencyInjection;
using Roopert.EfCore.SensitivityClassifications.Migrations.Design;

namespace Roopert.EfCore.SensitivityClassifications.Design
{
    // ReSharper disable once UnusedMember.Global
    // Referenced by Magic String
    public class ExtendedDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMigrationsCodeGenerator, ExtendedCSharpMigrationsGenerator>();
            serviceCollection.AddSingleton<ICSharpMigrationOperationGenerator, ExtendedCSharpMigrationOperationGenerator>();
            serviceCollection.AddSingleton<ICSharpHelper, ExtendedCSharpHelper>();
        }
    }
}
