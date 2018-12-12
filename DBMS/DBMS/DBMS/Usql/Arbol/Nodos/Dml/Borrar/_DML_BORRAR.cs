using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Borrar
{
    class _DML_BORRAR : nodoModelo
    {
        public _DML_BORRAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
