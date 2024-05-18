using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Migrations.Operations;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Migrations
{
    public class ExtendedMigrationsModelDiffer : MigrationsModelDiffer
    {
        public ExtendedMigrationsModelDiffer(IRelationalTypeMappingSource typeMappingSource,
            IMigrationsAnnotationProvider migrationsAnnotationProvider,
            IRowIdentityMapFactory rowIdentityMapFactory,
            CommandBatchPreparerDependencies commandBatchPreparerDependencies)
            : base(typeMappingSource, migrationsAnnotationProvider, rowIdentityMapFactory, commandBatchPreparerDependencies)
        {
        }

        public override IReadOnlyList<MigrationOperation> GetDifferences(IRelationalModel? source, IRelationalModel? target)
        {
            return base.GetDifferences(source, target);
        }

        protected override IEnumerable<MigrationOperation> Diff(IColumn source, IColumn target, DiffContext diffContext)
        {
            var baseOperations = base.Diff(source, target, diffContext);

            var operations = DiffSensitivityAnnotations(source, target);

            return baseOperations.Concat(operations);
        }

        private static IEnumerable<MigrationOperation> DiffSensitivityAnnotations(IColumn source, IColumn target)
        {
            var sourceAnn =
                source.PropertyMappings.First().Property.FindAnnotation("SensitivityClassification");

            var targetAnn =
                target.PropertyMappings.First().Property.FindAnnotation("SensitivityClassification");

            if (sourceAnn == null && targetAnn == null) yield break;

            if (sourceAnn == null && targetAnn != null)
            {
                // added
                var sc = targetAnn.Value as SensitivityClassificationItem ?? throw new InvalidOperationException();
                yield return new AddSensitivityClassificationOperation(target.Table.Schema, target.Table.Name, target.Name, sc);
            }
            else if (sourceAnn != null && targetAnn == null)
            {
                // removed
            }
            else
            {
                // possibly changed
                //if(sourcAnn)
            }
        }
    }
}
