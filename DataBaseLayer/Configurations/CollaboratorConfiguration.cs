using DataBaseLayer.Entities;
using DataBaseLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBaseLayer.Configurations
{
    public class CollaboratorConfiguration : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Permission)
                   .HasConversion<int>()                  // ✅ STORE AS INT
                   .HasDefaultValue(PermissionLevel.View) // ✅ ENUM DEFAULT
                   .IsRequired();

            builder.HasOne(x => x.Note)
                   .WithMany(n => n.Collaborators)
                   .HasForeignKey(x => x.NoteId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.CollaboratorUser)
                   .WithMany(u => u.CollaboratedNotes)
                   .HasForeignKey(x => x.CollaboratorId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => new { x.NoteId, x.CollaboratorId })
                   .IsUnique();

            builder.HasIndex(x => x.NoteId);
            builder.HasIndex(x => x.CollaboratorId);
        }
    }
}
