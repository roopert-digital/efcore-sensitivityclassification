using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Design;

public class ExtendedCSharpHelper : CSharpHelper
{
    public ExtendedCSharpHelper(ITypeMappingSource typeMappingSource) : base(typeMappingSource)
    {
    }

    public override string UnknownLiteral(object? value)
    {
        if (value != null && value is SensitivityClassificationItem i)
        {
            return
                $"new SensitivityClassificationItem(\"{i.Label}\", \"{i.LabelId}\", \"{i.InformationType}\", \"{i.InformationTypeId}\", \"{i.Rank}\")";
        }

        return base.UnknownLiteral(value);
    }
}