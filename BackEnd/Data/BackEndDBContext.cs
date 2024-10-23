using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using BackEnd.Data.Map;

namespace BackEnd.Data
{
    public class BackEndDBContext : DbContext
    {
        public BackEndDBContext(DbContextOptions<BackEndDBContext> options) 
        : base (options)
        {
            
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CompanyModel> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
