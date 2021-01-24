using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aerolinea1.Datos;

namespace Aerolinea1.Presentacion
{
    public partial class frmInformeRegisroPasaje : Form
    {

        clConexion objconexion = new clConexion();
        clPasaje objpasaje = new clPasaje();

        public frmInformeRegisroPasaje()
        {
            InitializeComponent();
        }

        private void frmInformeRegisroPasaje_Load(object sender, EventArgs e)
        {
            objpasaje.mtdCargarinformePasaje(dgvInformePasaje);
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

            if (txtFiltro.Text != "")
            {
                dgvInformePasaje.CurrentCell = null;
                foreach (DataGridViewRow r in dgvInformePasaje.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dgvInformePasaje.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if ((c.Value.ToString().IndexOf(txtFiltro.Text) == 0))

                        {
                            r.Visible = true;
                            break;

                        }

                    }

                }


            }
            else
            {
                objpasaje.mtdCargarinformePasaje(dgvInformePasaje);
            }
        }
    }
}
