using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions
{
    public class SensitivityClassificationAnnotation : IAnnotation
    {
        public string Name => "SensitivityClassification";

        public object? Value { get; }
    }
}
