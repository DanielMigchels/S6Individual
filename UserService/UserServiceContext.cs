using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using UserService.Models;

namespace UserService
{
    public class UserServiceContext : DbContext
    {
        public static UserServiceContext current;

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=studmysql01.fhict.local;Uid=dbi387743;Database=dbi387743;Pwd=database123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UUID);
                entity.Property(e => e.Username).IsRequired();
            });
        }
    }
}
