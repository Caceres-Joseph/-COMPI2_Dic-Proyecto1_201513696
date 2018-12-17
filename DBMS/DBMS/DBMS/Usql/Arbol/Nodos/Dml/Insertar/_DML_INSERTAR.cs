using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Insertar
{
    /*
     * DML_INSERTAR_2
                | DML_INSERTAR_1
     */
    class _DML_INSERTAR : nodoModelo
    {
        public _DML_INSERTAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
