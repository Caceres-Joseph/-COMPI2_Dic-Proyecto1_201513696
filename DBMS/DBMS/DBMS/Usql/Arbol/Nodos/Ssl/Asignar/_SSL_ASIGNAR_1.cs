using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Validar;
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
        /*

        public Boolean validandoTipo(itemEntorno tipo1, itemValor tipo2)
        {


            if (itemValor.getTipoApartirDeString(tipo1.tipo.valLower).Equals(tipo2.getTipo()) || tipo2.Equals("nulo"))
            {

                //revisando si es de tipo objeto
                if (!tipo2.nombreObjeto.Equals(tipo1.tipo.valLower))
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se está intentando guardar en :" + tipo1.nombre.val + " de tipo " + tipo1.tipo.valLower + ", un valor de tipo " + tipo2.nombreObjeto, tipo1.nombre);
                    return false;
                }
                return true;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("Se está intentando guardar en :" + tipo1.nombre.val + " de tipo " + tipo1.tipo.valLower + ", un valor de tipo " + tipo2.getTipo(), tipo1.nombre);
                return false;
            }

        }*/


        public void asignarValor(itemEntorno destino, itemValor valor)
        {

            validarTipos validador = new validarTipos(tablaSimbolos);


            
            if (validador.validandoTipo(destino.nombre, destino.tipo, valor))
            { 
                //aquí le asigno el valor 
                destino.valor = valor;
            }
        } 

    }
}
