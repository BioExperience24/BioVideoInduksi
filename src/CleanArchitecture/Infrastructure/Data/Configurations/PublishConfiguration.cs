using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Configurations;

public class PublishConfiguration : IEntityTypeConfiguration<Publish>
{
    public void Configure(EntityTypeBuilder<Publish> builder)
    {
        builder.ToTable("Publishes");

        //Id
        builder.HasKey(x => x.Id);

        // change enum to string
        builder.Property(x => x.PublishType).HasConversion<string>();
    }
}
