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
                yield return new DropSensitivityClassificationOperation(target.Table.Schema, target.Table.Name, target.Name);
            }
            else
            {
                // possibly changed
                var ssc = sourceAnn.Value as SensitivityClassificationItem ?? throw new InvalidOperationException();
                var tsc = targetAnn.Value as SensitivityClassificationItem ?? throw new InvalidOperationException();

                if (
                    (ssc.Label ?? string.Empty) != (tsc.Label ?? string.Empty)
                    || (ssc.LabelId ?? string.Empty) != (tsc.LabelId ?? string.Empty)
                    || (ssc.InformationType ?? string.Empty) != (tsc.InformationType ?? string.Empty)
                    || (ssc.InformationTypeId ?? string.Empty) != (tsc.InformationTypeId ?? string.Empty)
                    || (ssc.Rank ?? string.Empty) != (tsc.Rank ?? string.Empty))
                {
                    yield return new AddSensitivityClassificationOperation(target.Table.Schema, target.Table.Name, target.Name, tsc);
                }
            }
        }
    }
}
