using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MilkDbContext : DbContext
    {

        public MilkDbContext(DbContextOptions<MilkDbContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
    }
}
