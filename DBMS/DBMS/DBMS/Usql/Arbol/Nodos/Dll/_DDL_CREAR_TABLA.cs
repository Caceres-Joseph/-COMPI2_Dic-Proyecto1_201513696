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
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Usql.Arbol.Nodos.Listas.Atributo;

namespace DBMS.Usql.Arbol.Nodos.Dll
{
    class _DDL_CREAR_TABLA : nodoModelo
    {
        /*
         * tCrear + tTabla + valId + sAbreParent + LST_ATRIBUTO + sCierraParent
         */
        public _DDL_CREAR_TABLA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            if(tablaSimbolos.listaBaseDeDatos.usar==null)
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se ha seleccionado una base de datos para realizar la operacion de insertar nueva tabla", lstAtributos.getToken(2));
                return retorno;
            }



            //nombre de la tabla
            token idTabla = lstAtributos.getToken(2);
            
            
            //filas de la tabla
            tuplaTitulo tuplaTitulo = new tuplaTitulo(tablaSimbolos);
            _LST_ATRIBUTO atribs = (_LST_ATRIBUTO)hijos[0];
            tuplaTitulo.filaTitulo = atribs.getLstCeldas();

            //creando la tabla
            usqlTabla nuevaTabla = new usqlTabla(idTabla, tuplaTitulo, tablaSimbolos);

            //guardando la tabla en la base de datos
            tablaSimbolos.listaBaseDeDatos.usar.insertarTabla(nuevaTabla);



            if (hayErrores())
                return retorno;
             
            //mensaje de exitoso
            tablaSimbolos.tablaMensajesUsql.println("La tabla: " + idTabla.val + " se creo exitosamente");

            return retorno;
        }
    }
}
