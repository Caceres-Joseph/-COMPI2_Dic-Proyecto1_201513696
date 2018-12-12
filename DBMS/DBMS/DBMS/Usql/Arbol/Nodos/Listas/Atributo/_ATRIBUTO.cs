using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Listas.Atributo
{
    class _ATRIBUTO : nodoModelo
    {
        public _ATRIBUTO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
