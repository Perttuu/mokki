using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MokkiApp {
    static class UserUtils {

        private static List<string> errorMessages; //Virheviestilista
        public static User LoggedUser; //Kirjautunut käyttäjä, tarvitaan admintoimia varten, sekä mahdollista lokia varten
        private static List<User> users; //Tietokannasta tuotu lista käyttäjiä

        /// <summary>
        /// Tuo käyttäjälistan.
        /// </summary>
        /// <param name="userlist"></param>
        public static void SetUserlist(List<User> userlist) {
            users = new List<User>();
            try {
                foreach (User u in userlist) {
                    users.Add(u);
                }
            }
            catch {
                AddErrorMessage("Käyttäjälistan tuonti epäonnistui.");
            }
        }

        /// <summary>
        /// Vie käyttäjälistan.
        /// </summary>
        /// <returns></returns>
        public static List<User> GetUserlist() {
            List<User> ret = new List<User>();
            try {
                foreach (User u in users) {
                    ret.Add(u);
                }
            }
            catch {
                AddErrorMessage("Käyttäjälistan vienti epäonnistui.");
            }
            return ret;
        }
        
        /// <summary>
        /// Generoi suolan
        /// </summary>
        /// <returns></returns>
        public static string GetSalt() {
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            int maxLength = 16;
            byte[] salt = new byte[maxLength];
            random.GetNonZeroBytes(salt);
            return Convert.ToBase64String(salt);
        }

        /// <summary>
        /// Generoi MD5 hashin syötteestä.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetHash(string input) {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));
            for (int i = 0; i < bytes.Length; i++) {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        /// <summary>
        /// Tarkistaa onko salasana käypä.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool LegitPassword(string password) {
            bool ret = true;
            if (password.Length < 8) {
                ret = false;
            }
            else if (password.Contains(' ')) {
                ret = false;
            }
            if (!ret) {
                AddErrorMessage("Salasanan pitää olla vähintään 8 merkkiä pitkä, sekä ei saa sisältää välilyöntejä.");
            }
            return ret;
        }


        /// <summary>
        /// Lisää virheviestin
        /// </summary>
        /// <param name="message"></param>
        public static void AddErrorMessage(string message) {
            if (errorMessages == null) {
                errorMessages = new List<string>();
            }
            errorMessages.Add(message);
        }

        /// <summary>
        ///Tulostaa virheviestit rivinvaihdoilla.
        /// </summary>
        /// <param name="deleteAfter">Default = true, tyhjentää virheviestien listan</param>
        /// <returns></returns>
        public static string PrintErrorMessages(bool deleteAfter = true) {
            string ret = "";
            try {
                foreach (string s in errorMessages) {
                    ret = ret + s + "\n";
                }
            }
            catch {
                ret = ret + "Virheviestien tulostus epäonnistui.";
            }
            if (deleteAfter) {
                errorMessages = new List<string>();
            }
            return ret;
        }

        /// <summary>
        /// Etsii käyttäjänimen listasta (kirjainten koolla ei merkitystä)
        /// </summary>
        /// <param name="username"></param>
        /// <param name="uniquecheck">Tarkistetaanko uniikkiutta, jos true, käyttäjänimen löytyessä virheilmoitus.</param>
        /// <returns></returns>
        public static bool UserFound(string username, bool uniquecheck) {
            List<string> usernames = new List<string>(); //placeholder, lista pitää lukea tietokannasta!!!
            bool ret = true;
            try {
                foreach (string s in usernames) {
                    if (username.ToLower() == s.ToLower()) {
                        ret = false;
                    }
                }
            }
            catch {
                AddErrorMessage("Käyttäjänimen etsiminen epäonnistui.");
                ret = false;
            }
            if (!ret && uniquecheck) {
                AddErrorMessage("Käyttäjänimi on jo käytössä.");
            }
            return ret;
        }

        /// <summary>
        /// Tarkistaa salasanan listasta.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="user"></param>
        /// <param name="login">Laita arvoksi true, jos kyseessä on sisäänkirjautuminen. Default=false</param>
        /// <returns></returns>
        public static bool PasswordMatch(string password, User user, bool login = false) {
            bool ret = false;
            string hash = GetHash(password + user.Salt);
            if (hash == user.Hash) {
                ret = true;
            }
            else {
                AddErrorMessage("Salasana on väärin.");
            }
            if (ret && login) {
                LoggedUser = user;
            }
            return ret;
        }

        /// <summary>
        /// Admin poistaa käyttäjän listasta. Vaatii vahvistuksen.
        /// </summary>
        /// <param name="userToDelete"></param>
        /// <param name="confirm">Vahvistus poistoon, default=false</param>
        public static void DeleteUser(User userToDelete, bool confirm) {
            if (LoggedUser.Admin && confirm && userToDelete != LoggedUser) {
                users.Remove(userToDelete);
            }
            else if (!LoggedUser.Admin){
                AddErrorMessage("Sinulla ei ole oikeuksia tähän.");
            }
            else if (userToDelete == LoggedUser) {
                AddErrorMessage("Et voi poistaa omaa käyttäjää.");
            }
        }

        /// <summary>
        /// Muokkaa valittua käyttäjää.
        /// </summary>
        /// <param name="userToEdit"></param>
        /// <param name="confirm"></param>
        /// <param name="adminNew"></param>
        /// <param name="usernameNew"></param>
        /// <param name="passwordNew"></param>
        public static void EditUser(User userToEdit, bool confirm, bool adminNew, string usernameNew, string passwordNew) {
            bool loggedNow = false;
            try {
                if (userToEdit == LoggedUser) {
                    loggedNow = true;
                }
                if ((loggedNow || LoggedUser.Admin) && confirm) {
                    //Vain admin voi muuttaa vain muiden admin-statusta
                    if (LoggedUser.Admin && !loggedNow) {
                        userToEdit.Admin = adminNew;
                    }
                    else if (LoggedUser.Admin && loggedNow) {
                        AddErrorMessage("Et voi muuttaa omaa admin-statustasi.");
                    }
                    else if (!LoggedUser.Admin) {
                        AddErrorMessage("Sinulla ei ole oikeutta muuttaa admin-statuksia.");
                    }
                    //Vain admin voi muuttaa käyttäjänimeä
                    if (LoggedUser.Admin) {
                        userToEdit.Username = usernameNew;
                    }
                    else if (!LoggedUser.Admin && usernameNew != userToEdit.Username) {
                        AddErrorMessage("Sinulla ei ole oikeuksia muuttaa käyttäjänimeä.");
                    }
                    //Suola ja hash vaihtuu vain jos muokkaa omaa salasanaa ja salasana on muuttunut.
                    if (userToEdit == LoggedUser && !PasswordMatch(passwordNew, LoggedUser))  {
                        userToEdit.Salt = GetSalt();
                        userToEdit.Hash = GetHash(passwordNew + userToEdit.Salt);
                    }
                    if (loggedNow) {
                        LoggedUser = userToEdit;
                    }
                }
            }
            catch {
                AddErrorMessage("Käyttäjän muokkaus epäonnistui.");
            }
        }

        /// <summary>
        /// Admin luo uuden käyttäjän.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="admin"></param>
        public static void CreateUser(string username, string password, bool admin) {
            if (LoggedUser.Admin) {
                string salt = GetSalt();
                string hash = GetHash(password+salt);
                User nuser = new User(username, hash, salt, admin);
            }
        }
    }
}