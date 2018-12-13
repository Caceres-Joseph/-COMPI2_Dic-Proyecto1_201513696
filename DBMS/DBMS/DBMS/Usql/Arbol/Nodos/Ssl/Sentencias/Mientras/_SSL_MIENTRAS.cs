using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Nodos.Expresion.E;
using DBMS.Usql.Arbol.Nodos.Inicio;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Mientras
{
    class _SSL_MIENTRAS : nodoModelo
    {
        /*
         * tMientras + sAbreParent + VALOR + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;
         */
        public _SSL_MIENTRAS(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
            Object objetoValor = valE.getValorParseado("bool");
            Boolean condicion = false;


            if (objetoValor != null)
            {
                condicion = (Boolean)objetoValor;

            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("La condición devulelta no es de tipo booleano,es de tipo:" + valE.getTipo(), lstAtributos.getToken(0));
                return retorno;
            }

              
            while (condicion)
            {

                _LST_CUERPO nodoCuerpo = (_LST_CUERPO)getNodo("LST_CUERPO");
                elementoEntorno entornoWhile = new elementoEntorno(elementoEntor, tablaSimbolos, "While");
                retorno = nodoCuerpo.ejecutar(entornoWhile);

                //analizando el continue, el break, y el return

                if (retorno.isRomper())
                //este codigo sirve para eliminar el romper en los nodos, más arriba, y solo se quede en el case
                {
                    return new itemRetorno(0);
                }
                else if (retorno.isRetorno())
                {
                    return retorno;
                }
                else if (retorno.isContinuar())
                {
                    return new itemRetorno(0);
                    //retorno = new itemRetorno(0);
                }
                else if (hayErrores())
                {
                    return retorno;
                }


                //volviendo analizar el while 
                nodoE = (_VALOR)getNodo("VALOR");
                valE = nodoE.getValor(elementoEntor);
                objetoValor = valE.getValorParseado("bool");
                condicion = (Boolean)objetoValor;
            }

            if (retorno.isContinuar())
            {
                return new itemRetorno(0);
            }
            return retorno; 
        } 
    }
}
