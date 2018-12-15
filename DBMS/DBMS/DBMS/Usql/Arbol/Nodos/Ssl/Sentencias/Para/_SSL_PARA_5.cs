﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Nodos.Expresion.E;
using DBMS.Usql.Arbol.Nodos.Expresion.E.OpeAritmetica;
using DBMS.Usql.Arbol.Nodos.Inicio;
using DBMS.Usql.Arbol.Nodos.Ssl.Asignar;
using DBMS.Usql.Arbol.Nodos.Ssl.Declarar;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Para
{
    /*
     * tPara + sAbreParent + SSL_ASIGNAR + sPuntoComa + VALOR + sPuntoComa + sMenos + sMenos + 
     * sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;
     */
    class _SSL_PARA_5 : _SSL_ASIGNAR
    {
        public _SSL_PARA_5(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
            itemEntorno destino = null;

            if (hayErrores())
                return retorno;


            elementoEntorno entornoWhile = new elementoEntorno(elementoEntor, tablaSimbolos, "para");


            _SSL_ASIGNAR nodotemp = (_SSL_ASIGNAR)hijos[0];
            nodotemp.ejecutar(entornoWhile);



            _VALOR nodoE = (_VALOR)getNodo("VALOR");
            itemValor valE = nodoE.getValor(entornoWhile);
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


                /*
                 ********
                 *  i --
                 ********
                 */

                //aquí esta el destino
                destino = nodotemp.getUltimaVar(entornoWhile); 



                itemValor valor = destino.valor;
                itemValor valor2 = new itemValor();
                valor2.setValue(1);

                resta sumatoria = new resta(new _E("hijo1", tablaSimbolos), new _E("hijo2", tablaSimbolos), tablaSimbolos, lstAtributos.getToken(0));
                itemValor resultado = sumatoria.opRestaExterna(entornoWhile, valor, valor2);
                asignarValor(destino, resultado);


                /*
                 ********
                 *  CONDICION
                 ********
                 */

                //volviendo analizar el while 
                nodoE = (_VALOR)getNodo("VALOR");
                valE = nodoE.getValor(entornoWhile);
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
