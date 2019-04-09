using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokkiApp {
    class User {
        public string Username { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public bool Admin { get; set; }

        public User(string Username, string Hash, string Salt, bool Admin) {
            this.Username = Username;
            this.Hash = Hash;
            this.Salt = Salt;
            this.Admin = Admin;
        }
    }
}
