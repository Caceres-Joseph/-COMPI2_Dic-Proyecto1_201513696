using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E
{
    class _VALOR : nodoModelo
    {
        public _VALOR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
