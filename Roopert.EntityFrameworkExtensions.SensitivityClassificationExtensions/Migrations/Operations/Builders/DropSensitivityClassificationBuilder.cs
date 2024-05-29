using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Roopert.EfCore.SensitivityClassifications.Migrations.Operations.Builders
{
    public class DropSensitivityClassificationBuilder : OperationBuilder<DropSensitivityClassificationOperation>
    {
        public DropSensitivityClassificationBuilder(DropSensitivityClassificationOperation operation) : base(operation)
        {
        }
    }
}
