using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;

namespace BookingSystem.Data.UserCommunication
{
    public interface IUserCommunicacion
    {
        int GetValueFromUser();
        bool GetUpgrades();
    }
}
