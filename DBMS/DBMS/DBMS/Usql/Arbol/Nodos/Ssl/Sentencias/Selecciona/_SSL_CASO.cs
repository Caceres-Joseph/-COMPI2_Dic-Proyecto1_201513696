using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Nodos.Expresion.E;
using DBMS.Usql.Arbol.Nodos.Expresion.E.Operelacional;
using DBMS.Usql.Arbol.Nodos.Inicio;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Selecciona
{
    class _SSL_CASO : nodoModelo
    {
        /*
         * tCaso + VALOR + sDosPuntos + LST_CUERPO;
         */
        public _SSL_CASO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public itemRetorno ejecutar(elementoEntorno elementoEntor, itemValor expresion)
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
            IgualQue igual = new IgualQue(new _E("temp1", tablaSimbolos), new _E("temp2", tablaSimbolos), tablaSimbolos, new token("="));
            itemValor resultado = igual.opIgualacion(expresion, valE, "IGUALACION", elementoEntor);

            Object objetoValor = resultado.getValorParseado("bool");
            Boolean condicion = false;

            if (objetoValor != null)
            {
                condicion = (Boolean)objetoValor;
                if (condicion)
                {
                    _LST_CUERPO nodoCuerpo = (_LST_CUERPO)getNodo("LST_CUERPO");
                    return nodoCuerpo.ejecutar(elementoEntor);

                }
                else
                {
                    return retorno;
                }
            }
            else
            {
                println(" E + sDosPuntos + sAbreLlave + LST_CUERPO + sCierraLlave ->  No se retorno un boolenano en la igualación");
                return retorno;
            }
             

        }
    }
}
