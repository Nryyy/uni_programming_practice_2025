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
        public DbSet<AnswerStatus> AnswerStatuses { get; set; }
        public DbSet<IndicatorAnswers> IndicatorAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndicatorAnswers>()
                .HasOne(ia => ia.Responser)
                .WithMany() // Якщо у `User` є колекція `IndicatorAnswers`, вкажи її тут
                .HasForeignKey(ia => ia.ResponserId)
                .OnDelete(DeleteBehavior.NoAction); // Вимикає каскадне видалення

            modelBuilder.Entity<IndicatorAnswers>()
                .HasOne(ia => ia.Indicator)
                .WithMany()
                .HasForeignKey(ia => ia.IndicatorId)
                .OnDelete(DeleteBehavior.Cascade); // Якщо потрібно каскадне видалення

            modelBuilder.Entity<IndicatorAnswers>()
                .HasOne(ia => ia.AnswerStatus)
                .WithMany()
                .HasForeignKey(ia => ia.AnswerStatusId)
                .OnDelete(DeleteBehavior.Restrict); // Обмежує видалення, щоб уникнути помилок

            base.OnModelCreating(modelBuilder);
        }
    }
}
