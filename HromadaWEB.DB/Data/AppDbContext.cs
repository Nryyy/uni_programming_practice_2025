using HromadaWEB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HromadaWEB.DB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<EvaluationDirection> EvaluationDirections { get; set; }
        public DbSet<Indicator> Indicators { get; set; }
    }
}
