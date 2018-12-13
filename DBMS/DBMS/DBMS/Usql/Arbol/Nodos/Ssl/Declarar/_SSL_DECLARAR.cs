using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Nodos.Inicio;
using DBMS.Usql.Arbol.Nodos.Listas.Valor;
using DBMS.Usql.Arbol.Nodos.Ssl.Asignar;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Declarar
{
    /*
     * SSL_DECLARAR.Rule= tDeclarar+ LST_VARS+ TIPO +VAL
                    | tDeclarar+ LST_VARS+ TIPO
     */
    class _SSL_DECLARAR : nodoModelo
    {
        public _SSL_DECLARAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Ejecucion final para detener 
        |-------------------------------------------------------------------------------------------------------------------
        |
        */


        public override itemRetorno ejecutar(elementoEntorno tablaEntornos)
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

            //ya estoy recibiendo la tabla donde debo trabajar prro
            if (hayErrores())
                return retorno;
             


            token tipo = getTipo(); 
            token visibilidad = new token("publico");
            List<int> dimension = new List<int>(); 
            _VAL val = getNodoVAL();



            if (val != null)
            { 
                insertarVar(tipo, val.getValor(tablaEntornos, tipo), visibilidad, dimension, tablaEntornos);
            }
            else
            { 
                insertarVar(tipo, new itemValor(), visibilidad, dimension, tablaEntornos);
            }

            return retorno;
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        |Funciones
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public void insertarVar( token tipo, itemValor valor,  token visibilidad, List<int> dimension, elementoEntorno tablaEntornos)
        {
            _LST_VARS listas =(_LST_VARS) getNodo("LST_VARS");

            if (listas==null)
            {
                return;
            }

            foreach (token nombre in listas.getLstId())
            { 
                //Se declaro la variable pero el valor es nulo 
                itemEntorno it = new itemEntorno(nombre, tipo, valor, visibilidad, dimension, tablaSimbolos);
                tablaEntornos.insertarEntorno(it);
            }
        }
         



        public _VAL getNodoVAL()
        {
            nodoModelo temp = getNodo("VAL");
            if (temp != null)
            {
                return (_VAL)temp;
            }
            else
            {
                return null;
            } 
        }

         

        public token getTipo()
        {

            nodoModelo tempNodo = getNodo("TIPO");
            if (tempNodo != null)
            {
                _TIPO tipo = (_TIPO)tempNodo;

                token retorno = tipo.getTipo();

                if (retorno.valLower.Equals("vacio"))
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede declarar una variable de tipo vacio:" + retorno.val, retorno);
                }
                return retorno;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede declarar una variable de tipo vacio:", new token("vacio"));
                return new token("vacio");
            }
             
        }
    }
}
