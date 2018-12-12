using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E_Rel
{
    class _E_MENOR_QUE : nodoModelo
    {
        public _E_MENOR_QUE(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
