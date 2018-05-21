using CapstoneData.Models;
using Microsoft.EntityFrameworkCore;


namespace CapstoneData
{
    public class CapstoneContext: DbContext
    {
        public CapstoneContext(DbContextOptions options) : base(options) { }

        private DbSet<Prefix> Prefixes { get; set; }


    }
}
