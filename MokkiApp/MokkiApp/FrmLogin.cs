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
    public partial class FrmLogin : Form
    {

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public FrmLogin()
        {
            InitializeComponent();
        }

        // Tämän avulla rajatonta formia voi liikutella (1/3)
        private void FrmLoginTEST_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        // Tämän avulla rajatonta formia voi liikutella (2/3)
        private void FrmLoginTEST_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        // Tämän avulla rajatonta formia voi liikutella (3/3)
        private void FrmLoginTEST_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}

        
