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
    class _ID_VAR_FUNC_3 : _ID_VAR_FUNC
    {
        /*
         * ID_VAR_FUNC_3.Rule = valId;
         */
        public _ID_VAR_FUNC_3(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Recuperando valor
        |-------------------------------------------------------------------------------------------------------------------
        |
        */


        public override itemValor getValor(elementoEntorno elementoEntorno)
        {


            itemValor retorno = new itemValor();  
            // en este momento no se si es columna o es una tabla prro
            retorno.setCartColumna(lstAtributos.getToken(0));
            return retorno;
        }

    }
}
