using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokkiApp {
    class Office {
        public string Zip { get; set; } //pakollinen
        public string City { get; set; } //pakollinen
        public string StreetAddress { get; set; } //pakollinen
        public string Description { get; set; } //valinnainen
        public int Id { get; set; } //automaattinen
        public string Email { get; set; } //valinnainen
        public string Phone { get; set; } //valinnainen


        /// <summary>
        /// Zip, City, StreetAddress ei saa olla null eikä tyhjä("")
        /// </summary>
        /// <param name="Zip"></param>
        /// <param name="City"></param>
        /// <param name="StreetAddress"></param>
        /// <param name="Description"></param>
        /// <param name="Email"></param>
        /// <param name="Phone"></param>
        public Office(string Zip, string City, string StreetAddress, string Description, string Email, string Phone) {
            if (!(Zip == "" || City == "" || StreetAddress == "" || Zip == null || City == null || StreetAddress == null)) {
                this.Zip = Zip;
                this.City = City;
                this.StreetAddress = StreetAddress;
                this.Description = Description;
                this.Email = Email;
                this.Phone = Phone;
            }
        }
    }
}
