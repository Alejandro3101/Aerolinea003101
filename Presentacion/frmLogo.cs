using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aerolinea1.Presentacion
{
    public partial class frmLogo : Form
    {
        public frmLogo()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void frmLogo_Load(object sender, EventArgs e)
        {
            lblHora.BackColor = Color.Transparent;
            lblHora.Parent = fondo;

            lblFecha.BackColor = Color.Transparent;
            lblFecha.Parent = fondo;
        }
    }
}
