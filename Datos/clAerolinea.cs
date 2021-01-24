using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea1.Datos
{
    class clAerolinea
    {

        public int IdCompañia { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        clConexion objconexion = new clConexion();

        public DataTable mtdListar()
        {
            string consulta = "select IdCompañia,Nombre,Direccion,Telefono from Compañia ";
            DataTable tblCompañia = new DataTable();
            tblCompañia = objconexion.mtdDesconectado(consulta);
            return tblCompañia;

        }


    }
}
