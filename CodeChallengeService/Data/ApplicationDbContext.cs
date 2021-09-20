using CodeChallengeService.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeChallengeService.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public virtual DbSet<Publicaciones> Publicacioness { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Publicaciones>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("Publicaciones");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PublishedAt).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

        }
    }
}