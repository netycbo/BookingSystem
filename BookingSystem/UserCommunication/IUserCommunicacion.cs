using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;

namespace BookingSystem
{
    public interface IUserCommunicacion
    {
        int GetValueFromUser();
        bool GetUpgrades();
    }
}
