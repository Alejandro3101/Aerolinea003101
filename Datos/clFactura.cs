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
    class clFactura
    {

        DataTable dt;

        clConexion objconexion = new clConexion();

        public int IdFactura { get; set; }
        public string Fecha { get; set; }
        public int IdVuelo { get; set; }


        public DataTable mtdListar()
        {
            string consulta = "select IdFactura,Fecha,IdVuelo from Factura ";
            DataTable tblFactura = new DataTable();
            tblFactura = objconexion.mtdDesconectado(consulta);
            return tblFactura;
        }

        public Boolean mtdRegistar()
        {

           
            try
            {
                string consulta = String.Format("EXEC spAgregarFactura '{0}','{1}'",Fecha,IdVuelo);
                int res = objconexion.mtdConectado(consulta);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public void mtdCargarFactura(DataGridView dgv)
        {
            try
            {
                clConexion objconexion = new clConexion();
                dt = new DataTable();
                string consulta = ("select * from Factura");
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
