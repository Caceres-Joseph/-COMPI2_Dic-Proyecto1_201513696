using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dml
{
    class _DML : nodoModelo
    {
        public _DML(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
