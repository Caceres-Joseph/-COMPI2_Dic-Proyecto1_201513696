using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;

namespace DBMS.Usql.Arbol.Nodos.Expresion.Id
{
    class _ID_VAR_FUNC_4 : _ID_VAR_FUNC
    {
        /*
         * valId + sAbreParent + sCierraParent
         */
        public _ID_VAR_FUNC_4(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override itemRetorno ejecutar(elementoEntorno elementoEntor)
        /*
        |---------------------------- 
        | EJECUTAR 
        |----------------------------
        | 0= normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */
        {

            itemRetorno retorno = new itemRetorno(0);

            token nombreFunc = lstAtributos.listaAtributos[0].tok;


            //le tengo que enviar el entorno global compa
            itemValor retornoFunc = tablaSimbolos.lstMetodo_funcion.getMetodoFuncion(nombreFunc, new lstValores(), elementoEntor, nombreFunc.val);

            return retorno;
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | DESTINO
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override itemEntorno getDestino(elementoEntorno elementoEntorno)
        {
            token nombreFunc = lstAtributos.listaAtributos[0].tok;
            tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede asignar un valor al retorno de la función: "+ nombreFunc.val, nombreFunc);


            return new itemEntorno(tablaSimbolos);

        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Recuperando valor
        |-------------------------------------------------------------------------------------------------------------------
        |
        */


        public override itemValor getValor(elementoEntorno elementoEntor)
        {

            itemRetorno retorno = new itemRetorno(0);

            token nombreFunc = lstAtributos.listaAtributos[0].tok;


            //le tengo que enviar el entorno global compa
            itemValor retornoFunc = tablaSimbolos.lstMetodo_funcion.getMetodoFuncion(nombreFunc, new lstValores(), elementoEntor, nombreFunc.val);
            return retornoFunc; 
        }



    }
}
