
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookingSystem.Data.Entities
{
    public  class Restaurant
    {
        
        public int Id { get; set; }
        public int GuestId { get; set; }
      
        public int RoomNumber { get; set; }
        public int Price { get; set; }
        public bool Breakfast { get; set; }
        public string BreakfastDescription { get; set; }
        public bool Brunch { get; set; }
        public string BrunchDescription { get; set; }
        public bool Dinner { get; set; }
        public string DinnerDescription { get; set; }

        public Restaurant()
        {
        }
        public Restaurant(int roomNumber, int basePrice, bool breakfast, string breakfastDescription, bool brunch, string brunchDescription, bool dinner, string dinnerDescription)
        {

            RoomNumber = roomNumber;
            Breakfast = breakfast;
            BreakfastDescription = breakfastDescription;
            Dinner = dinner;
            DinnerDescription = dinnerDescription;
            Brunch = brunch;
            BrunchDescription = brunchDescription;

            Price = basePrice;

            if (Breakfast)
            {
                Price += 50;
            }

            if (Brunch)
            {
                Price += 60;
            }

            if (Dinner)
            {
                Price += 100;
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"    Room Number: {RoomNumber}");
            sb.AppendLine($"    Price: {Price}");
            sb.AppendLine($"    Breakfast {(Breakfast ? "yes" : "no")}  Breakfast description: {BreakfastDescription}");
            sb.AppendLine($"    Brunch {(Brunch ? "yes" : "no")}  Brunch description: {BrunchDescription}");
            sb.AppendLine($"    Dinner {(Dinner ? "yes" : "no")}  Dinner description: {DinnerDescription}");
           
            return sb.ToString();
        }
    }
}


