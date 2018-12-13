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

namespace DBMS.Usql.Arbol.Nodos.Dll
{
    /*
     * DDL_CREAR_FUNCION.Rule = tCrear + tFuncion + valId + sAbreParent + LST_PARAMETRO + sCierraParent + TIPO + sAbreLlave + LST_CUERPO + sCierraLlave;      
     */


    class _DDL_CREAR_FUNCION : nodoModelo
    {
        public _DDL_CREAR_FUNCION(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Ejecucion final para detener 
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
            return retorno;
        }




        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Cargando Funciones
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override void ejecutar()
        { 
            if (hayErrores())
                return;
            // println("llego al contructor");

            token tipo = getTipo();
            token nombre = getIdentificador();
            nodoModelo LST_CUERPO = getLST_CUERPO();
            token visbilidad = new token("public");
            int dimension = getDimensiones();
            elementoPolimorfo element = new elementoPolimorfo(visbilidad, tablaSimbolos, tipo, nombre, LST_CUERPO, dimension);

            cargarPolimorfismoHijos(element);
            tablaSimbolos.lstMetodo_funcion.insertarElemento(element); 
        }


 
        public token getTipo()
        {

            nodoModelo tempNodo = getNodo("TIPO");
            if (tempNodo != null)
            {
                _TIPO tipo = (_TIPO)tempNodo;
                return tipo.getTipo();
            }
            else
                return new token("vacio");

        }

         
        public token getIdentificador()
        {
            token retorno = lstAtributos.getToken(2);
            return retorno;
        }


        public int getDimensiones()
        {
             
            return 0;
        }

        public nodoModelo getLST_CUERPO()
        {
            nodoModelo tempNodo = getNodo("LST_CUERPO");
            if (tempNodo != null)
                return tempNodo;
            else
                return new nodoModelo("---", tablaSimbolos);

        }


    }
}
