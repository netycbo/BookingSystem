using BookingSystem.Data.Entities;
using BookingSystem.Components.CSV_Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Data
{
    public class InsertDataFromCsv
    {
        private readonly ICsvReader _csvReader;
        private readonly BookingSystemContext _bookingSystemcontext;
        private void insertData()
        {
            var rooms = _csvReader.ReadRoomData("Resource\\rooms_data.csv");
            foreach (var room in rooms)
            {
                _bookingSystemcontext.Rooms.Add(new RoomBasic()
                {

                    NumberOfBeds = room.NumberOfBeds,
                    PrivateBathroom = room.PrivateBathroom,
                    Balcony = room.Balcony,
                    GymAccess = room.GymAccess,
                    PoolAccess = room.PoolAccess,
                    Kettle = room.Kettle,
                    Tv = room.Tv,
                    Tea_Coffe = room.Tea_Coffe,
                    GardenView = room.GardenView,
                    StreetView = room.StreetView,
                    Safe = room.Safe,

                });
            }

            _bookingSystemcontext.SaveChanges();
        }
    }
}
