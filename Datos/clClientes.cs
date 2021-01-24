using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerolinea1.Presentacion;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Aerolinea1.Datos
{
    class clClientes

    { 
        DataTable dt;

        public int IdCliente { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Edad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }



        clConexion objconexion = new clConexion();

        
        public DataTable mtdListar()
        {
            string consulta = "select IdCliente,Documento,Nombre,Apellido,Edad,Telefono,Email,Tipo from Cliente ";
            DataTable tblClientes = new DataTable();
            tblClientes = objconexion.mtdDesconectado(consulta);
            return tblClientes;
        }

        public int mtdRegistrar()
        {
            string consulta = "insert into Cliente (Documento,Nombre,Apellido,Edad,Telefono,Email,Tipo) Values ('"+Documento+ "','" + Nombre + "','" + Apellido + "','" + Edad + "','" + Telefono + "','" + Email + "','" + Tipo + "')";
            int res = objconexion.mtdConectado(consulta);
            return res;
        }

        //public int mtdEliminar()
        //{
        //    string cons = "DELETE FROM Cliente WHERE Documento = '" + Documento + "' ";

        //    //1 o 0 filas retornadas afectadas
        //    int res = objconexion.mtdConectado(cons);
        //    return res;
        //}
         public int mtdEditar()
        {
            string consu = "update Cliente set Documento = '" + Documento + "',Nombre = '" + Nombre + "' ,Apellido = '" + Apellido + "' ,Edad = '" + Edad + "' ,Telefono =  '" + Telefono + "',Email = '" + Email + "' ,Tipo = '" + Tipo + "' where Documento = '" + Documento + "' ";

            //1 o 0 filas retornadas afectadas
            int res = objconexion.mtdConectado(consu);
            return res;
        }

        public void mtdcargarPersonas(DataGridView dgv)
        {
            try
            {
                clConexion objconexion = new clConexion();

                dt = new DataTable();
                string consulta = "select * from Cliente";
                dt = objconexion.mtdDesconectado(consulta);
                dgv.DataSource = dt;

            }
            catch (Exception Ex)
            {
                MessageBox.Show("No se pudo llenar el DataGridView " + Ex.ToString());

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
                                                    