using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Roopert.EfCore.SensitivityClassifications.Migrations.Operations
{
    public class DropSensitivityClassificationOperation : MigrationOperation
    {
        public DropSensitivityClassificationOperation(string schemaName, string tableName, string columnName)
        {
            SchemaName = schemaName;
            TableName = tableName;
            ColumnName = columnName;
        }

        public string SchemaName { get; }

        public string TableName { get; }

        public string ColumnName { get; }
    }
}
