using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.DB;
using DBMS.Usql.Arbol.Nodos.Expresion.E;

namespace DBMS.Usql.Arbol.Nodos.Dll
{
    class _DDL_CREAR_BASE : nodoModelo
    {
        /*
         * tCrear + tBase_datos + valId;
         */
        public _DDL_CREAR_BASE(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
            if (hayErrores())
                return retorno;

            token idBase = lstAtributos.getToken(2);

            //creando la base de datos
            baseDeDatos nuevaBase = new baseDeDatos(idBase, tablaSimbolos);
            
            
            //insertando la nueva base de datos
            tablaSimbolos.listaBaseDeDatos.insertar(nuevaBase);

            if (hayErrores())
                return retorno;

            //mensaje de exitoso
            tablaSimbolos.tablaMensajesUsql.println("La base de datos:" + idBase.val+ " se creo exitosamente");

            return retorno;
        }
    }
}
