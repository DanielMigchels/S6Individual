using Microsoft.EntityFrameworkCore;
using SiteService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteService
{
    public class SiteServiceContext : DbContext
    {
        public static SiteServiceContext current;

        public DbSet<Site> Site { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=siteservice.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
