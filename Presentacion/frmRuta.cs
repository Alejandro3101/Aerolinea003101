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
    public partial class frmRuta : Form
    {
        public frmRuta()
        {
            InitializeComponent();
        }

        clConexion objConexion = new clConexion();
        clRuta objRuta = new clRuta();


        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            try
            {
                objRuta.Fecha = dtpfecha.Text.Trim();
                objRuta.HoraSalida = dtpsalida.Text.Trim();
                objRuta.HoraLlegada = dtpllegada.Text.Trim();
                objRuta.IdOrigen = int.Parse(cmbOrigen.SelectedValue.ToString());
                objRuta.IdDestino = int.Parse(cmbDestino.SelectedValue.ToString());
                //objRuta.IdRuta = int.Parse(cmbUsuario.SelectedValue.ToString());

                if (objRuta.mtdRegistrar() == true)
                {
                    MessageBox.Show("Pasaje Registrado");
                    objRuta.mtdCargarRuta(dgvRuta);
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

       

        private void frmRuta_Load(object sender, EventArgs e)
        {
            clOrigen objOrigen = new clOrigen();
            cmbOrigen.DataSource = objOrigen.mtdListar();
            cmbOrigen.DisplayMember = "Ciudad";
            cmbOrigen.ValueMember = "IdOrigen";


            clDestino objDestino = new clDestino();
            cmbDestino.DataSource = objDestino.mtdListar();
            cmbDestino.DisplayMember = "Ciudad";
            cmbDestino.ValueMember = "IdDestino";


            objRuta.mtdCargarRuta(dgvRuta);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                objRuta.Fecha = dtpfecha.Text.Trim();
                objRuta.HoraSalida = dtpsalida.Text.Trim();
                objRuta.HoraLlegada = dtpllegada.Text.Trim();
                objRuta.IdOrigen = int.Parse(cmbOrigen.SelectedValue.ToString());
                objRuta.IdDestino = int.Parse(cmbDestino.SelectedValue.ToString());
                objRuta.IdRuta = int.Parse(txtId.Text);

                Boolean res = objRuta.mtdActualizar();

                if (res == true)
                {
                    MessageBox.Show("Datos Actualizados");
                    objRuta.mtdCargarRuta(dgvRuta);

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

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

            if (txtFiltro.Text != "")
            {
                dgvRuta.CurrentCell = null;
                foreach (DataGridViewRow r in dgvRuta.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dgvRuta.Rows)
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
                objRuta.mtdCargarRuta(dgvRuta);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRuta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                dtpfecha.Text = dgvRuta.CurrentRow.Cells[1].Value.ToString();
                dtpsalida.Text = dgvRuta.CurrentRow.Cells[2].Value.ToString();
                dtpllegada.Text = dgvRuta.CurrentRow.Cells[3].Value.ToString();
                cmbOrigen.Text = dgvRuta.CurrentRow.Cells[4].Value.ToString();
                cmbDestino.Text = dgvRuta.CurrentRow.Cells[5].Value.ToString();
                txtId.Text = dgvRuta.CurrentRow.Cells["IdRuta"].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
