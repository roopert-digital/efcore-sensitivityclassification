using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Roopert.EfCore.SensitivityClassifications.Migrations.Operations.Builders
{
    public class AddSensitivityClassificationBuilder : OperationBuilder<AddSensitivityClassificationOperation>
    {
        public AddSensitivityClassificationBuilder(AddSensitivityClassificationOperation operation) : base(operation)
        {
        }
    }
}
