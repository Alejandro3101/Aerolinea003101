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
    public partial class frmViajeros : Form
    {
        public frmViajeros()
        {
            InitializeComponent();
        }


        clConexion objconexion = new clConexion();
        clViajeros objviajeros = new clViajeros();



        private void button1_Click(object sender, EventArgs e)
        {
            frmFactura objFactura = new frmFactura();
            objFactura.Show();
        }

        private void frmViajeros_Load(object sender, EventArgs e)
        {
            try
            {
                clClientes objclientes = new clClientes();
                cmbCliente.DataSource = objclientes.mtdListar();
                cmbCliente.DisplayMember = "Documento";
                cmbCliente.ValueMember = "IdCliente";

                clViajeros objviajeros = new clViajeros();
                cmbFactura.DataSource = objviajeros.mtdListar();
                cmbFactura.DisplayMember = "IdFactura";
                cmbFactura.ValueMember = "IdViajeros";

                objviajeros.mtdcatgarViajeros(dgvViajeros);
            }
            catch (Exception)
            {

                MessageBox.Show("complete todos los campos");
            }
            
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

            objviajeros.ValorViajero = int.Parse(txtvalorviajeros.Text);
            objviajeros.IdFactura = int.Parse(cmbFactura.SelectedValue.ToString());
            objviajeros.IdCliente = int.Parse(cmbCliente.SelectedValue.ToString());


            int registro = objviajeros.mtdRegistrar();


            if (registro == 1)
            {
                MessageBox.Show("Registro exitoso");
                objviajeros.mtdcatgarViajeros(dgvViajeros);

            }
            else
            {
                MessageBox.Show("Error");
            }






        }

        private void txtvalorviajeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                clClientes.mtdvalidarnum(e);

                errorProvider1.SetError(txtvalorviajeros, " Cantidad en Valor Numerico");
                btnCrear.Enabled = false;

                if (int.Parse(txtvalorviajeros.Text.ToString()) >= 0)
                {
                    errorProvider1.Clear();
                    btnCrear.Enabled = true;
                }

            }
            catch (Exception)
            {


            }
        }
    }
}

