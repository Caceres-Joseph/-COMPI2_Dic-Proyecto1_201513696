using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dcl
{
    class _DCL_DENEGAR : nodoModelo
    {
        public _DCL_DENEGAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
