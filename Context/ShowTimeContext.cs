using ShowTime.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ShowTime.Context
{
    public class ShowTimeContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ShowTimeContext(DbContextOptions<ShowTimeContext> options)
            : base(options)
        { }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<FestivalBand> FestivalBands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FestivalBand>()
                .HasKey(e => new { e.FestivalId, e.BandId });

            modelBuilder.Entity<FestivalBand>()
                .HasOne(e => e.Band)
                .WithMany(e => e.FestivalBand)
                .HasForeignKey(e => e.BandId);

            modelBuilder.Entity<FestivalBand>()
                .HasOne(e => e.Festival)
                .WithMany(e => e.FestivalBand)
                .HasForeignKey(e => e.FestivalId);
                
            base.OnModelCreating(modelBuilder);
        }

    }
}