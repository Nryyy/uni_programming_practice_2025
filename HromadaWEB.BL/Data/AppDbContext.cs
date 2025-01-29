using HromadaWEB.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace HromadaWEB.BL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
