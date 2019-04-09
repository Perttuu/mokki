using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MokkiApp {
    public partial class FrmLoginTEMP : Form {
        public FrmLoginTEMP() {
            InitializeComponent();
        }

        //tbPassword kohdassa näppäimen painaisu
        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                btnOk_Click(sender, e);
            }
        }

        //OK-napin click
        private void btnOk_Click(object sender, EventArgs e) {
            try {
                if (UserUtils.LegitPassword(tbPassword.Text) && UserUtils.UserFound(tbUsername.Text, true)) {
                    UserUtils.CreateUser(tbUsername.Text, tbPassword.Text, cbAdmin.Checked);
                    lblHash.Text = UserUtils.LoggedUser.Hash;
                    lblSalt.Text = UserUtils.LoggedUser.Salt;
                }
            }
            catch {
                UserUtils.AddErrorMessage("Käyttäjän luominen epäonnistui.");
            }
            //Printtaa aina kaikki virheviestit (saa muuttaa)
            lblError.Text = UserUtils.PrintErrorMessages();
        }
    }
}
