using Microsoft.EntityFrameworkCore;
using Customer.Domain.Entities;

namespace Customer.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get;set;}
    }
}
