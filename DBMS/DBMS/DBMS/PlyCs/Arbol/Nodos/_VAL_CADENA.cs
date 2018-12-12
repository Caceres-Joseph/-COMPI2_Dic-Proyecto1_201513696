using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.PlyCs.Arbol.Nodos
{
    class _VAL_CADENA : nodoModelo
    {
        public _VAL_CADENA(string nombre) : base(nombre)
        {
        }



        public string getCadena()
        {

            String cadena = lstAtributos.getValItem(0);
             
            cadena = cadena.Replace("\\", "");
            cadena = cadena.Replace("\"", "");
            return cadena;


        }
    }
}
