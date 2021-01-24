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
    public partial class btnbuscar : Form
    {

        public string Fecha { get; set; }

        clEstadoVuelos objestadV = new clEstadoVuelos();
        bool Retornodelabusqueda;


        public btnbuscar()
        {
            InitializeComponent();
        }

        private void frmEstadoVuelo_Load(object sender, EventArgs e)
        {
            objestadV.mtdcargardatosvuelos(dgvVueloEstado);
        }




        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                dgvVueloEstado.CurrentCell = null;
                foreach (DataGridViewRow r in dgvVueloEstado.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dgvVueloEstado.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if ((c.Value.ToString().IndexOf(textBox1.Text) == 0))

                        {
                            r.Visible = true;
                            break;

                        }

                    }

                }


            }
            else
            {
                objestadV.mtdcargardatosvuelos(dgvVueloEstado);
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //    List<clEstadoVuelos> listaestadovuelo = new List<clEstadoVuelos>();

        //    listaestadovuelo = objestadV.mtdmtdbusqudafecha();

        //    bool Buscar = false;

        //    if (fecha.Value.Date.ToString() == "" ) 
        //    {
        //        MessageBox.Show("Seleccione una fecha");

        //    }
        //    else
        //    {
        //        for (int i = 0; i < listaestadovuelo.Count; i++)
        //        {
        //            Retornodelabusqueda = false;
        //            Buscar = true;
        //            Retornodelabusqueda = true;

        //            break;
        //        }

        //    }
        //    if (Retornodelabusqueda != true)
        //    {
        //        MessageBox.Show("Ningun Vuelo Registrado");
        //        fecha.ResetText();
        //    }

        //    frmBusquedaV objbusquedav = new frmBusquedaV();

        //    objbusquedav.Fecha = fecha.Value.Date.ToString();

        //    if (Buscar == true)
        //    {
        //        objbusquedav.Show();
        //    }





        //}

        //private void fecha_ValueChanged(object sender, EventArgs e)
        //{

        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}


