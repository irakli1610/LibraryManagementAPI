using LibraryManagement.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Persistance.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
        
        builder.Property(x => x.ISBN).IsRequired().HasMaxLength(13).IsFixedLength();

        builder.Property(x => x.CoverImageUrl).IsRequired();

        builder.Property(x => x.Description).IsRequired();

        builder.Property(x => x.Quantity).HasDefaultValue(0);

        builder.HasOne(x => x.Author)
            .WithMany(x => x.Books)
            .HasForeignKey(x=>x.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
   
        builder.Property(x => x.AuthorId).IsRequired();
    }
}
