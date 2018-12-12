using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dll
{
    class _DDL_CREAR_OBJETO : nodoModelo
    {
        public _DDL_CREAR_OBJETO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
