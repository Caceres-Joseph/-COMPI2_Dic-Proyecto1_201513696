using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Usar
{
    class _DML_USAR : nodoModelo
    {
        public _DML_USAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
