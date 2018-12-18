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
        /*
         * 
            DML_ORDENAR.Rule = tOrdenar + tPor + valId + tAsc
                                    | tOrdenar + tPor + valId + tDesc
                                    | tOrdenar + tPor + valId
                                    ;
         */
        public _DML_ORDENAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
