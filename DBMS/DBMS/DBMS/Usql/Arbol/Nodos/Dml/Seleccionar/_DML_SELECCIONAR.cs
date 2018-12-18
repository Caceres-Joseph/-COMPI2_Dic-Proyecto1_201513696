using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Seleccionar
{
    class _DML_SELECCIONAR : nodoModelo
    {
        /*
         * 
            //  ''' SELECCIONAR '''
            DML_SELECCIONAR.Rule = DML_SELECCIONAR_P
                                    | DML_SELECCIONAR_P + DML_ORDENAR
                                    ;
         */
        public _DML_SELECCIONAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
