﻿using Models;
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
        string MySQL_Server = "article-mysql";
#endif

        string MySQL_Database = "article";
        string MySQL_Uid = "article";
        string MySQL_Password = "article";

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
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.SiteId).IsRequired();
                entity.Property(e => e.URI).IsRequired();
                entity.Property(e => e.Created).IsRequired();
            });
        }
    }
}
