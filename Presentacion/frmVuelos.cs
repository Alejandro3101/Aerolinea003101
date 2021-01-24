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
    public partial class frmVuelos : Form
    {
        public frmVuelos()
        {
            InitializeComponent();
        }

        clConexion objconexion = new clConexion();
        clVuelo objvuelo = new clVuelo();

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                objvuelo.Capacidad = txtCapacidad.Text.Trim();
                objvuelo.Modelo_Avion = txtModelo.Text.Trim();
                objvuelo.IdRuta = int.Parse(cmbRuta.SelectedValue.ToString());
                objvuelo.IdCompañia = int.Parse(cmbCompañia.SelectedValue.ToString());
                objvuelo.IdAvion = int.Parse(cmbAvion.SelectedValue.ToString());



                if (objvuelo.mtdRegistrar() == true)
                {
                    MessageBox.Show("Registro Exitoso");
                    objvuelo.mtdcargarVuelos(dgvVuelo);

                }
                else
                {
                    MessageBox.Show("Error ");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Complete todos los campos");
            }
           
        }

        private void frmVuelos_Load(object sender, EventArgs e)
        {
            objvuelo.mtdcargarVuelos(dgvVuelo);

            clRuta objRuta = new clRuta();
            cmbRuta.DataSource = objRuta.mtdListar();
            cmbRuta.DisplayMember = "Ruta";
            cmbRuta.ValueMember = "IdRuta";


            clAerolinea objAerolinea = new clAerolinea();
            cmbCompañia.DataSource = objAerolinea.mtdListar();
            cmbCompañia.DisplayMember = "Nombre";
            cmbCompañia.ValueMember = "IdCompañia";


            clAvion objAvion = new clAvion();
            cmbAvion.DataSource = objAvion.mtdListar();
            cmbAvion.DisplayMember = "Numero";
            cmbAvion.ValueMember = "IdAvion";





        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                objvuelo.Capacidad = txtCapacidad.Text;
                objvuelo.Modelo_Avion = txtModelo.Text;
                objvuelo.IdRuta = int.Parse(cmbRuta.SelectedValue.ToString());
                objvuelo.IdCompañia = int.Parse(cmbCompañia.SelectedValue.ToString());
                objvuelo.IdAvion = int.Parse(cmbAvion.SelectedValue.ToString());
                objvuelo.IdVuelo = int.Parse(txtId.Text);

                Boolean res = objvuelo.mtdActualiazar();

                if (res == true)
                {
                    MessageBox.Show("Datos Actualizados");
                    objvuelo.mtdcargarVuelos(dgvVuelo);
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

        private void dgvVuelo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int linea = e.RowIndex;
                string Capacidad = dgvVuelo.Rows[linea].Cells["Capacidad"].Value.ToString();
                txtCapacidad.Text = Capacidad;
                string Modelo_Avion = dgvVuelo.Rows[linea].Cells["Modelo_Avion"].Value.ToString();
                txtModelo.Text = Modelo_Avion;
                string IdRuta = dgvVuelo.Rows[linea].Cells["IdRuta"].Value.ToString();
                cmbRuta.Text = IdRuta;
                string IdCompañia = dgvVuelo.Rows[linea].Cells["IdCompañia"].Value.ToString();
                cmbCompañia.SelectedValue = IdCompañia;
                string IdAvion = dgvVuelo.Rows[linea].Cells["IdAvion"].Value.ToString();
                cmbAvion.SelectedValue = IdAvion;
                string IdVuelo = dgvVuelo.Rows[linea].Cells["IdVuelo"].Value.ToString();
                txtId.Text = IdVuelo;

            }
            catch (Exception)
            {

                throw;
            }
            


        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

            if (txtFiltro.Text != "")
            {
                dgvVuelo.CurrentCell = null;
                foreach (DataGridViewRow r in dgvVuelo.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dgvVuelo.Rows)
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
                objvuelo.mtdcargarVuelos(dgvVuelo);
            }

        }

        private void txtCapacidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                clClientes.mtdvalidarnum(e);

                errorProvider1.SetError(txtCapacidad, "Solo numeros");
                btnRegistrar.Enabled = false;

                if (int.Parse(txtCapacidad.Text.ToString()) >= 0)
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


