using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aerolinea1.Datos;
using System.Data;

namespace Aerolinea1.Datos
{
    class clViajeros
    {

        DataTable dt;

        clConexion objconexion = new clConexion();

        public int IdViajeros { get; set; }
        public int ValorViajero { get; set; }
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }


        public DataTable mtdListar()
        {
            string consulta = "select IdViajeros,ValorViajero,Factura.IdFactura,IdCliente from Viajeros,Factura where Factura.IdFactura = Viajeros.IdFactura ";
            DataTable tblViajeros = new DataTable();
            tblViajeros = objconexion.mtdDesconectado(consulta);
            return tblViajeros;
        }

       public int  mtdRegistrar()
        {

            string consulta = "Insert into Viajeros (ValorViajero,IdFactura,IdCliente)values('"+ValorViajero+"','"+IdFactura+"','"+IdCliente+"') ";
            int res = objconexion.mtdConectado(consulta);
            return res;


        }
     

       
        public void mtdcatgarViajeros(DataGridView dgv)
        {
            try
            {
                clConexion objconexion = new clConexion();
                dt = new DataTable();
                string consulta = ("select * from Viajeros ");
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
