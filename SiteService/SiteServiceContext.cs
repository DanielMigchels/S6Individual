using Microsoft.EntityFrameworkCore;
using Models;

namespace SiteService
{
    public class SiteServiceContext : DbContext
    {
#if DEBUG
        string MySQL_Server = "127.0.0.1";
#else
        string MySQL_Server = "site-mysql";
#endif

        string MySQL_Database = "site";
        string MySQL_Uid = "site";
        string MySQL_Password = "site";

        public static SiteServiceContext current;

        public DbSet<Site> Site { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=userservice.db;");

            string connectionstring = "Server = " + MySQL_Server + "; Database = " + MySQL_Database + "; Uid = " + MySQL_Uid + "; Pwd = " + MySQL_Password + "; ";
            optionsBuilder.UseMySQL(connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.DomainName).IsRequired();
                entity.Property(e => e.Created).IsRequired();
            });
        }
    }
}
