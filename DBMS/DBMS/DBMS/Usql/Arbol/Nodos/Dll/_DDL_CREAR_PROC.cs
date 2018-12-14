using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;

namespace DBMS.Usql.Arbol.Nodos.Dll
{
    class _DDL_CREAR_PROC : nodoModelo
    /*
     *DDL_CREAR_PROC.Rule = tCrear + tProcedimiento + valId + sAbreParent + LST_PARAMETRO + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave; 
     * 
     */
    {
        public _DDL_CREAR_PROC(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
        /*
        |-------------------------------------------------------------------------------------------------------------------
        | FUNCIONES
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        /*
        public override void ejecutar(elementoClase simbolo)
        {

            if (hayErrores())
                return;
            // println("llego al contructor");

            token tipo = getTipo();
            token nombre = getIdentificador();
            nodoModelo LST_CUERPO = getLST_CUERPO();
            token visbilidad = getVisibilidad(simbolo);
            int dimension = getDimensiones();
            elementoPolimorfo element = new elementoPolimorfo(visbilidad, tablaSimbolos, tipo, nombre, LST_CUERPO, dimension);

            cargarPolimorfismoHijos(element);
            simbolo.lstMetodo_funcion.insertarElemento(element);


        }
        */

        public token getVisibilidad(elementoClase elem)
        {
             
            token toK = new token("public");
            return toK;
        }


        public token getTipo()
        {

            token toK = new token("vacio");
            return toK;

        }




        public token getIdentificador()
        {
            token retorno = new token();

            if (lstAtributos.listaAtributos.Count > 1)
            {
                retorno = lstAtributos.getToken(2);
            }

            return retorno;
        }


        public int getDimensiones()
        {

            int retorno = 0; 
            return retorno;
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
