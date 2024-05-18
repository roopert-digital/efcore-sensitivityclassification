using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Roopert.EntityFrameworkExtensions.SensitivityClassificationExtensions
{
    public static class ModelBuilderExtensions
    {
        public static void AnnotateSensitivityClassificationAttributes(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var type = entityType.ClrType;

                EntityTypeBuilder typeBuilder = modelBuilder.Entity(type);

                foreach (var propertyInfo in type.GetProperties())
                {
                    var scAttributes = propertyInfo.GetCustomAttributes(false)
                        .Where(x => x.GetType() == typeof(SensitivityClassificationAttribute))
                        .Cast<SensitivityClassificationAttribute>();

                    foreach (var scAttribute in scAttributes)
                    {
                        typeBuilder
                            .Property(propertyInfo.Name)
                            .HasAnnotation("SensitivityClassification", scAttribute.SensitivityClassificationItem);
                    }
                }
            }
        }
    }
}
