using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MokkiApp {
    static class FormUtils {
        static Form frmLogin;

        public static void CloseFrmLogin() {
            frmLogin.Close();
        }

        public static void ShowFrmLogin() {
            frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }
        
    }
}
