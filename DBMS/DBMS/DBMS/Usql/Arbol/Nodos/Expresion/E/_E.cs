using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E
{
    class _E : nodoModelo
    {
        public _E(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
