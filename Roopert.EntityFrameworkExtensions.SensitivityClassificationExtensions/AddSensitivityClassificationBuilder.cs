using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions
{
    public class AddSensitivityClassificationBuilder : OperationBuilder<AddSensitivityClassificationOperation>
    {
        public AddSensitivityClassificationBuilder(AddSensitivityClassificationOperation operation) : base(operation)
        {
        }
    }
}
