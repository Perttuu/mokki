using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MokkiApp
{
    public partial class FrmMain : Form {

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        string[] serviceOrders = new string[5] { "toimipiste", "id", "hinta", "tyyppi", "nimi" };
        string[] officeOrders = new string[4] { "postitoimipaikka", "id", "nimi", "postinumero" };

        public FrmMain() {
            FormUtils.ShowFrmLogin();
            InitializeComponent();
            refreshCmbServiceOrder();
            refreshCmbOffice();
            refreshCmbOfficeOrder();
        }

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void btnAsiakkaatAdd_Click(object sender, EventArgs e) {

        }

        private void btnPalvelutAdd_Click(object sender, EventArgs e) {
            try {
                Service s = new Service(tbPalvelutName.Text, double.Parse(tbPalvelutPrice.Text), tbPalvelutDescription.Text, double.Parse(tbPalvelutAlv.Text), int.Parse(tbPalvelutType.Text), 1);
                ServiceUtils.AddService(s);
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        private void btnToimiAdd_Click(object sender, EventArgs e) {
            try {
                Office o = new Office(tbToimiName.Text, tbToimiZip.Text, tbToimiCity.Text, tbToimiStreetAdress.Text, tbToimiEmail.Text, tbToimiPhone.Text);
                OfficeUtils.AddOffice(o);
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }
        

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            if (UserUtils.LoggedUser == null) {
                this.Close();
            }
        }

        private void cmbOffice_Click(object sender, EventArgs e) {
            refreshCmbOffice();
        }

        private void refreshCmbOffice() {
            try {
                List<Office> offices = OfficeUtils.GetOffices();
                List<string> names = new List<string>();
                foreach (Office o in offices) {
                    names.Add(o.Name);
                }
                cmbOffice.DataSource = names;
            }
            catch (Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);

                //placeholder
                List<string> names = new List<string>();
                names.Add("Kuopio");
                names.Add("Joensuu");
                names.Add("Varkaus");
                cmbOffice.DataSource = names;
            }
        }

        private void refreshCmbServiceOrder() {
            cmbServiceOrder.DataSource = serviceOrders;
        }

        private void refreshCmbOfficeOrder() {
            cmbOfficeOrder.DataSource = officeOrders;
        }

        private void refreshUserManagement() {
            
        }
    }
}
