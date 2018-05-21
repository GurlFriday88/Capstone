using Capstone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Data
{
    public class CapstoneDBContext : DbContext
    {
        public CapstoneDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Prefix> Prefixes { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderNote> ProviderNotes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MemoOption> MemoOptions { get; set; }



    }
}
