using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService
{
    public class UserServiceContext : DbContext
    {
#if DEBUG
        string MySQL_Server = "127.0.0.1";
#else
        string MySQL_Server = "user-mysql";
#endif

        string MySQL_Database = "user";
        string MySQL_Uid = "user";
        string MySQL_Password = "user";

        public static UserServiceContext current;

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=userservice.db;");

            string connectionstring = "Server = " + MySQL_Server + "; Database = " + MySQL_Database + "; Uid = " + MySQL_Uid + "; Pwd = " + MySQL_Password + "; ";
            optionsBuilder.UseMySQL(connectionstring);
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
