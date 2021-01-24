using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aerolinea1.Datos
{
    class clUsuario
    {
        public int IdUsuario { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }

        DataTable dt;
        clConexion objconexion = new clConexion();



        public DataTable mtdListar()
        {
            string consulta = "select IdUsuario,Documento,Nombre,Apellido,Correo,Clave,Rol from Usuario ";
            DataTable tblUsuario = new DataTable();
            tblUsuario = objconexion.mtdDesconectado(consulta);
            return tblUsuario;
        }

        public Boolean mtdRegistrar()
        {

            try
            {
                string consulta = String.Format(" EXEC spRegistrarUsuario '{0}','{1}','{2}','{3}','{4}','{5}'", Documento, Nombre, Apellido, Correo, Clave, Rol);
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
            try
            {
                string consulta = String.Format(" EXEC ActualizarUsuario '{0}','{1}','{2}','{3}','{4}','{5}','{6}'", Documento, Nombre, Apellido, Correo, Clave, Rol, IdUsuario);
                int res = objconexion.mtdConectado(consulta);
                return true;

            }
            finally
            {


            }
        }

        public static Boolean mtdvalidaremail(string email)
        {
            string validar;

            validar = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

            if (Regex.IsMatch(email, validar))
            {
                if (Regex.Replace(email, validar, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        public void mtdcargarUsuario(DataGridView dgv)
        {
            try
            {
                clConexion objconexion = new clConexion();
                dt = new DataTable();
                string consulta = ("select * from Usuario ");
                dt = objconexion.mtdDesconectado(consulta);
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el DataGridView " + ex.ToString());

            }
        }

        public static void mtdvalidarnum(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}

