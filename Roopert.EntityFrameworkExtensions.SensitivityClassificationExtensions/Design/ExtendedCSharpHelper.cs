using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace Roopert.EfCore.SensitivityClassifications.Design;

public class ExtendedCSharpHelper(ITypeMappingSource typeMappingSource) : CSharpHelper(typeMappingSource)
{
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