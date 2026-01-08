using DataBaseLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBaseLayer.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(200)
                   .HasDefaultValue("Untitled");

            builder.Property(x => x.Content)
                   .HasMaxLength(10000);

            builder.Property(x => x.Color)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasDefaultValue("#FFFFFF");

            builder.Property(x => x.IsPinned)
                   .HasDefaultValue(false);

            builder.Property(x => x.IsArchived)
                   .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // ✅ Keep this cascade (User → Notes)
            builder.HasOne(x => x.User)
                   .WithMany(u => u.Notes)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => new { x.UserId, x.IsArchived });
            builder.HasIndex(x => new { x.UserId, x.IsPinned })
                   .HasFilter("[IsPinned] = 1");
        }
    }
}
