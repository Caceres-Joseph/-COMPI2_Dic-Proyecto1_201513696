using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;

namespace DBMS.Usql.Arbol.Nodos.Expresion.Id
{
    class _ID_VAR_FUNC_2 : _ID_VAR_FUNC
    {
        /*
         * sArroba + valId;
         */
        public _ID_VAR_FUNC_2(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override itemEntorno getDestino(elementoEntorno elementoEntorno)
        { 
            return getEntornoId(lstAtributos.listaAtributos[1].tok, elementoEntorno, new List<int>());
              
        }

    }
}
