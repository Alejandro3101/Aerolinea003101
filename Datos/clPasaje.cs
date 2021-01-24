using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Aerolinea1.Datos
{
    class clPasaje
    {
        public int IdPasaje { get; set; }
        public string Clase { get; set; }
        public string Asiento { get; set; }
        public string Valor { get; set; }
        public int IdCliente { get; set; }
        public int IdVuelo { get; set; }
        public int IdUsuario { get; set; }

        DataTable dt;



        public Boolean mtdRegistrar()
        {
            clConexion objconexion = new clConexion();

            try
            {

                string consulta = String.Format("EXEC spRegistrarPasaje '{0}','{1}','{2}','{3}','{4}','{5}'", Clase, Asiento, Valor, IdCliente, IdVuelo, IdUsuario);
                int res = objconexion.mtdConectado(consulta);
                return true;

            }
            catch (Exception )
            {
                return false;

            }

        }

        public Boolean mtdActualizar()
        {
            clConexion objconexion = new clConexion();

            try
            {
                string consulta = String.Format("EXEC spEditarP '{0}','{1}','{2}','{3}','{4}','{5}','{6}'", Clase, Asiento, Valor, IdCliente, IdVuelo, IdUsuario, IdPasaje);
                int res = objconexion.mtdConectado(consulta);
                return true;


            }
            finally
            {

            }


        }

        public void mtdCargarPasaje(DataGridView dgv)
        {
            try
            {
                clConexion objConexion = new clConexion();

                dt = new DataTable();
                string consulta = "Select Pasaje.*, Cliente.Documento,Cliente.Nombre as Cliente,Cliente.Apellido, Vuelo.Modelo_Avion, Usuario.Nombre as Nombre_Usuario,Rol  from Pasaje inner join Cliente on Cliente.IdCliente = Pasaje.IdCliente inner join  Vuelo on  Vuelo.IdVuelo = Pasaje.IdVuelo inner join Usuario on  Usuario.IdUsuario = Pasaje.IdUsuario ";
                dt = objConexion.mtdDesconectado(consulta);
                dgv.DataSource = dt;


            }
            catch (Exception Ex)
            {

                MessageBox.Show("No se pudo llenar el DataGridView " + Ex.ToString());
            }



        }
        public void mtdCargarinformePasaje(DataGridView dgv)
        {
            try
            {
                clConexion objConexion = new clConexion();

                dt = new DataTable();
                string consulta = "select * from RegistroTrig";
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
