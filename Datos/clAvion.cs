using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Aerolinea1.Datos
{
    class clAvion
    {

        DataTable dt;

        public int IdAvion { get; set; }
        public string Placa { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }

        clConexion objconexion = new clConexion();
        public DataTable mtdListar()
        {
            string consulta = "select IdAvion,Placa,Numero,Estado from Avion ";
            DataTable tblAvion = new DataTable();
            tblAvion = objconexion.mtdDesconectado(consulta);
            return tblAvion;
        }


        public Boolean mtdRegistrar ()
        {
            clConexion objconexion = new clConexion();
            try
            {          
                string consulta = String.Format("EXEC spRegistrarAvion '{0}','{1}','{2}'", Placa, Numero, Estado);
                int res = objconexion.mtdConectado(consulta);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
            
        }
         public Boolean mtdActualizar()
        {
            clConexion objconexion = new clConexion();
            try
            {
                string consulta = String.Format(" EXEC ActualizarAvion '{0}','{1}','{2}','{3}'",Placa,Numero,Estado,IdAvion);
                int res = objconexion.mtdConectado(consulta);
                return true;


            }
            finally
            {

            }

        }

        public void mtdCargarAvion(DataGridView dgv)
        {
            try
            {
                clConexion objconexion = new clConexion();
                dt = new DataTable();
                string consulta = ("select * from Avion ");
                dt = objconexion.mtdDesconectado(consulta);
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el DataGridView " + ex.ToString());
               
            }
        }


    }
}
