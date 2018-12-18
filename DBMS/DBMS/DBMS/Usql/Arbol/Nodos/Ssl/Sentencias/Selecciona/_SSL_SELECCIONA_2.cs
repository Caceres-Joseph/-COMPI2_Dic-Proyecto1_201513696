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
    class _SSL_SELECCIONA_2 : nodoModelo
    {
        /*
         * tSelecciona + sAbreParent + VALOR + sCierraParent + sAbreLlave + SSL_CASOS + SSL_SEL_DEFECTO + sCierraLlave;
         */
        public _SSL_SELECCIONA_2(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            retorno = nodoCuerpo.ejecutar(entornoIf, valE);

             


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


            _SSL_SEL_DEFECTO defecto = (_SSL_SEL_DEFECTO)getNodo("SSL_SEL_DEFECTO");
            retorno = defecto.ejecutar(entornoIf);



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

            return retorno;
        }


    }
}
