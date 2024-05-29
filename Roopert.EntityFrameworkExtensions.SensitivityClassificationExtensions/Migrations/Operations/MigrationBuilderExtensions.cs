using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Roopert.EfCore.SensitivityClassifications.Migrations.Operations
{
    public static class MigrationBuilderExtensions
    {
        public static OperationBuilder<AddSensitivityClassificationOperation> AddSensitivityClassification(
            this MigrationBuilder migrationBuilder,
            string? schemaName, string tableName, string columnName,
            string? label = null, string? labelId = null, string? informationType = null, string? informationTypeId = null, string? rank = null
            )
        {
            var operation = new AddSensitivityClassificationOperation(schemaName, tableName, columnName,
                new SensitivityClassificationItem(label, labelId, informationType, informationTypeId, rank));

            migrationBuilder.Operations.Add(operation);

            return new OperationBuilder<AddSensitivityClassificationOperation>(operation);
        }

        public static OperationBuilder<DropSensitivityClassificationOperation> DropSensitivityClassification(
            this MigrationBuilder migrationBuilder,
            string? schemaName, string tableName, string columnName,
            string? label = null, string? labelId = null, string? informationType = null, string? informationTypeId = null, string? rank = null
        )
        {
            var operation = new DropSensitivityClassificationOperation(schemaName, tableName, columnName);

            migrationBuilder.Operations.Add(operation);

            return new OperationBuilder<DropSensitivityClassificationOperation>(operation);
        }
    }
}
