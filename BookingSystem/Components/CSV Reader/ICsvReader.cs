using BookingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Components.CSV_Reader
{
    public interface ICsvReader
    {
        List<RoomBasic> ReadRoomData(string path);
        
    }
}
