using DataBaseLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Configurations
{
    public class OtpConfiguration : IEntityTypeConfiguration<EmailOtp>
    {
        void IEntityTypeConfiguration<EmailOtp>.Configure(EntityTypeBuilder<EmailOtp> builder)
        {
            builder.ToTable("EmailOtps");
            //id
            builder.HasKey(x => x.EmailOtpId);
            builder.Property(x => x.EmailOtpId).ValueGeneratedOnAdd();
            //email
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.HasIndex(x => x.Email).HasDatabaseName("UX_EmailOtp_Email");
            //OtpCode
            builder.Property(x => x.OtpCodeHash).IsRequired().HasMaxLength(255);
            //Purpose
            builder.Property(x => x.Purpose).HasMaxLength(100).IsRequired();
            //ExpiresAt
            builder.Property(x => x.ExpiresAt).IsRequired();
            builder.HasIndex(x => x.ExpiresAt).HasDatabaseName("IX_EmailOtp_ExpiresAt");
            //IsUsed
            builder.Property(x=> x.IsUsed).IsRequired().HasDefaultValue(false);
            //Attempt Count
            builder.Property(x => x.AttemptCount).IsRequired().HasDefaultValue(0);
            //CreateAt
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");

            //Foreign Key EmailOtp -> User 
            builder.HasOne(o => o.User).WithMany(u => u.EmailOtps).HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
