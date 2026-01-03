using System;
using System.Collections.Generic;
using System.Text;
using DataBaseLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using DataBaseLayer.Context;


namespace DataBaseLayer.Context
{
    public class FundooNotesDbContext:DbContext
    {
        public FundooNotesDbContext(DbContextOptions dbContextOptions):base(dbContextOptions) { }
        public DbSet<User>? users;
        public DbSet<EmailOtp> emails;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof
                (FundooNotesDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
