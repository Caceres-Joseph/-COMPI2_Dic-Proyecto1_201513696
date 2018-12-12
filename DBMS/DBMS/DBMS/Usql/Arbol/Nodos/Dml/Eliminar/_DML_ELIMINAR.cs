using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Eliminar
{
    class _DML_ELIMINAR : nodoModelo
    {
        public _DML_ELIMINAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
