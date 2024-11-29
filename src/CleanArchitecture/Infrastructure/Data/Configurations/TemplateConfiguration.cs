using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Configurations;

public class SignageConfiguration : IEntityTypeConfiguration<Signage>
{
    public void Configure(EntityTypeBuilder<Signage> builder)
    {
        builder.ToTable("Signages");

        //Id
        builder.HasKey(x => x.Id);
    }
}
