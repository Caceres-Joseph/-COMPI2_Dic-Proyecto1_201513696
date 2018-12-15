using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Nodos.Expresion.E;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Selecciona
{
    class _SSL_SELECCIONA_1 : nodoModelo
    {
        /*
         * tSelecciona + sAbreParent + VALOR + sCierraParent + sAbreLlave + SSL_CASOS + sCierraLlave;
         */
        public _SSL_SELECCIONA_1(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
        | 0 = normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */
        {
            itemRetorno retorno = new itemRetorno(0);
            if (hayErrores())
                return retorno;

            _VALOR nodoE = (_VALOR)getNodo("VALOR");
            itemValor valE = nodoE.getValor(elementoEntor);

            _SSL_CASOS nodoCuerpo = (_SSL_CASOS)hijos[1];
            elementoEntorno entornoIf = new elementoEntorno(elementoEntor, tablaSimbolos, "case");

            itemRetorno cuerpoCase = nodoCuerpo.ejecutar(entornoIf, valE);


            if (cuerpoCase.isRomper())
            //este codigo sirve para eliminar el romper en los nodos, más arriba, y solo se quede en el case
            {
                return new itemRetorno(0);
            }
            else
            {
                return cuerpoCase;
            }
             
        }

    }
}
