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
    public partial class frmCrearFactura : Form
    {
        public frmCrearFactura()
        {
            InitializeComponent();
        }

        clConexion objconexion = new clConexion();
        clFactura objfactura = new clFactura();


        private void button1_Click(object sender, EventArgs e)
        {
            frmViajeros objviajeros = new frmViajeros();
            objviajeros.Show();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                objfactura.IdVuelo = int.Parse(cmbVuelo.SelectedValue.ToString());
                objfactura.Fecha = dtpfecha.Text.Trim();


                if (objfactura.mtdRegistar() == true)
                {
                    MessageBox.Show("Pasaje Registrado");
                    objfactura.mtdCargarFactura(dgvFactura);
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

        private void frmCrearFactura_Load(object sender, EventArgs e)
        {
            objfactura.mtdCargarFactura(dgvFactura);

            clVuelo objVuelo = new clVuelo();
            cmbVuelo.DataSource = objVuelo.mtdListar();
            cmbVuelo.DisplayMember = "Modelo_Avion";
            cmbVuelo.ValueMember = "IdVuelo";
        }
    }
}
