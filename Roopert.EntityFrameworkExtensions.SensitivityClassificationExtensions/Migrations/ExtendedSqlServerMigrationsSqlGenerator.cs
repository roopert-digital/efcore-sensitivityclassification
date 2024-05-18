using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Migrations.Operations;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Migrations
{
    public class ExtendedSqlServerMigrationsSqlGenerator : SqlServerMigrationsSqlGenerator
    {
        public ExtendedSqlServerMigrationsSqlGenerator(MigrationsSqlGeneratorDependencies dependencies, ICommandBatchPreparer commandBatchPreparer) : base(dependencies, commandBatchPreparer)
        {
        }

        protected override void Generate(MigrationOperation operation, IModel? model, MigrationCommandListBuilder builder)
        {
            switch (operation)
            {
                case AddSensitivityClassificationOperation addOperation:
                    Generate(addOperation, builder, Dependencies.TypeMappingSource);
                    break;
                case DropSensitivityClassificationOperation dropOperation:
                    Generate(dropOperation, builder, Dependencies.TypeMappingSource);
                    break;
                default:
                    base.Generate(operation, model, builder);
                    break;
            }
        }

        private void Generate(AddSensitivityClassificationOperation operation, MigrationCommandListBuilder builder, IRelationalTypeMappingSource typeMappingSource)
        {
            string tableIdentifier = operation.TableName;

            if (!string.IsNullOrEmpty(operation.SchemaName))
            {
                tableIdentifier = $"{operation.SchemaName}.{tableIdentifier}";
            }

            builder.AppendLine($"ADD SENSITIVITY CLASSIFICATION TO {tableIdentifier}.{operation.ColumnName}");
            builder.AppendLine("WITH (");
            using (builder.Indent())
            {
                List<string> options = new List<string>();

                if (operation.SensitivityClassification.Label != null)
                {
                    options.Add($"LABEL = '{operation.SensitivityClassification.Label}'");
                }

                if (operation.SensitivityClassification.LabelId != null)
                {
                    options.Add($"LABEL_ID = '{operation.SensitivityClassification.LabelId}'");
                }

                if (operation.SensitivityClassification.InformationType != null)
                {
                    options.Add($"INFORMATION_TYPE = '{operation.SensitivityClassification.InformationType}'");
                }

                if (operation.SensitivityClassification.InformationTypeId != null)
                {
                    options.Add($"INFORMATION_TYPE_ID = '{operation.SensitivityClassification.InformationTypeId}'");
                }

                if (operation.SensitivityClassification.Rank != null)
                {
                    options.Add($"RANK = '{operation.SensitivityClassification.Rank}'");
                }

                builder.AppendLines(string.Join(",\r\n", options));
            }
            builder.AppendLine(");");
            builder.EndCommand();
        }

        private void Generate(DropSensitivityClassificationOperation operation, MigrationCommandListBuilder builder, IRelationalTypeMappingSource dependenciesTypeMappingSource)
        {
            string tableIdentifier = operation.TableName;

            if (!string.IsNullOrEmpty(operation.SchemaName))
            {
                tableIdentifier = $"{operation.SchemaName}.{tableIdentifier}";
            }

            builder.AppendLine($"DROP SENSITIVITY CLASSIFICATION FROM {tableIdentifier}.{operation.ColumnName}");
            builder.EndCommand();
        }
    }
}
