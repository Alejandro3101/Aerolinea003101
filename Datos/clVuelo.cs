using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Aerolinea1.Datos
{
    class clVuelo
    {
        DataTable dt;


        public int IdVuelo { get; set; }
        public string Capacidad { get; set; }
        public string Modelo_Avion { get; set; }
        public int IdRuta { get; set; }
        public int IdCompañia { get; set; }
        public int IdAvion { get; set; }

        clConexion objconexion = new clConexion();
        public DataTable mtdListar()
        {
            string consulta = "select IdVuelo,Capacidad,Modelo_Avion,IdRuta,IdCompañia,IdAvion from Vuelo ";
            DataTable tblVuelo = new DataTable();
            tblVuelo = objconexion.mtdDesconectado(consulta);
            return tblVuelo;
        }


        public Boolean mtdRegistrar()
        {
            clConexion objconexion = new clConexion();
            try
            {
                string consulta = String.Format("EXEC spRegistrar '{0}','{1}','{2}','{3}','{4}'", Capacidad, Modelo_Avion, IdRuta, IdCompañia, IdAvion);
                int res = objconexion.mtdConectado(consulta);
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public Boolean mtdActualiazar()
        {
            clConexion objconexion = new clConexion();

            try
            {
                string consulta = String.Format("Exec spActualizar  '{0}','{1}','{2}','{3}','{4}','{5}' ", Capacidad, Modelo_Avion, IdRuta, IdCompañia, IdAvion, IdVuelo);
                int res = objconexion.mtdConectado(consulta);
                return true;
            }
            finally
            {

            }

        }

        public void mtdcargarVuelos(DataGridView dgv)
        {
            try
            {
                clConexion objConexion = new clConexion();

                dt = new DataTable();
                string consulta = "select * from Vuelo";
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


