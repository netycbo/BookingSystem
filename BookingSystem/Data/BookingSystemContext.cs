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
        
        
    }

}
