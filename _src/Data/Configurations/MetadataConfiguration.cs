using Data.Entities.Proxy;
using Data.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class MetadataConfiguration : IEntityTypeConfiguration<Metadata>
{
    public void Configure(EntityTypeBuilder<Metadata> builder)
    {
        builder.ToTable("Metadata");

        // Primary Key
        builder.HasKey(m => m.Id);

        // Value converter
        var converter = new DictionaryToStringConverter();

        // Value comparer
        var dictionaryComparer = new ValueComparer<Dictionary<string, string>>(
            (d1, d2) => d1.SequenceEqual(d2),
            d => d.Aggregate(0, (a, v) => HashCode.Combine(a, v.Key.GetHashCode(), v.Value.GetHashCode())),
            d => new Dictionary<string, string>(d)
        );

        // Configure properties
        builder.Property(m => m.Data)
            .HasConversion(converter)
            .Metadata.SetValueComparer(dictionaryComparer);

        //Soft Delete Query Filter
        builder.HasQueryFilter(q => !q.IsDeleted);
        builder.HasIndex(i => i.IsDeleted)
            .HasFilter("IsDeleted = 0");
    }
}