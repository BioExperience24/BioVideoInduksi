using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Configurations;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.ToTable("Media");

        //Id
        builder.HasKey(x => x.Id);

        // change enum to string
        builder.Property(x => x.MediaType).HasConversion<string>();
    }
}
