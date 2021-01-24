using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerolinea1.Datos;
using System.Windows.Forms;

namespace Aerolinea1.Presentacion
{
    public partial class frmPasaje : Form
    {
        public frmPasaje()
        {
            InitializeComponent();
        }

        clConexion objConexion = new clConexion();
        clPasaje objPasaje = new clPasaje();

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            try
            {
                objPasaje.Clase = cmbClase.Text.Trim();
                objPasaje.Asiento = txtAsiento.Text.Trim();
                objPasaje.Valor = txtValor.Text.Trim();
                objPasaje.IdCliente = int.Parse(cmbCliente.SelectedValue.ToString());
                objPasaje.IdVuelo = int.Parse(cmbVuelo.SelectedValue.ToString());
                objPasaje.IdUsuario = int.Parse(cmbUsuario.SelectedValue.ToString());

                if (objPasaje.mtdRegistrar() == true)
                {
                    MessageBox.Show("Pasaje Registrado");
                    objPasaje.mtdCargarPasaje(dgvPasaje);
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
                objPasaje.Clase = cmbClase.Text.Trim();
                objPasaje.Asiento = txtAsiento.Text.Trim();
                objPasaje.Valor = txtValor.Text.Trim();
                objPasaje.IdCliente = int.Parse(cmbCliente.SelectedValue.ToString());
                objPasaje.IdVuelo = int.Parse(cmbVuelo.SelectedValue.ToString());
                objPasaje.IdUsuario = int.Parse(cmbUsuario.SelectedValue.ToString());
                objPasaje.IdPasaje = int.Parse(txtId.Text);

                Boolean res = objPasaje.mtdActualizar();

                if (res == true)
                {
                    MessageBox.Show("Datos Actualizados");
                    objPasaje.mtdCargarPasaje(dgvPasaje);

                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Seleccione el campo que desea editar");
            }
            
        }

        private void frmPasaje_Load(object sender, EventArgs e)
        {
            mtdCargar();


            clClientes objclientes = new clClientes();
            cmbCliente.DataSource = objclientes.mtdListar();
            cmbCliente.DisplayMember = "Documento";
            cmbCliente.ValueMember = "IdCliente";


            clVuelo objVuelo = new clVuelo();
            cmbVuelo.DataSource = objVuelo.mtdListar();
            cmbVuelo.DisplayMember = "Modelo_Avion";
            cmbVuelo.ValueMember = "IdVuelo";

            clUsuario objusuario = new clUsuario();
            cmbUsuario.DataSource = objusuario.mtdListar();
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "IdUsuario";



        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPasaje_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //Lista los datos en los textbox para modificar 
            try
            {
                cmbClase.Text = dgvPasaje.CurrentRow.Cells[1].Value.ToString();
                txtAsiento.Text = dgvPasaje.CurrentRow.Cells[2].Value.ToString();
                txtValor.Text = dgvPasaje.CurrentRow.Cells[3].Value.ToString();
                cmbCliente.SelectedValue = dgvPasaje.CurrentRow.Cells[4].Value.ToString();
                cmbVuelo.SelectedValue = dgvPasaje.CurrentRow.Cells[5].Value.ToString();
                cmbUsuario.SelectedValue = dgvPasaje.CurrentRow.Cells[6].Value.ToString();
                txtId.Text = dgvPasaje.CurrentRow.Cells["IdPasaje"].Value.ToString();


            }
            catch (Exception)
            {

                throw;
            }
        }
        public void mtdCargar()
        {
            objPasaje.mtdCargarPasaje(dgvPasaje);
            this.dgvPasaje.Columns["IdCliente"].Visible = false;
            this.dgvPasaje.Columns["IdUsuario"].Visible = false;
            this.dgvPasaje.Columns["IdVuelo"].Visible = false;

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

            if (txtFiltro.Text != "")
            {
                dgvPasaje.CurrentCell = null;
                foreach (DataGridViewRow r in dgvPasaje.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dgvPasaje.Rows)
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
                objPasaje.mtdCargarPasaje(dgvPasaje);
            }

        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            frmTicket objTicket = new frmTicket();
            objTicket.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCrearFactura objCreaFactura = new frmCrearFactura();
            objCreaFactura.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

