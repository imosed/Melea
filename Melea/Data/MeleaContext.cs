using Melea.Models;
using Microsoft.EntityFrameworkCore;

namespace Melea.Data
{
    public class MeleaContext : DbContext
    {
        public MeleaContext(DbContextOptions options) : base(options)
        { 
        }
        
        public DbSet<EssentialOil> Oils { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Blend> Blends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Volume>().HasKey(e => new { e.OilId, e.BlendId });
            
            modelBuilder.Entity<Volume>()
                .HasOne(e => e.Blend)
                .WithMany(e => e.Volumes)
                .HasForeignKey(e => e.BlendId);
            modelBuilder.Entity<Volume>()
                .HasOne(e => e.Oil)
                .WithMany(e => e.Volumes)
                .HasForeignKey(e => e.OilId);
        }
    }
}