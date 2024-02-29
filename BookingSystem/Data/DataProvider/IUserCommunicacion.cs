using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;

namespace BookingSystem.Data.DataProvider
{
    public interface IUserCommunicacion
    {
        int GetValueFromUser();
        bool GetUpgrades();
    }
}
