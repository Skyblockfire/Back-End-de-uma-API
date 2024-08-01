using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

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
            base.OnModelCreating(modelBuilder);
        }
    }
}
