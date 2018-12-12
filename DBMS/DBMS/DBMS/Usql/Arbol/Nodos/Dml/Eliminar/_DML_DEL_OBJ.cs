using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Eliminar
{
    class _DML_DEL_OBJ : nodoModelo
    {
        public _DML_DEL_OBJ(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
