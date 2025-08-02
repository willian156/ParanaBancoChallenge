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

        DbSet<CreditProposal> CreditProposals { get; set; }
        DbSet<UserReadOnly> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserReadOnly>().ToTable("Users");
            modelBuilder.Entity<UserReadOnly>().HasKey(c => c.Id);

            modelBuilder.Entity<CreditProposal>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<CreditProposal>(p => p.UserId)
                .IsRequired();
        }
    }
}
