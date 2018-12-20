using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Actualizar
{
    class _DML_ACTUALIZAR : nodoModelo
    {
        /*
         * 
            DML_ACTUALIZAR.Rule = DML_ACTUALIZAR_1
                                     | DML_ACTUALIZAR_2
                                     ;
         */
        public _DML_ACTUALIZAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
