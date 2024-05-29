namespace Roopert.EfCore.SensitivityClassifications
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class SensitivityClassificationAttribute : Attribute
    {
        public SensitivityClassificationAttribute(string? label = null, string? labelId = null, string? informationType = null, string? informationTypeId = null, string? rank = null)
        {
            SensitivityClassificationItem = new SensitivityClassificationItem(label, labelId, informationType, informationTypeId, rank);
        }

        public SensitivityClassificationItem SensitivityClassificationItem { get; }
    }
}
