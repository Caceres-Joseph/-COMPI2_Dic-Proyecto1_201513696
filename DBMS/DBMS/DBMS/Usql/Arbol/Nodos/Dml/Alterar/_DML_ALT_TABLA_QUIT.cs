using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.DB;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Usql.Arbol.Nodos.Dml.Seleccionar;
using DBMS.Usql.Arbol.Nodos.Listas.Atributo;
using DBMS.Usql.Arbol.Nodos.Listas.Valor;

namespace DBMS.Usql.Arbol.Nodos.Dml.Alterar
{
    class _DML_ALT_TABLA_QUIT : nodoModelo
    {
        /*
         * tAlterar + tTabla + LST_VAL_ID + tQuitar + LST_VALOR;
         */
        public _DML_ALT_TABLA_QUIT(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se ha seleccionado una base de datos para realizar la operacion de alterar tabla", lstAtributos.getToken(0));
                return retorno;
            }


            //primero recupero la tabla
            usqlTablaCartesiana tablaFinal = getTablaCartesiana(tablaEntornos);
            


            //mensaje de exitoso
            tablaSimbolos.tablaMensajesUsql.println("La tabla:   se altero exitosamente");

            return retorno;
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | ELIMINAR FILAS Y TUTIULO
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public void eliminandoColumnas(usqlTablaCartesiana tablaFinal, Dictionary<string, celdaTitulo> cols)
        {
            foreach (tupla item in tablaFinal.filas)
            { 
                foreach (KeyValuePair<string, celdaTitulo> entry in cols)
                {
                    //eliminando la posicion indicada
                    item.listaValores.RemoveAt(entry.Value.posEnColumna);
                }
            }
        }

        public void eliminarColumnasTitulo(usqlTabla tablaFinal, Dictionary<string, celdaTitulo> cols)
        {
            foreach (KeyValuePair<string, celdaTitulo> entry in cols)
            { 
                String clave = entry.Key.Replace("0||", "");
                if (tablaFinal.titulo.filaTitulo.ContainsKey(clave))
                {
                    tablaFinal.titulo.filaTitulo.Remove(clave);
                }
                else
                {
                    println("No viene con el nombre de la clave");
                }
            }
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | GET TABLA
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public usqlTablaCartesiana getTablaCartesiana(elementoEntorno tablaEntornos)
        {

            /*
             * +-----------------
             * | FROM
             * +-----------------
             */
            _LST_VAL_ID nodoIds = (_LST_VAL_ID)hijos[0];
            usqlTablaCartesiana lstTablas = nodoIds.getTablaFinalAlter();

            usqlTabla tablaOrigina = nodoIds.getTablaUsql();


            /*
             * +-----------------
             * | SELECT
             * +-----------------
             */

            _LST_VALOR nodValor = (_LST_VALOR)hijos[1];
            Dictionary<string, celdaTitulo> cols = nodValor.getIndicesSelect(tablaEntornos, lstTablas, lstAtributos.getToken(0));


            /*
             * +-----------------
             * | QUITANDO COLUMNAS
             * +-----------------
             */
            eliminandoColumnas(lstTablas, cols);
            eliminarColumnasTitulo(tablaOrigina, cols);

            return lstTablas;
        }
    }
}
