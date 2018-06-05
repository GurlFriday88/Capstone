using Capstone.Models;
using Microsoft.EntityFrameworkCore;

namespace Capstone.Data
{
    public class CapstoneDBContext : DbContext
    {
        public CapstoneDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Prefix> Prefixes { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Store> Stores { get; set; }
       



    }
}
