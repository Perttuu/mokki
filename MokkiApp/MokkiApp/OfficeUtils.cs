using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokkiApp {
    static class OfficeUtils {
        static List<Office> officeList;

        /// <summary>
        /// Palauttaa listan toimipisteistä
        /// </summary>
        /// <returns></returns>
        public static List<Office> GetOffices() {
            return officeList;
        }

        /// <summary>
        /// Lukee toimipisteet tietokannasta
        /// </summary>
        /// <param name="OfficeList"></param>
        public static void SetOffices(List<Office> OfficeList) {
            try {
                officeList = new List<Office>();
                if (OfficeList != null) {
                    foreach (Office o in OfficeList) {
                        officeList.Add(o);
                    }
                }
            }
            catch(Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Luo automaattisen, uniikin ID:n
        /// </summary>
        /// <returns></returns>
        public static int GetId() {
            try {
                int id = 1;
                List<int> idlist = new List<int>();
                foreach (Office o in officeList) {
                    idlist.Add(o.Id);
                }
                while (idlist.Contains(id)) {
                    id++;
                }
                return id;
            }
            catch(Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Muokkaa toimipistettä.
        /// </summary>
        /// <param name="Zip">!null</param>
        /// <param name="City">!null</param>
        /// <param name="StreetAddress">!null</param>
        /// <param name="Description"></param>
        /// <param name="Email"></param>
        /// <param name="Phone"></param>
        /// <param name="Id">!null, > 0</param>
        public static void EditOffice(string Name, string Zip, string City, string StreetAddress, string Email, string Phone, int Id) {
            try {
                if (!(Name == "" || Name == null || Zip == "" || City == "" || StreetAddress == "" || Zip == null || City == null || StreetAddress == null || Id < 1)) {
                    Office o = new Office(Name, Zip, City, StreetAddress, Email, Phone);
                    int i = 0;
                    foreach (Office off in officeList) {
                        if (off.Id == Id) {
                            officeList.RemoveAt(i);
                            o.Id = Id;
                            officeList.Add(o);
                        }
                        i++;
                    }
                }
            }
            catch(Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Järjestelee listan kaupungin mukaan
        /// </summary>
        /// <param name="Decending">Onko käänteinen järjestys? default=false</param>
        public static void OrderByCity(bool Decending = false) {
            try {
                List<Office> ordered = new List<Office>();
                if (!Decending) {
                    ordered = officeList.OrderBy(o => o.PostalArea).ToList();
                }
                else {
                    ordered = officeList.OrderBy(o => o.PostalArea).ToList();
                }
                if (ordered != null) {
                    officeList = new List<Office>();
                    foreach (Office o in ordered) {
                        officeList.Add(o);
                    }
                }
            }
            catch(Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Järjestelee listan Id:n mukaan
        /// </summary>
        /// <param name="Decending">Onko käänteinen järjestys? default=false</param>
        public static void OrderById(bool Decending = false) {
            try {
                List<Office> ordered = new List<Office>();
                if (!Decending) {
                    ordered = officeList.OrderBy(o => o.Id).ToList();
                }
                else {
                    ordered = officeList.OrderBy(o => o.Id).ToList();
                }
                if (ordered != null) {
                    officeList = new List<Office>();
                    foreach (Office o in ordered) {
                        officeList.Add(o);
                    }
                }
            }
            catch(Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Järjestelee listan postinumeron mukaan
        /// </summary>
        /// <param name="Decending">Onko käänteinen järjestys? default=false</param>
        public static void OrderByZip(bool Decending = false) {
            try {
                List<Office> ordered = new List<Office>();
                if (!Decending) {
                    ordered = officeList.OrderBy(o => o.Zip).ToList();
                }
                else {
                    ordered = officeList.OrderBy(o => o.Zip).ToList();
                }
                if (ordered != null) {
                    officeList = new List<Office>();
                    foreach (Office o in ordered) {
                        officeList.Add(o);
                    }
                }
            }
            catch(Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Järjestelee listan nimen mukaan
        /// </summary>
        /// <param name="Decending">Onko käänteinen järjestys? default=false</param>
        public static void OrderByName(bool Decending = false) {
            try {
                List<Office> ordered = new List<Office>();
                if (!Decending) {
                    ordered = officeList.OrderBy(o => o.Name).ToList();
                }
                else {
                    ordered = officeList.OrderBy(o => o.Name).ToList();
                }
                if (ordered != null) {
                    officeList = new List<Office>();
                    foreach (Office o in ordered) {
                        officeList.Add(o);
                    }
                }
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Poistaa toimipisteen tunnistamalla ID:n
        /// </summary>
        /// <param name="Id"></param>
        public static void RemoveOffice(int Id) {
            try {
                OrderById();
                int i = officeList.FindIndex(o => o.Id == Id);
                officeList.RemoveAt(i);
            }
            catch(Exception ex) {
                ErrorUtils.AddErrorMessage("Toimipisteen poisto ei onnistunut. -- " + ex.Message);
            }
        }

        /// <summary>
        /// Hakee tietyn toimipisteen ID:n perusteella tulostusta tms varten
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Office GetOffice(int Id) {
            try {
                Office ret = new Office("", "", "", "", "", "");
                foreach (Office o in officeList) {
                    if (o.Id == Id) {
                        ret.PostalArea = o.PostalArea;
                        ret.Email = o.Email;
                        ret.Id = o.Id;
                        ret.Phone = o.Phone;
                        ret.StreetAddress = o.StreetAddress;
                        ret.Zip = o.Zip;
                        break;
                    }
                }
                return ret;
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
                return null;
            }
        }
    }
}
