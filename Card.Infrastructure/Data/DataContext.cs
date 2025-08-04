using Card.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Card.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CardProposal> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardProposal>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<CardProposal>(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<CardProposal>()
                .HasOne(p => p.CreditProposal)
                .WithOne()
                .HasForeignKey<CardProposal>(p => p.CreditProposalId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(c => c.Id);
                entity.Metadata.SetIsTableExcludedFromMigrations(true);
            });

            modelBuilder.Entity<CreditProposal>(entity =>
            {
                entity.ToTable("CreditProposals");
                entity.HasKey(c => c.Id);
                entity.Metadata.SetIsTableExcludedFromMigrations(true);
            });

        }
    }
}
