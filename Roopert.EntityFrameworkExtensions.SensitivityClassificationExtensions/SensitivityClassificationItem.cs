namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions
{
    public class SensitivityClassificationItem
    {
        public string? Label { get; }
        public string? LabelId { get; }
        public string? InformationType { get; }
        public string? InformationTypeId { get; }
        public string? Rank { get; }

        public SensitivityClassificationItem(string? label = null, string? labelId = null, string? informationType = null, string? informationTypeId = null, string? rank = null)
        {
            if (label == null
                && labelId == null
                && informationType == null
                && informationTypeId == null
                && rank == null)
            {
                throw new ArgumentException("At least one parameter needs a value");
            }

            Label = label;
            LabelId = labelId;
            InformationType = informationType;
            InformationTypeId = informationTypeId;
            Rank = rank;
        }
    }
}
