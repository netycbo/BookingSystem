using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;

namespace BookingSystem
{
    public interface IRoomManager
    {
        
        void AddRoomBasic(IRepository<RoomBasic> repository, RoomBasic room);
        void DeleteRoom(IRepository<RoomBasic> repository);
        void NewBookingRoomRemoved(object? sender, RoomBasic room);
        void NewBookingRoomAdded(object? sender, RoomBasic room);
    }
}

