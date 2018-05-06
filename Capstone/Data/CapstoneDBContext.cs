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
        public DbSet<AutoMemo>AutoMemos  { get; set; }
        public DbSet<MemoChoice>MemoChoices  { get; set; }
        public DbSet<Provider>Providers  { get; set; }
        public DbSet<BcbsPrefix>BcbsPrefixes  { get; set; }
        public DbSet<Patient>Patients  { get; set; }
        public DbSet<Store>Stores  { get; set; }

public CapstoneDBContext(DbContextOptions<CapstoneDBContext> options)
            : base(options)
        {
        }


    }
}
