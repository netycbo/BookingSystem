﻿using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;

namespace BookingSystem.ApplicationServices.RoomManager
{
    public interface IRoomManager
    {

        void AddRoomBasic(RoomBasic room);
        void DeleteRoom(int roomId);
        void FindRoomToUpgrade(int roomId);
        void UpdateRoomBasic();
        void NewBookingRoomRemoved(object? sender, RoomBasic room);
        void NewBookingRoomAdded(object? sender, RoomBasic room);
    }
}

