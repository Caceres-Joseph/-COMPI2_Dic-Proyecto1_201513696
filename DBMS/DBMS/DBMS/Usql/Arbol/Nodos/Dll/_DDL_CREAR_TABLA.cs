using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dll
{
    class _DDL_CREAR_TABLA : nodoModelo
    {
        /*
         * tCrear + tTabla + valId + sAbreParent + LST_ATRIBUTO + sCierraParent
         */
        public _DDL_CREAR_TABLA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


    }
}
