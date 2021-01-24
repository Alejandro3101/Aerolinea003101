using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aerolinea1.Datos
{
    class clRuta
    {

        DataTable dt;


        public int IdRuta { get; set; }
        public string Fecha { get; set; }
        public string HoraSalida { get; set; }
        public string HoraLlegada { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }

        clConexion objconexion = new clConexion();



        public DataTable mtdListar()
        {
            string Consulta = "select IdRuta,Fecha,HoraSalida,HoraLlegada,IdOrigen,IdDestino from Ruta";
            DataTable tblPrograma = new DataTable();
            tblPrograma = objconexion.mtdDesconectado(Consulta);
            return tblPrograma;

        }

        public Boolean mtdRegistrar()
        {
            clConexion objconexion = new clConexion();
            try
            {
                string consulta = String.Format("EXEC spRegistrarRutas '{0}','{1}','{2}','{3}','{4}'", Fecha, HoraSalida, HoraLlegada, IdOrigen, IdDestino);
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
                string consulta = String.Format("EXEC spActualizarRuta '{0}','{1}','{2}','{3}','{4}','{5}'", Fecha, HoraSalida, HoraLlegada, IdOrigen, IdDestino,IdRuta);
                int res = objconexion.mtdConectado(consulta);
                return true;
            }
           finally
            {

            }    

        }

        public void mtdCargarRuta(DataGridView dgv)
        {
            try
            {
                clConexion objconexion = new clConexion();
                dt = new DataTable();
                string consulta = ("select IdRuta,Fecha,HoraSalida,HoraLlegada,Origen.Ciudad as Ciudad_Origen ,Destino.Ciudad as Ciudad_Destino from ruta inner join Origen on Origen.IdOrigen = Ruta.IdOrigen inner join Destino on Destino.IdDestino = Ruta.IdDestino ");
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
