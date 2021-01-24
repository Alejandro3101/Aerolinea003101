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
    public partial class frmAvion : Form
    {
        public frmAvion()
        {
            InitializeComponent();
        }

        clConexion objconexion = new clConexion();
        clAvion objavion = new clAvion();
      
        private void frmAvion_Load(object sender, EventArgs e)
        {
            objavion.mtdCargarAvion(dgvAvion);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

                objavion.Placa = txtPlaca.Text.Trim();
                objavion.Numero = txtNumero.Text.Trim();
                objavion.Estado = cmbEstado.Text.Trim();

                if (objavion.mtdRegistrar() == true)
                {
                    MessageBox.Show("Avion Registrado");
                    objavion.mtdCargarAvion(dgvAvion);
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Complete todos los campos");
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                objavion.Placa = txtPlaca.Text.Trim();
                objavion.Numero = txtNumero.Text.Trim();
                objavion.Estado = cmbEstado.Text.Trim();
                objavion.IdAvion = int.Parse(txtId.Text);

                Boolean res = objavion.mtdActualizar();

                if (res == true)
                {
                    MessageBox.Show("Avion Actualizado");
                    objavion.mtdCargarAvion(dgvAvion);
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Seleccione el campo que desea Editar");
            }
        }

        private void dgvAvion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Lista los datos en los textbox para modificar 
            try
            {
                txtPlaca.Text = dgvAvion.CurrentRow.Cells[1].Value.ToString();
                txtNumero.Text = dgvAvion.CurrentRow.Cells[2].Value.ToString();
                cmbEstado.Text = dgvAvion.CurrentRow.Cells[3].Value.ToString();
                txtId.Text = dgvAvion.CurrentRow.Cells["IdAvion"].Value.ToString();


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

            if (txtFiltro.Text != "")
            {
                dgvAvion.CurrentCell = null;
                foreach (DataGridViewRow r in dgvAvion.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dgvAvion.Rows)
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
                objavion.mtdCargarAvion(dgvAvion);
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {

                clUsuario.mtdvalidarnum(e);

                errorProvider1.SetError(txtNumero, "Solo numeros");
                btnRegistrar.Enabled = false;

                if (int.Parse(txtNumero.Text.ToString()) >= 0)
                {
                    errorProvider1.Clear();
                    btnRegistrar.Enabled = true;
                }

            }
            catch (Exception)
            {


            }
        }
    }
}
