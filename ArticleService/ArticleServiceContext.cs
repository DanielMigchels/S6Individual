using ArticleService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleService
{
    public class ArticleServiceContext : DbContext
    {
        public static ArticleServiceContext current;

        public DbSet<Article> Article { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=articleservice.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
