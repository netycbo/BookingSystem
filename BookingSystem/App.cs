using BookingSystem.DataProvider;
using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;
using BookingSystem.Components.CSV_Reader;
using BookingSystem.Data;
using BookingSystem.RoomManagment;

namespace BookingSystem
{
    public class App : IApp
    {
        private readonly BookingSystemContext _bookingSystemcontext;
        private readonly IRepository<RoomBasic> _roomRepository;
        private readonly IUserCommunicacion _userCommunication;

        public App(BookingSystemContext bookingSystemcontext, IRepository<RoomBasic> roomBasicRepository,IUserCommunicacion userCommunication)
        {
            
            _roomRepository = roomBasicRepository;
            _bookingSystemcontext = bookingSystemcontext;
            _userCommunication = userCommunication;
            _bookingSystemcontext.Database.EnsureCreated();
        }

        public void Run()
        {
            
            _userCommunication.UserInterface();
        }
    }
}
    

