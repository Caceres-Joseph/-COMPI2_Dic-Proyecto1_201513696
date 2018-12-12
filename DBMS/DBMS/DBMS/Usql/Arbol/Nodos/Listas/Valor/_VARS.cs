using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Listas.Valor
{
    class _VARS : nodoModelo
    {
        public _VARS(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
