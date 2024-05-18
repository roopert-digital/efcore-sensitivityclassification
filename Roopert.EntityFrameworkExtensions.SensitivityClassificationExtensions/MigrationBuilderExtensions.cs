using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions
{
    public static class MigrationBuilderExtensions
    {
        public static OperationBuilder<AddSensitivityClassificationOperation> AddSensitivityClassification(
            this MigrationBuilder migrationBuilder,
            string? schemaName, string tableName, string columnName,
            string? label = null, string? labelId = null, string? informationType = null, string? informationTypeId = null, string? rank = null
            )
        {
            Debugger.Break();

            var operation = new AddSensitivityClassificationOperation(schemaName, tableName, columnName, 
                new SensitivityClassificationItem(label, labelId, informationType, informationTypeId, rank));

            migrationBuilder.Operations.Add(operation);

            return new OperationBuilder<AddSensitivityClassificationOperation>(operation);
        }
    }
}
