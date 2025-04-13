using LibraryManagement.Domain.Patrons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Persistance.Configurations;

public class PatronConfiguration : IEntityTypeConfiguration<Patron>
{
    public void Configure(EntityTypeBuilder<Patron> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p=>p.FirstName).IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.LastName).IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Email).IsRequired()
            .HasMaxLength(255);
        
        builder.HasIndex(p => p.Email).IsUnique();

        builder.Property(p => p.MembershipDate).IsRequired();

        builder.HasMany(p=>p.BorrowRecords)
            .WithOne(br => br.Patron)
            .HasForeignKey(br => br.PatronId);
    }
}
