using DataBaseLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayer.Context
{
    public class FundooAppDbContext : DbContext
    {
        public FundooAppDbContext(DbContextOptions<FundooAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Note> Notes => Set<Note>();
        public DbSet<Label> Labels => Set<Label>();
        public DbSet<Collaborator> Collaborators => Set<Collaborator>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(FundooAppDbContext).Assembly);

            modelBuilder.Entity<Note>()
                .HasMany(n => n.Labels)
                .WithMany(l => l.Notes)
                .UsingEntity<Dictionary<string, object>>(
                    "LabelNote",
                    j => j
                        .HasOne<Label>()
                        .WithMany()
                        .HasForeignKey("LabelsId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Note>()
                        .WithMany()
                        .HasForeignKey("NotesId")
                        .OnDelete(DeleteBehavior.NoAction)
                );
        }
    }
}
