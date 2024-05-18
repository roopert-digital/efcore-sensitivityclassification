using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions
{
    public class ExtendedSqlServerMigrationsSqlGenerator : SqlServerMigrationsSqlGenerator
    {
        public ExtendedSqlServerMigrationsSqlGenerator(MigrationsSqlGeneratorDependencies dependencies, ICommandBatchPreparer commandBatchPreparer) : base(dependencies, commandBatchPreparer)
        {
        }

        protected override void Generate(MigrationOperation operation, IModel? model, MigrationCommandListBuilder builder)
        {
            Debugger.Launch();
            switch (operation)
            {
                case AddSensitivityClassificationOperation addSensitivityClassificationOperation:
                    Generate(addSensitivityClassificationOperation, builder, Dependencies.TypeMappingSource);
                    break;

             // TODO remove classification

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
    }
}
