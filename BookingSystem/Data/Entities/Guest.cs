
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookingSystem.Data.Entities
{
    public class Guest
    {
       
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"    FirstName: {Name}   LastName: {Surname}");
            sb.AppendLine($"    Email: {Email}   PhoneNumber: {PhoneNumber}");
            sb.AppendLine($"    Adress: {Address}"); 
              
            return sb.ToString();
        }
    }
}
