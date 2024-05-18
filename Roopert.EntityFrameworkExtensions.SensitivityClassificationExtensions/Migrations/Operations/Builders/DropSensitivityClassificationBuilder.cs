using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Migrations.Operations.Builders
{
    public class DropSensitivityClassificationBuilder : OperationBuilder<DropSensitivityClassificationOperation>
    {
        public DropSensitivityClassificationBuilder(DropSensitivityClassificationOperation operation) : base(operation)
        {
        }
    }
}
