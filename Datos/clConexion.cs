using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Aerolinea1.Presentacion;

namespace Aerolinea1.Datos
{
    class clConexion
    {
        SqlConnection objConexion = null;
       

        public clConexion()
        {
            try
            {
                objConexion = new SqlConnection("Data Source=.;Initial Catalog=Aerolinea;Integrated Security=True");
            }
            catch (Exception exp)
            {
                string salida = exp.Message;
            }
        }

        public int mtdConectado(string consulta)
        {
            objConexion.Open();
            SqlCommand comando = new SqlCommand(consulta, objConexion);
            int resultado = comando.ExecuteNonQuery();
            objConexion.Close();
            return resultado;
        }
        public DataTable mtdDesconectado(string consulta)
        {
            objConexion.Open();
            SqlDataAdapter objadaptador = new SqlDataAdapter(consulta, objConexion);
            DataTable tblDatos = new DataTable();
            objadaptador.Fill(tblDatos);
            objConexion.Close();
            return tblDatos;
        }
        

    }
   
}
