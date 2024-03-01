namespace BookingSystem
{
    public class UserCommunication : IUserCommunicacion
    {
        public bool GetUpgrades()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "yes")
                {
                    return true;
                }
                else if (input == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input only yes or no:");
                }
            }
        }

        public int GetValueFromUser()
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value))
            {
                return value;
            }
            return 69;
        }
    }
}
