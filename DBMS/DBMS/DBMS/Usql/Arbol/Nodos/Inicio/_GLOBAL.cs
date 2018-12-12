using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Inicio
{
    class _GLOBAL : nodoModelo
    {
        public _GLOBAL(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
