using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E_Valor
{
    class _E_ID : nodoModelo
    {
        public _E_ID(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
