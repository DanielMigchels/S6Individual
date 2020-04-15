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
#if DEBUG
        string MySQL_Server = "127.0.0.1";
#else
        string MySQL_Server = "mysql";
#endif

        string MySQL_Database = "admin";
        string MySQL_Uid = "admin";
        string MySQL_Password = "admin";

        public static ArticleServiceContext current;

        public DbSet<Article> Article { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=articleservice.db;");

            string connectionstring = "Server = " + MySQL_Server + "; Database = " + MySQL_Database + "; Uid = " + MySQL_Uid + "; Pwd = " + MySQL_Password + "; ";
            optionsBuilder.UseMySQL(connectionstring);
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
