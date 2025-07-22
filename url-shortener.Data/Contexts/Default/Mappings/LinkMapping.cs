using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using url_shortener.Domain.Entities;

namespace url_shortener.Data.Contexts.Default.Mappings;
public class LinkMapping : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder.ToTable("TB_LINK");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("INT")
            .HasColumnName("ID_LINK")
            .IsRequired();

        builder.Property(x => x.OriginalUrl)
            .HasColumnType("varchar(500)")
            .HasColumnName("DS_ORIGINAL_URL")
            .IsRequired();

        builder.Property(x => x.ShortenedUrl)
            .HasColumnType("varchar(100)")
            .HasColumnName("DS_SHORTENED_URL")
            .IsRequired();
    }
}
