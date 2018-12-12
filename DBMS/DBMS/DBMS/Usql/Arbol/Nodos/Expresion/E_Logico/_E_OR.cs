using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E_Logico
{
    class _E_OR : nodoModelo
    {
        public _E_OR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
