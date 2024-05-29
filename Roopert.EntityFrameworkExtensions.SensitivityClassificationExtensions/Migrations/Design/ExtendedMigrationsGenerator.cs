using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Roopert.EfCore.SensitivityClassifications.Migrations.Operations;

namespace Roopert.EfCore.SensitivityClassifications.Migrations.Design
{
    public class ExtendedCSharpMigrationsGenerator : CSharpMigrationsGenerator
    {
        public ExtendedCSharpMigrationsGenerator(MigrationsCodeGeneratorDependencies dependencies, CSharpMigrationsGeneratorDependencies csharpDependencies)
            : base(dependencies, csharpDependencies)
        {
        }

        protected override IEnumerable<string> GetNamespaces(IEnumerable<MigrationOperation> operations)
            => base.GetNamespaces(operations).Concat(new List<string>
            {
                typeof(MigrationBuilderExtensions).Namespace
            });
    }
}
