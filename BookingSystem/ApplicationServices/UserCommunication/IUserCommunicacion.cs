using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;

namespace BookingSystem.ApplicationServices.UserCommunication
{
    public interface IUserCommunicacion
    {
        int GetValueFromUser();
        bool GetUpgrades();
        void UserInterface();
    }
}
