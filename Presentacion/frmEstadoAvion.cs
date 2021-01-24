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
    public partial class frmEstadoAvion : Form
    {
        clEstadoAvion objestadoavion = new clEstadoAvion();
        

        public frmEstadoAvion()
        {
            InitializeComponent();
        }

        private void frmEstadoAvion_Load(object sender, EventArgs e)
        {
            objestadoavion.mtdCargarEstadoAvion(dgvEstadoavion);
        }

       

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEstadoAvion_TextChanged(object sender, EventArgs e)
        {

            if (txtEstadoAvion.Text != "")
            {
                dgvEstadoavion.CurrentCell = null;
                foreach (DataGridViewRow r in dgvEstadoavion.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dgvEstadoavion.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if ((c.Value.ToString().IndexOf(txtEstadoAvion.Text) == 0))

                        {
                            r.Visible = true;
                            break;

                        }

                    }

                }


            }
            else
            {
                objestadoavion.mtdCargarEstadoAvion(dgvEstadoavion);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
