using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokkiApp
{
    public class CabinBooking
    {
        public string FirstName { get; set; } //pakollinen
        public string LastName { get; set; } //pakollinen
        public string Email { get; set; } //pakollinen
        public string Phone { get; set; } //pakollinen
        public string DateOfArrival { get; set; } //pakollinen
        public string DateOfDeparture { get; set; } //pakollinen
        public string Cabin { get; set; } //pakollinen
        public string AddService { get; set; } //valinnainen

        public CabinBooking(string FirstName, string LastName, string Email, string Phone, string DateOfArrival,
            string DateOfDeparture, string Cabin)
        {
            if(!(FirstName == "" || LastName == "" || Email == "" || Phone == "" || DateOfArrival == "" || DateOfDeparture == "" || 
                Cabin == "" || FirstName == null || LastName == null || Email == null|| Phone == null || DateOfArrival == null || 
                DateOfDeparture == null || Cabin == null))
            {
                this.FirstName = FirstName;
                this.LastName = LastName;
                this.Email = Email;
                this.Phone = Phone;
                this.DateOfArrival = DateOfArrival;
                this.DateOfDeparture = DateOfDeparture;
                this.Cabin = Cabin;
                this.AddService = AddService;
            }
        }

    }
}