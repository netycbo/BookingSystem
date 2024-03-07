using Microsoft.EntityFrameworkCore;
using BookingSystem.Data.Entities;
using System.Reflection.Emit;

namespace BookingSystem.Data
{
    public class BookingSystemContext : DbContext
    {
        public BookingSystemContext(DbContextOptions<BookingSystemContext> options) : base(options)
        {
            
        }
       
        public DbSet<Guest> Guests { get; set; }
        public DbSet<RoomBasic> Rooms { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Guest>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd(); 

                modelBuilder.Entity<RoomBasic>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd(); 

            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd(); 

            base.OnModelCreating(modelBuilder);
        }



    }

}
