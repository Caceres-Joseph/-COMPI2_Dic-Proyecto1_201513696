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
        /*
         * DML_SELECCIONAR_P.Rule = DML_SELECCIONAR_P1
                                     | DML_SELECCIONAR_P2
                                     | DML_SELECCIONAR_P3
                                     | DML_SELECCIONAR_P4
                                     ;
        */
        public _DML_SELECCIONAR_P(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
