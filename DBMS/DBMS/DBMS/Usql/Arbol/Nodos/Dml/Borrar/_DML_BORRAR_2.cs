using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Borrar
{
    class _DML_BORRAR_2 : nodoModelo
    {
        /*
         * tBorrar + tEn + tTabla + valId;
         */
        public _DML_BORRAR_2(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            if (tablaSimbolos.listaBaseDeDatos.usar == null)
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se ha seleccionado una base de datos para realizar la operacion de insertar nueva tabla", lstAtributos.getToken(0));
                return retorno;
            }

            //recupero la tabla
            token idTabla = lstAtributos.getToken(3);
            usqlTabla tablaFinal = tablaSimbolos.listaBaseDeDatos.usar.getTabla(idTabla);
            if (hayErrores())
                return retorno;

            //vaciando el contenido de la tabla
            tablaFinal.filas = new List<tupla>();


            return retorno;
        } 
    }
}
