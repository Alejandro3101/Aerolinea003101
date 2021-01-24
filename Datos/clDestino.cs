using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Aerolinea1.Datos
{
    class clDestino
    {

        public int IdDestino { get; set; }
        public int Ciudad { get; set; }
        public int Nombre_Aeropuerto { get; set; }

        clConexion objconexion = new clConexion();
        public DataTable mtdListar()
        {
            string consulta = " select * from Destino ";
            DataTable tblDestino = new DataTable();
            tblDestino = objconexion.mtdDesconectado(consulta);
            return tblDestino;
        }
    }
}

