using Credit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit.Infrastructure.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CreditProposal> CreditProposals { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditProposal>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<CreditProposal>(p => p.UserId)
                .IsRequired();


            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(c => c.Id);

                entity.Metadata.SetIsTableExcludedFromMigrations(true);
            });

        }
    }
}
