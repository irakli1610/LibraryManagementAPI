using LibraryManagement.Domain.BorrowRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Persistance.Configurations;

public class BorrowRecordConfiguration : IEntityTypeConfiguration<BorrowRecord>
{
    public void Configure(EntityTypeBuilder<BorrowRecord> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Book)
                .WithMany(b => b.BorrowRecords)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.SetNull); 

        builder.HasOne(x => x.Patron)
               .WithMany(p => p.BorrowRecords)
               .HasForeignKey(x => x.PatronId)
                .OnDelete(DeleteBehavior.SetNull);

        builder.Property(x => x.Status)
               .IsRequired()
               .HasConversion<int>();

        builder.Property(x => x.BorrowDate)
               .IsRequired();

        builder.Property(x => x.DueDate)
               .IsRequired();
    }
}
