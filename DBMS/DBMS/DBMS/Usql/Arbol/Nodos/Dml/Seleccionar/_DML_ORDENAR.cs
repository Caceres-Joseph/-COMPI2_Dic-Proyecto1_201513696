using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Seleccionar
{
    class _DML_ORDENAR : nodoModelo
    {
        public _DML_ORDENAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
