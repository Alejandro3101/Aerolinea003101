using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


namespace Aerolinea1.Datos
{
    class clEstadoAvion
    {
        DataTable dt;

        public int IdAvion { get; set; }
        public string Placa { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }



        public void mtdCargarEstadoAvion(DataGridView dgv)
        {


            try
            {
                clConexion objconexion = new clConexion();

                dt = new DataTable();
                string consulta = "Select * from Avion";
                dt = objconexion.mtdDesconectado(consulta);
                dgv.DataSource = dt;

            }
            catch (Exception Ex)
            {
                MessageBox.Show("No se pudo llenar el DataGridView " + Ex.ToString());

            }
        }

        public DataTable mtdBuscar()
        {
            clConexion objconexion = new clConexion();
            string consulta = "select Placa from Avion Where Placa = '" + Placa + "'";
            DataTable tbleAvion = new DataTable();
            tbleAvion = objconexion.mtdDesconectado(consulta);
            return tbleAvion;

        }



    }
}
