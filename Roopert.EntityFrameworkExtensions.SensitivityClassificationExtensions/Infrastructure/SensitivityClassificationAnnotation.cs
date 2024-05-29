using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Roopert.EfCore.SensitivityClassifications.Infrastructure
{
    public class SensitivityClassificationAnnotation : IAnnotation
    {
        public string Name => "SensitivityClassification";

        public object? Value { get; }
    }
}
