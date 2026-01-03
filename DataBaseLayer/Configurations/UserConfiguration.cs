using DataBaseLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Configurations
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            //primary key
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.UserId).ValueGeneratedOnAdd();
            //User name 
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(100);
            builder.HasIndex(u => u.UserName).IsUnique().IsUnique().HasDatabaseName("UX_Users_UserName");
            //UserEmail
            builder.Property(u => u.UserEmail).IsRequired().HasMaxLength(150);
            builder.HasIndex(u => u.UserEmail).IsUnique().HasDatabaseName("UX_Users_UserName");

            //Phone number
            builder.Property(u => u.UserPhoneNumber).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.UserPhoneNumber).IsUnique().HasDatabaseName("UX_Users_Phone");

            //Password
            builder.Property(u => u.UserPhoneNumber).IsRequired().HasMaxLength(255);

            //created At
            builder.Property(u => u.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
