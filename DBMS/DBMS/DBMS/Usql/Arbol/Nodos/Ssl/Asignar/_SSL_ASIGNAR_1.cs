using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Nodos.Expresion.Id;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Asignar
{
    class _SSL_ASIGNAR_1 : nodoModelo
    {
        /*
         * SSL_ASIGNAR_1.Rule = ID_VAR_FUNC + VAL;
         */
        public _SSL_ASIGNAR_1(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
            if (hayErrores())
                return retorno;


            //PUNTERO DONDE VOY A GUARDAR EL VALOR
            _ID_VAR_FUNC nodoFunc = (_ID_VAR_FUNC)getNodo("ID_VAR_FUNC");
            itemEntorno destino = nodoFunc.getDestino(elementoEntor);


            //AHORA OBTENGO EL VALOR 
            _VAL nodoVal = (_VAL)getNodo("VAL");

            if (destino != null)
            {
                itemValor valor = nodoVal.getValor(elementoEntor, destino.tipo);

                asignarValor(destino, valor);

            }
            else
            {
                println("Me retorno un itemEntorno vacio, no podré asignar la variable prro");
            }

            return retorno;

        }
         
        public Boolean validandoTipo(String tipo1, String tipo2)
        {
             
            if (itemValor.getTipoApartirDeString(tipo1).Equals(tipo2) || tipo2.Equals("nulo"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void asignarValor(itemEntorno destino, itemValor valor)
        {

            //validando si lo que estoy esperando es un arreglo

            if (destino.dimension.Count > 0)
            {
                if (destino.dimension.Count == valor.dimensiones.Count)
                {

                    if (validandoTipo(destino.tipo.valLower, valor.getTipo()))
                    {

                        //aquí le asigno el valor
                        destino.valor = valor;

                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSemantic("Se está intentando guardar en :" + destino.nombre.val + " de tipo " + destino.tipo.valLower + ", un valor de tipo " + valor.getTipo(), destino.nombre);
                    }
                }
                else
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se esta recibiendo :" + valor.dimensiones.Count + " en la matriz : " + destino.nombre.val + " de dimension:" + destino.dimension.Count, destino.nombre);
                }
            }
            else
            {
                if (valor.dimensiones.Count != 0)
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se está intentando guardar en la variable :" + destino.nombre.val + " de tipo " + destino.tipo.valLower + ", una matriz de dimension : " + valor.dimensiones.Count, destino.nombre);
                }
                else if (validandoTipo(destino.tipo.valLower, valor.getTipo()))
                {

                    //aquí le asigno el valor

                    destino.valor = valor;
                }
                else
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se está intentando guardar en :" + destino.nombre.val + " de tipo " + destino.tipo.valLower + ", un valor de tipo " + valor.getTipo(), destino.nombre);

                    //error semantico, se está intentando asiganar un valor diferente al declarado por la variable
                }
            }
        }

    }
}
