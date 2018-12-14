using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Expresion.Id
{
    class _ID_VAR_FUNC_5 : _ID_VAR_FUNC
    {
        /*
         * valId + sAbreParent + LST_VALOR + sCierraParent
         */
        public _ID_VAR_FUNC_5(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
