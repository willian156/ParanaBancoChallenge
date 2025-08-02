using Microsoft.EntityFrameworkCore;
using Customer.Domain.Entities;

namespace Customer.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property<bool>("IsDeleted");

            modelBuilder.Entity<User>().HasQueryFilter(u => EF.Property<bool>(u, "IsDeleted") == false);
        }
    }
}
