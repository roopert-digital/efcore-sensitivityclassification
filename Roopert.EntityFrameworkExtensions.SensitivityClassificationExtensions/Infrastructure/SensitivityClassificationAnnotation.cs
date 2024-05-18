using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Infrastructure
{
    public class SensitivityClassificationAnnotation : IAnnotation
    {
        public string Name => "SensitivityClassification";

        public object? Value { get; }
    }
}
