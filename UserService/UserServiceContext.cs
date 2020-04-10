using Microsoft.EntityFrameworkCore;
using System.Data.SQLite;
using UserService.Models;

namespace UserService
{
    public class UserServiceContext : DbContext
    {
        public static UserServiceContext current;

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=userservice.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired();
            });
        }
    }
}
