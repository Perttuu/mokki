using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokkiApp {
    static class ServiceUtils {
        static List<Service> serviceList;

        /// <summary>
        /// Palauttaa listan palveluista
        /// </summary>
        /// <returns></returns>
        public static List<Service> GetServices() {
            return serviceList;
        }

        /// <summary>
        /// Lukee palvelut tietokannasta
        /// </summary>
        /// <param name="OfficeList"></param>
        public static void SetServices(List<Service> ServiceList) {
            try {
                serviceList = new List<Service>();
                if (ServiceList != null) {
                    foreach (Service s in ServiceList) {
                        serviceList.Add(s);
                    }
                }
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Luo uniikin id:n palvelulle
        /// </summary>
        /// <returns></returns>
        public static int GetId() {
            try {
                int id = 1;
                List<int> idlist = new List<int>();
                foreach (Service s in serviceList) {
                    idlist.Add(s.Id);
                }
                while (idlist.Contains(id)) {
                    id++;
                }
                return id;
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
                return -1;
            }
        }

        public static void EditService(string Name, double Price, string Description, double Tax, int Type, int OfficeId, int Id) {
            if (Id > 0) {
                try {
                    Service snew = new Service(Name, Price, Description, Tax, Type, OfficeId);
                    int i = 0;
                    foreach (Service s in serviceList) {
                        if (s.Id == Id) {
                            serviceList.RemoveAt(i);
                            snew.Id = Id;
                            serviceList.Add(snew);
                        }
                        i++;
                    }
                }
                catch (Exception ex) {
                    ErrorUtils.AddErrorMessage(ex.Message);
                }
            }
            else {
                ErrorUtils.AddErrorMessage("Palvelua muokatessa tapahtui virhe: palveluId on pienempi kuin 1");
            }
        }

        /// <summary>
        /// järjestelee listan toimipisteen mukaan
        /// </summary>
        /// <param name="Decending">Onko käänteinen järjestys? default=false</param>
        public static void OrderByOffice(bool Decending = false) {
            try {
                List<Service> ordered = new List<Service>();
                if (!Decending) {
                    ordered = serviceList.OrderBy(s => s.OfficeId).ToList();
                }
                else {
                    ordered = serviceList.OrderBy(s => s.OfficeId).ToList();
                }
                if (ordered != null) {
                    serviceList = new List<Service>();
                    foreach (Service s in ordered) {
                        serviceList.Add(s);
                    }
                }
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// järjestelee listan Id:n mukaan
        /// </summary>
        /// <param name="Decending">Onko käänteinen järjestys? default=false</param>
        public static void OrderById(bool Decending = false) {
            try {
                List<Service> ordered = new List<Service>();
                if (!Decending) {
                    ordered = serviceList.OrderBy(s => s.Id).ToList();
                }
                else {
                    ordered = serviceList.OrderBy(s => s.Id).ToList();
                }
                if (ordered != null) {
                    serviceList = new List<Service>();
                    foreach (Service s in ordered) {
                        serviceList.Add(s);
                    }
                }
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// jarjestelee listan hinnan mukaan
        /// </summary>
        /// <param name="Decending">Onko käänteinen järjestys? default=false</param>
        public static void OrderByPrice(bool Decending = false) {
            try {
                List<Service> ordered = new List<Service>();
                if (!Decending) {
                    ordered = serviceList.OrderBy(s => s.Price).ToList();
                }
                else {
                    ordered = serviceList.OrderBy(s => s.Price).ToList();
                }
                if (ordered != null) {
                    serviceList = new List<Service>();
                    foreach (Service s in ordered) {
                        serviceList.Add(s);
                    }
                }
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// järjestelee listan tyypin mukaan
        /// </summary>
        /// <param name="Decending">Onko käänteinen järjestys? default=false</param>
        public static void OrderByType(bool Decending = false) {
            try {
                List<Service> ordered = new List<Service>();
                if (!Decending) {
                    ordered = serviceList.OrderBy(s => s.Type).ToList();
                }
                else {
                    ordered = serviceList.OrderBy(s => s.Type).ToList();
                }
                if (ordered != null) {
                    serviceList = new List<Service>();
                    foreach (Service s in ordered) {
                        serviceList.Add(s);
                    }
                }
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// järjestelee listan nimen mukaan
        /// </summary>
        /// <param name="Decending">Onko käänteinen järjestys? default=false</param>
        public static void OrderByName(bool Decending = false) {
            try {
                List<Service> ordered = new List<Service>();
                if (!Decending) {
                    ordered = serviceList.OrderBy(s => s.Name).ToList();
                }
                else {
                    ordered = serviceList.OrderBy(s => s.Name).ToList();
                }
                if (ordered != null) {
                    serviceList = new List<Service>();
                    foreach (Service s in ordered) {
                        serviceList.Add(s);
                    }
                }
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// poistaa palvelun listasta ID:n perusteella
        /// </summary>
        /// <param name="Id"></param>
        public static void RemoveService(int Id) {
            try {
                int i = serviceList.FindIndex(s => s.Id == Id);
                serviceList.RemoveAt(i);
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage("Palvelun poisto ei onnistunut. -- " + ex.Message);
            }
        }

        /// <summary>
        /// Etsii palvelun listasta ID:n perusteella ja palauttaa identtisen kopion
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Service GetService(int Id) {
            try {
                Service ret = new Service("", 0, "", 0, 0, 0);
                foreach (Service s in serviceList) {
                    if (s.Id == Id) {
                        ret.Name = s.Name;
                        ret.Description = s.Description;
                        ret.Id = s.Id;
                        ret.OfficeId = s.OfficeId;
                        ret.Price = s.Price;
                        ret.Tax = s.Tax;
                        ret.Type = s.Type;
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
