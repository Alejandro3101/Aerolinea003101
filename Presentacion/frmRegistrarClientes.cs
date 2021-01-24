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
using Aerolinea1.Presentacion;

namespace Aerolinea1.Presentacion
{
    public partial class frmRegistrarClientes : Form
    {

        clClientes objcliente = new clClientes();
        clConexion objconexion = new clConexion();

        public frmRegistrarClientes()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegistrarClientes_Load(object sender, EventArgs e)
        {
           
            objcliente.mtdcargarPersonas(dgvCliente);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                objcliente.Documento = txtDocumento.Text;
                objcliente.Nombre = txtNombre.Text;
                objcliente.Apellido = txtApellidos.Text;
                objcliente.Edad = txtedad.Text;
                objcliente.Telefono = txtTelefono.Text;
                objcliente.Email = txtemail.Text;
                objcliente.Tipo = cmbTipo.Text;



                int registro = objcliente.mtdRegistrar();
                if (registro == 1)
                {
                    MessageBox.Show("Datos Insertados");
                    objcliente.mtdcargarPersonas(dgvCliente);

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

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            //Lista los datos en los textbox para modificar 
            try
            {
                txtDocumento.Text = dgvCliente.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgvCliente.CurrentRow.Cells[2].Value.ToString();
                txtApellidos.Text = dgvCliente.CurrentRow.Cells[3].Value.ToString();
                txtedad.Text = dgvCliente.CurrentRow.Cells[4].Value.ToString();
                txtTelefono.Text = dgvCliente.CurrentRow.Cells[5].Value.ToString();
                txtemail.Text = dgvCliente.CurrentRow.Cells[6].Value.ToString();
                cmbTipo.Text = dgvCliente.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {

                clClientes.mtdvalidarnum(e);

                errorProvider1.SetError(txtDocumento, "Solo numeros");
                btnRegistrar.Enabled = false;

                if (int.Parse(txtDocumento.Text.ToString()) >= 0)
                {
                    errorProvider1.Clear();
                    btnRegistrar.Enabled = true;
                }

            }
            catch (Exception)
            {


            }
        }

        //private void btnEliminar_Click(object sender, EventArgs e)
        //{
        //    objcliente.Documento = txtDocumento.Text;
        //    int registro = objcliente.mtdEliminar();

        //    if (registro == 1)
        //    {
        //        MessageBox.Show("Datos Eliminados");
        //        objcliente.mtdcargarPersonas(dgvCliente);

        //    }
        //    else
        //    {
        //        MessageBox.Show("Error ! ");
        //    }
        //}

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                objcliente.Documento = txtDocumento.Text;
                objcliente.Nombre = txtNombre.Text;
                objcliente.Apellido = txtApellidos.Text;
                objcliente.Edad = txtedad.Text;
                objcliente.Telefono = txtTelefono.Text;
                objcliente.Email = txtemail.Text;
                objcliente.Tipo = cmbTipo.Text;

                int registro = objcliente.mtdEditar();

                if (registro == 1)
                {
                    MessageBox.Show("Datos Actualizados");
                    objcliente.mtdcargarPersonas(dgvCliente);

                }
                else
                {
                    MessageBox.Show("Error ");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Seleccione el campo que desea Editar");
            }
           
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if(txtFiltro.Text!="")
                {
                dgvCliente.CurrentCell = null;
                foreach (DataGridViewRow r in dgvCliente.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dgvCliente.Rows)
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
                objcliente.mtdcargarPersonas(dgvCliente);
            }

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                clClientes.mtdvalidarnum(e);

                errorProvider1.SetError(txtTelefono, "Solo numeros");
                btnRegistrar.Enabled = false;

                if (int.Parse(txtTelefono.Text.ToString()) >= 0)
                {
                    errorProvider1.Clear();
                    btnRegistrar.Enabled = true;
                }

            }
            catch (Exception)
            {


            }
        }

        private void txtedad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                clClientes.mtdvalidarnum(e);

                errorProvider1.SetError(txtedad, "Solo numeros");
                btnRegistrar.Enabled = false;

                if (int.Parse(txtedad.Text.ToString()) >= 0)
                {
                    errorProvider1.Clear();
                    btnRegistrar.Enabled = true;
                }

            }
            catch (Exception)
            {


            }
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            if (clUsuario.mtdvalidaremail(txtemail.Text) == false)
            {
                errorProvider1.SetError(txtemail, "ingrese un correo valido");
                txtemail.Focus();
                btnRegistrar.Enabled = false;
            }
            else
            {
                errorProvider1.Clear();
                btnRegistrar.Enabled = true;
            }
        }
    }
}
    



