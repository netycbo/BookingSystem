using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Data.RoomManager
{
    public interface IRoomManager
    {
        void AddRoomPremium(IWritetRepository<RoomPremium> repository, RoomPremium room);
        void AddRoomBasic(IRepository<RoomBasic> repository, RoomBasic room);
        void DeleteRoom(IRepository<RoomBasic> repository);
        void NewBookingRoomRemoved(object? sender, RoomBasic room);
        void NewBookingRoomAdded(object? sender, RoomBasic room);
    }
}

