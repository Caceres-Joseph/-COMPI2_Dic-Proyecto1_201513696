using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;

namespace DBMS.Usql.Arbol.Nodos.Dll
{
    /*
     * 
            DDL_CREAR_OBJETO.Rule = tCrear + tObjeto + valId + sAbreParent + LST_ATRIBUTO + sCierraParent
     */
    class _DDL_CREAR_OBJETO : nodoModelo
    {
        public _DDL_CREAR_OBJETO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Cargando Objetos
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
         
        public override void ejecutar()
        {

            //aqui tengo qu crear una clase real


            if (hayErrores())
                return;

            token nombreClase = getNombre();
            token extender = new token("");
            token visibilidad = new token("publico");

            elementoClase nuevaClase = new elementoClase(nombreClase, visibilidad, extender, hijos, tablaSimbolos);
            ejecutarHijos(nuevaClase); //aqui cargo ele elmento clase 
            //ahora lo ingreso a la tabla de simbolos
            tablaSimbolos.lstClases.Add(nuevaClase); 
        }

        public token getNombre()
        { 
            token retorno = lstAtributos.getToken(2); 
            return retorno;
        } 
    }
}
