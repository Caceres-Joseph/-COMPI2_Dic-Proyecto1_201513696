using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Inicio
{
    class _TIPO : nodoModelo
    {
        public _TIPO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
