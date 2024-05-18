using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Migrations.Operations;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Migrations.Design
{
    public class ExtendedCSharpMigrationOperationGenerator : CSharpMigrationOperationGenerator
    {
        public ExtendedCSharpMigrationOperationGenerator(CSharpMigrationOperationGeneratorDependencies dependencies)
            : base(dependencies)
        {
            //Debugger.Launch();
        }

        protected override void Generate(MigrationOperation operation, IndentedStringBuilder builder)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            switch (operation)
            {
                case AddSensitivityClassificationOperation create:
                    Generate(create, builder);
                    break;

                //case DropSensitivityClassificationOperation drop:
                //    Generate(drop, builder);
                //    break;

                default:
                    base.Generate(operation, builder);
                    break;
            }
        }

        private static void Generate(AddSensitivityClassificationOperation operation, IndentedStringBuilder builder)
        {
            builder.AppendLine(".AddSensitivityClassification(");

            using (builder.Indent())
            {
                builder.AppendLine($"schemaName: \"{operation.SchemaName}\",");
                builder.AppendLine($"tableName: \"{operation.TableName}\",");
                builder.AppendLine($"columnName: \"{operation.ColumnName}\",");

                List<string> options = new List<string>();

                if (operation.SensitivityClassification.Label != null)
                {
                    options.Add($"label: \"{operation.SensitivityClassification.Label}\"");
                }

                if (operation.SensitivityClassification.LabelId != null)
                {
                    options.Add($"labelId: \"{operation.SensitivityClassification.LabelId}\"");
                }

                if (operation.SensitivityClassification.InformationType != null)
                {
                    options.Add($"informationType: \"{operation.SensitivityClassification.InformationType}\"");
                }

                if (operation.SensitivityClassification.InformationTypeId != null)
                {
                    options.Add($"informationTypeId: \"{operation.SensitivityClassification.InformationTypeId}\"");
                }

                if (operation.SensitivityClassification.Rank != null)
                {
                    options.Add($"rank = \"{operation.SensitivityClassification.Rank}\"");
                }

                builder.AppendLines(string.Join(",\r\n", options));
            }

            builder.AppendLine(");");
        }
    }
}
