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

namespace DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Si
{
    class _SSL_SI_2 : nodoModelo
    {
        /*
         * tSi+ sAbreParent +VALOR+ sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave + SSL_SINO;
         */
        public _SSL_SI_2(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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


            if (condicion)
            {
                _LST_CUERPO nodoCuerpo = (_LST_CUERPO)getNodo("LST_CUERPO"); 
                elementoEntorno entornoIf = new elementoEntorno(elementoEntor, tablaSimbolos, "Si");
                return nodoCuerpo.ejecutar(entornoIf); 
            }
            else
            {
                _SSL_SINO nodoSino = (_SSL_SINO)getNodo("SSL_SINO");
                elementoEntorno entornoSino = new elementoEntorno(elementoEntor, tablaSimbolos, "Sino"); 
                return nodoSino.ejecutar(entornoSino); 
            }
             
        }
    }
}
