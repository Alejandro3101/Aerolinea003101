using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Aerolinea1.Datos
{
    class clAeropuertos
    {

        DataTable dt;
        public void mtdcargaraeropuertos(DataGridView dgv)
        {
            try
            {
                clConexion objConexion = new clConexion();

                dt = new DataTable();
                string consulta = "select Ciudad,Nombre_Aeropuerto from Origen";
                dt = objConexion.mtdDesconectado(consulta);
                dgv.DataSource = dt;


            }
            catch (Exception Ex)
            {

                MessageBox.Show("No se pudo llenar el DataGridView " + Ex.ToString());
            }



        }
    }
}
