using ASPNETMVCCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Xml;

namespace ASPNETMVCCRUD.Data
{
    public class MVCDemoDbContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }


        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)// Crée la migration
        {
            modelBuilder.Entity<Employee>().Property(p => p.Salary).HasColumnType("decimal(18,4)");
        }
    }
}
