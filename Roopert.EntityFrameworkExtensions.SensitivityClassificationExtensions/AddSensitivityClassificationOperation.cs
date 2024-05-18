using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions
{
    public class AddSensitivityClassificationOperation : MigrationOperation
    {
        public AddSensitivityClassificationOperation(string schemaName, string tableName, string columnName, SensitivityClassificationItem sc)
        {
            SchemaName = schemaName;
            TableName = tableName;
            ColumnName = columnName;
            SensitivityClassification = sc;
        }

        public string SchemaName { get; }

        public string TableName { get; }

        public string ColumnName { get; }

        public SensitivityClassificationItem? SensitivityClassification { get; }
    }
}
