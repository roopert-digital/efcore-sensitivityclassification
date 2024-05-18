# EF Core SensitivityClassificationExtensions

**Note: code is not production-ready**

`Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions` provides EF Core support for MS SQL Data Discovery and Classification.

More specifically it supports creating and dropping columns sensitivity classifications:
* ADD SENSITIVITY CLASSIFICATION
* DROP SENSITIVITY CLASSIFICATION

## Installation

### Override Design time services

To override the EF Core Design Time Services, add an `Properties\Assembly.cs` file with:

`[assembly: DesignTimeServicesReference(
    "Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions.Design.ExtendedDesignTimeServices, Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions")]`

This makes sure the necessary Design Time Services are overridden with the extended versions.

See also:
* https://github.com/dotnet/efcore/issues/13690 
* https://github.com/dotnet/efcore/issues/10154

Reference `Microsoft.EntityFrameworkCore.Design` and change the `PagackeReference` as described in 
https://learn.microsoft.com/en-us/ef/core/cli/services

### Annotate the Classification Attributes

For ease of usage, a `SensitivityClassificationAttribute` is a available.

To annotate these in the ModelBuilder:
* In the DbContext, override `OnModelCreating()`
* Call `modelBuilder.AnnotateSensitivityClassificationAttributes();`

## Usage

Once everything is set up, annotate sensitive properties as follows:

```csharp
public class Customer
{
    public int Id { get; set; }

    [SensitivityClassification(label: "Name", informationType: "Confidential - GDPR")]
    public string Firstname { get; set; }

    [SensitivityClassification(label: "Name", informationType: "Confidential - GDPR")]
    public string Lastname { get; set; }
}
```

# Credits

Thanks to https://github.com/VictordeBaare for doing the heavy lifting in https://github.com/VictordeBaare/EntityFrameworkExtensions. 
His article paved the way: https://xebia.com/blog/extending-entity-framework-core/.

Other:

## References

SQL statement documentation:
* https://learn.microsoft.com/en-us/sql/t-sql/statements/add-sensitivity-classification-transact-sql?view=sql-server-ver15
* https://learn.microsoft.com/en-us/sql/t-sql/statements/drop-sensitivity-classification-transact-sql?view=sql-server-ver16

Feature being requested in efcore:
* https://github.com/dotnet/efcore/issues/15693
* https://github.com/dotnet/efcore/issues/20302

EF Core docs on extending:
* https://learn.microsoft.com/en-us/ef/core/miscellaneous/internals/tools
* https://learn.microsoft.com/en-us/ef/core/cli/services


Other EF Core extension examples:
* https://github.com/bricelam/EFCore.Pluralizer
* https://github.com/win7user10/Laraue.EfCoreTriggers
* https://github.com/mzwierzchlewski/EFCore.AuditExtensions
* https://github.com/jamesfera/EntityFrameworkCore.SqlChangeTracking
* https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql

Other articles:
* https://maciejz.dev/entity-framework-core-extension-tips-tricks-migration-operations/
* https://maciejz.dev/debugging-ef-core-migrations/
* https://stackoverflow.com/questions/63575132/how-to-customize-migration-generation-in-ef-core-code-first