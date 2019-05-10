using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokkiApp {
    class Office {
        public string Zip { get; set; } //pakollinen
        public string PostalArea { get; set; } //pakollinen
        public string StreetAddress { get; set; } //pakollinen
        public int Id { get; set; } //automaattinen
        public string Email { get; set; } //valinnainen
        public string Phone { get; set; } //valinnainen
        public string Name { get; set; } //pakollinen


        /// <summary>
        /// Name, Zip, City, StreetAddress ei saa olla null eikä tyhjä("")
        /// </summary>
        /// <param name="Zip"></param>
        /// <param name="PostalArea"></param>
        /// <param name="StreetAddress"></param>
        /// <param name="Description"></param>
        /// <param name="Email"></param>
        /// <param name="Phone"></param>
        public Office(string Name, string Zip, string PostalArea, string StreetAddress, string Email, string Phone) {
            if (!(Name == "" || Zip == "" || PostalArea == "" || StreetAddress == "" || Name == null || Zip == null || PostalArea == null || StreetAddress == null)) {
                this.Name = Name;
                this.Zip = Zip;
                this.PostalArea = PostalArea;
                this.StreetAddress = StreetAddress;
                this.Email = Email;
                this.Phone = Phone;
            }
        }
    }
}
