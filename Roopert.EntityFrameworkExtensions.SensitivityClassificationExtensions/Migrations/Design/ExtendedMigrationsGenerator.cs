using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Migrations.Operations;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Migrations.Design
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
