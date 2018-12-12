using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Seleccionar
{
    class _DML_SELECCIONAR_P : nodoModelo
    {
        public _DML_SELECCIONAR_P(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
