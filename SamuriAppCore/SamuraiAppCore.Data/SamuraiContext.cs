using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamuraiAppCore.Domain;

namespace SamuraiAppCore.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Battle> Battles { get; set; } 
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Samurai> Samurais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= (localdb)\\mssqllocaldb; Database = SamuraiDataCore; Trusted_Connection = True;");
        }

    }
}
