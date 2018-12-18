using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Seleccionar
{
    class _DML_SELECCIONAR_P2 : nodoModelo
    {
        /*
         * tSeleccionar + LST_VALOR + tDe + LST_VAL_ID;
         */
        public _DML_SELECCIONAR_P2(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
