using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Serie> series { get; set; }
        public DbSet<Genre> genre { get; set; }
        public DbSet<Producer> producer { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Serie>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Serie>()
                .HasOne(s => s.Producer)
                .WithMany(p => p.Series)
                .HasForeignKey(s => s.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
                .HasOne(s => s.PrimaryGenre)
                .WithMany(g => g.SeriesAsPrimary)
                .HasForeignKey(s => s.PrimaryGenreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
                .HasOne(s => s.SecondaryGenre)
                .WithMany(g => g.SeriesAsSecondary)
                .HasForeignKey(s => s.SecondaryGenreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Producer>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Genre>()
                .HasKey(g => g.Id);
        }

    }
}
