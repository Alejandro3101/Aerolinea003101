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
    public partial class frmUsuarios : Form
    {
        clConexion objconexion = new clConexion();
        clUsuario objusuario = new clUsuario();

        public frmUsuarios()
        {
            InitializeComponent();

        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            objusuario.mtdcargarUsuario(dgvUsuario);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            try
            {
                objusuario.Documento = txtDocumento.Text.Trim();
                objusuario.Nombre = txtNombre.Text.Trim();
                objusuario.Apellido = txtApellidos.Text.Trim();
                objusuario.Correo = txtcorreo.Text.Trim();
                objusuario.Clave = txtclave1.Text.Trim();
                objusuario.Rol = cmbRol.Text.Trim();

                if (objusuario.mtdRegistrar() == true)
                {
                    MessageBox.Show("Usuario Registrado");
                    objusuario.mtdcargarUsuario(dgvUsuario);
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
                objusuario.Documento = txtDocumento.Text.Trim();
                objusuario.Nombre = txtNombre.Text.Trim();
                objusuario.Apellido = txtApellidos.Text.Trim();
                objusuario.Correo = txtcorreo.Text.Trim();
                objusuario.Clave = txtclave1.Text.Trim();
                objusuario.Rol = cmbRol.Text.Trim();
                objusuario.IdUsuario = int.Parse(txtId.Text);

                Boolean res = objusuario.mtdActualizar();

                if (res == true)
                {
                    MessageBox.Show("Usuario Actualizado");
                    objusuario.mtdcargarUsuario(dgvUsuario);
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

           

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtDocumento.Text = dgvUsuario.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgvUsuario.CurrentRow.Cells[2].Value.ToString();
                txtApellidos.Text = dgvUsuario.CurrentRow.Cells[3].Value.ToString();
                txtcorreo.Text = dgvUsuario.CurrentRow.Cells[4].Value.ToString();
                txtclave1.Text = dgvUsuario.CurrentRow.Cells[5].Value.ToString();
                cmbRol.Text = dgvUsuario.CurrentRow.Cells[6].Value.ToString();
                txtId.Text = dgvUsuario.CurrentRow.Cells["IdUsuario"].Value.ToString();
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
                dgvUsuario.CurrentCell = null;
                foreach (DataGridViewRow r in dgvUsuario.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dgvUsuario.Rows)
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
                objusuario.mtdcargarUsuario(dgvUsuario);
            }
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                clUsuario.mtdvalidarnum(e);

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

        private void txtcorreo_TextChanged(object sender, EventArgs e)
        {
            if (clUsuario.mtdvalidaremail(txtcorreo.Text) == false)
            {
                errorProvider1.SetError(txtcorreo, "ingrese un correo valido");
                txtcorreo.Focus();
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
