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

namespace DBMS.Usql.Arbol.Nodos.Ssl.Nativas
{
    class _SSL_IMPRIMIR : nodoModelo
    {
        /*
         tImprimir + sAbreParent + VALOR + sCierraParent;
        */
        public _SSL_IMPRIMIR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }




        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override itemRetorno ejecutar(elementoEntorno tablaEntornos)
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

            //ya estoy recibiendo la tabla donde debo trabajar prro
            if (hayErrores())
                return retorno;



            _VALOR val = getNodoVALOR();
            if (val != null)
            {
                //se estan guardando valores en la variable
                //  println("Ejecutando el imprimir que tiene un hijo de valore ejejejejejejejejej");

                itemValor temp = val.getValor(tablaEntornos, new token());

                if (temp.isTypeNulo())
                {
                    Form1.mensajeConsola("nulo");
                }
                else
                {


                    if (temp.valor != null)
                    {
                        try
                        {
                            Form1.mensajeConsola(temp.valor.ToString());
                        }
                        catch (Exception e)
                        {
                            Form1.mensajeConsola(e.ToString());
                        }
                    }
                    //tablaSimbolos.consola.insertar("imprimiendo");

                }

            }
            else
            {
                Form1.mensajeConsola("");

            }

            return retorno;
        }

        public _VALOR getNodoVALOR()
        {
            nodoModelo temp = getNodo("VALOR");
            if (temp != null)
            {
                return (_VALOR)temp;
            }
            else
            {
                return null;
            }

        }

    }
}
