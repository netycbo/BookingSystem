using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;

namespace BookingSystem.RoomManagment
{
    public interface IRoomManager
    {

        void AddRoomBasic(RoomBasic room);
        void DeleteRoom(int roomId);
        void NewBookingRoomRemoved(object? sender, RoomBasic room);
        void NewBookingRoomAdded(object? sender, RoomBasic room);
    }
}

