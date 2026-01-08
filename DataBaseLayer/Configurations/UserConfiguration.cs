using DataBaseLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBaseLayer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(128);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(x => x.IsEmailVerified)
                   .HasDefaultValue(false);

            builder.Property(x => x.EmailVerificationToken)
                   .HasMaxLength(450)
                   .IsRequired(false);

            builder.Property(x => x.ResetPasswordToken)
                   .HasMaxLength(450)
                   .IsRequired(false);

            builder.Property(x => x.EmailVerificationExpiry)
                   .IsRequired(false);

            builder.Property(x => x.ResetPasswordExpiry)
                   .IsRequired(false);

            builder.HasIndex(x => x.Email)
                   .IsUnique();

            builder.HasIndex(x => x.EmailVerificationToken);

            builder.HasIndex(x => x.ResetPasswordToken);
        }
    }
}
