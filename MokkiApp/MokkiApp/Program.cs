using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MokkiApp {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try {
                Application.Run(new FrmMain());
            }
            catch {
                ErrorUtils.AddErrorMessage("Jokin meni pahasti pieleen, ohjelma ei toiminut.");
            }
            ErrorUtils.WriteToFile(); //Kirjoittaa kaikki virheet tiedostoon
        }
    }
}
