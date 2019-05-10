using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// DEFAULT

namespace MokkiApp {
    static class ErrorUtils {
        static string filePath = Directory.GetCurrentDirectory() + "\\ErrorReports.txt";
        static List<string> ErrorMessages = new List<string>();

        /// <summary>
        /// Lisää virheviestin listaan ajankohdan kanssa.
        /// </summary>
        /// <param name="Message"></param>
        public static void AddErrorMessage(string Message) {
            ErrorMessages.Add(System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString() + " -- " + Message);
        }

        /// <summary>
        /// Palauttaa virheviestit
        /// </summary>
        /// <returns></returns>
        public static List<string> GetErrorMessages() {
            List<string> ret = new List<string>();
            foreach (string s in ErrorMessages) {
                ret.Add(s);
            }
            return ret;
        }

        /// <summary>
        /// Tyhjentää virheviestilistan
        /// </summary>
        public static void Clear() {
            ErrorMessages = new List<string>();
        }

        public static void WriteToFile() {
            StreamWriter sw = new StreamWriter(filePath, true);
            foreach (string s in ErrorMessages) {
                sw.WriteLine(s);
            }
            sw.Close();
        }
    }
}
