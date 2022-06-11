using EvolutionTechTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EvolutionTechTest.Infrastructure.Respositories.Data
{
    public class EvolutionTestContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public EvolutionTestContext(DbContextOptions<EvolutionTestContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
