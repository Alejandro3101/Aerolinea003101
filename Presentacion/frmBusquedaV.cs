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
    public partial class frmBusquedaV : Form
    {
        public frmBusquedaV()
        {
            InitializeComponent();
        }

        public string Fecha { get; set; }

        private void frmBusquedaV_Load(object sender, EventArgs e)
        {
            clEstadoVuelos objestadovuelo = new clEstadoVuelos();
            objestadovuelo.Fecha = Fecha;
            DataTable dtdatos = objestadovuelo.mtdResultadoBusqueda();
            dgvBusqueda.DataSource = dtdatos;
        }

        private void dgvBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
