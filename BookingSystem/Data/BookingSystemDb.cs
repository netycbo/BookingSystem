using Microsoft.EntityFrameworkCore;
using BookingSystem.Entities;

namespace BookingSystem.Data
{
    internal class BookingSystemDb : DbContext
    {
        public DbSet<RoomBasic> RoomBasic => Set<RoomBasic>();
        public DbSet<RoomPremium> RoomPremium => Set<RoomPremium>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase(databaseName: "BookingDb");
        }
    }
   
}
