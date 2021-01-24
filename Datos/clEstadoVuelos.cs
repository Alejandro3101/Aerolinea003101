using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;



namespace Aerolinea1.Datos
{
    class clEstadoVuelos
    {
        DataTable dt;
        clConexion objconexion = new clConexion();

        List<clEstadoVuelos> verificar = new List<clEstadoVuelos>();
        public string Fecha { get; set; }

        public void mtdcargardatosvuelos(DataGridView dgv)
        {

            try
            {
                clConexion objconexion = new clConexion();

                dt = new DataTable();
                string consulta = "select Modelo_Avion, fecha, HoraSalida, origen.Ciudad As Ciudad_Origen ,origen.Nombre_Aeropuerto,HoraLlegada,Destino.Ciudad as Nombre_Destino,Destino.Nombre_Aeropuerto from Vuelo inner join Ruta on ruta.IdRuta = vuelo.IdRuta inner join Origen on Origen.IdOrigen = ruta.IdOrigen inner join Destino on Destino.IdDestino = ruta.IdDestino";
                dt = objconexion.mtdDesconectado(consulta);
                dgv.DataSource = dt;

            }
            catch (Exception Ex)
            {
                MessageBox.Show("No se pudo llenar el DataGridView " + Ex.ToString());

            }

        }

        public List<clEstadoVuelos> mtdmtdbusqudafecha()
        {
            string consulta = "select Fecha from Ruta ";
            DataTable dt = objconexion.mtdDesconectado(consulta);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                clEstadoVuelos objestadovuelos = new clEstadoVuelos();

                objestadovuelos.Fecha = dt.Rows[i]["Fecha"].ToString();
                verificar.Add(objestadovuelos);


            }
            return verificar;

        }

        public DataTable mtdResultadoBusqueda()
        {
            string consulta = "select * from Vuelo";
            DataTable dtresul = objconexion.mtdDesconectado(consulta);
            return dtresul;
        }




    }
}
