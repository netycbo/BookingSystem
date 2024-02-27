using Microsoft.EntityFrameworkCore;
using BookingSystem.Data.Entities;

namespace BookingSystem.Data
{
    internal class BookingSystemContext : DbContext
    {
        public DbSet<RoomBasic> RoomsBasic => Set<RoomBasic>();
        public DbSet<RoomPremium> RoomsPremium => Set<RoomPremium>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase(databaseName: "BookingDb");
        }
    }
   
}
