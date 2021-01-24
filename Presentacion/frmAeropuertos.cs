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
    public partial class frmAeropuertos : Form
    {

        clAeropuertos objaeropuertos = new clAeropuertos();

        public frmAeropuertos()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmAeropuertos_Load(object sender, EventArgs e)
        {
            objaeropuertos.mtdcargaraeropuertos(dgvAeropuertos);
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

            if (txtFiltro.Text != "")
            {
                dgvAeropuertos.CurrentCell = null;
                foreach (DataGridViewRow r in dgvAeropuertos.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dgvAeropuertos.Rows)
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
                objaeropuertos.mtdcargaraeropuertos(dgvAeropuertos);
            }
        }
    }
}
