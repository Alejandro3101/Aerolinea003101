using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aerolinea1
{
    public partial class frmTicket : Form
    {
        public frmTicket()
        {
            InitializeComponent();
        }

        private void frmTicket_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.DataTable2' Puede moverla o quitarla según sea necesario.
            this.DataTable2TableAdapter.Fill(this.DataSet1.DataTable2);

            this.reportViewer1.RefreshReport();
        }
    }
}
