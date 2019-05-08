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
    public partial class FrmMain : Form
    {

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public FrmMain()
        {
            FormUtils.ShowFrmLogin();
            InitializeComponent();
            if (UserUtils.LoggedUser == null) {
                this.Close();
            }
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
            catch(Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        private void btnToimiAdd_Click(object sender, EventArgs e) {
            try {
                Office o = new Office(tbToimiName.Text, tbToimiZip.Text, tbToimiCity.Text, tbToimiStreetAdress.Text, tbToimiEmail.Text, tbToimiPhone.Text);
                OfficeUtils.AddOffice(o);
            }
            catch(Exception ex) {
                ErrorUtils.AddErrorMessage(ex.Message);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) {
            ErrorUtils.WriteToFile();
        }
    }
}
