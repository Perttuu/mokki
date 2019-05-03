using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokkiApp {
    class Service {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int OfficeId { get; set; }
        public double Tax { get; set; }
        public int Type { get; set; }

        public Service(string Name, double Price, string Description, double Tax, int Type, int OfficeId) {
            try {
                if (Name != "" || Name != null || Price >= 0 || Description != "" || Description != null || Tax >= 0 || Type > 0 || OfficeId > 0) {
                    this.Name = Name;
                    this.Price = Price;
                    this.Description = Description;
                    this.Tax = Tax;
                    this.Type = Type;
                    this.OfficeId = OfficeId;
                    Id = ServiceUtils.GetId();
                }
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }
    }
}
