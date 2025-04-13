using LibraryManagement.Domain.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Persistance.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);

        builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

        builder.Property(x => x.Biography).IsRequired();

        builder.HasMany(x => x.Books).WithOne(x => x.Author).OnDelete(DeleteBehavior.Cascade);    
    }
}
