using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dcl
{
    class _DCL_OTORGAR : nodoModelo
    {
        public _DCL_OTORGAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
