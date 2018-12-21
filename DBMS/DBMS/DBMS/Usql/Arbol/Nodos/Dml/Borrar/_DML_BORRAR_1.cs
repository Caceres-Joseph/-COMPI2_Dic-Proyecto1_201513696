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
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.Tuplas;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Usql.Arbol.Nodos.Expresion.E;
using DBMS.Usql.Arbol.Nodos.Listas.Valor;

namespace DBMS.Usql.Arbol.Nodos.Dml.Borrar
{
    class _DML_BORRAR_1 : nodoModelo
    {
        /*
         * tBorrar + tEn + tTabla + LST_VAL_ID + tDonde + VALOR;
         */
        public _DML_BORRAR_1(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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


            usqlTablaCartesiana tablaQuery = getTablaCartesiana(tablaEntornos);





            //tablaQuery.imprimir();

            return retorno;
        }

        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Quitando columnas extras
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public tupla selectMenos(tupla t)
        {
            tupla nuevaTupla = new tupla();
            nuevaTupla.listaValores.AddRange(t.listaValores);
            nuevaTupla.listaValores.RemoveRange(t.listaValores.Count - 2, 2);
            return nuevaTupla;
        }

         
        /*
        |-------------------------------------------------------------------------------------------------------------------
        | GET TABLA
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public  usqlTablaCartesiana getTablaCartesiana(elementoEntorno tablaEntornos)
        {

            /*
             * +-----------------
             * | FROM
             * +-----------------
             */
            _LST_VAL_ID nodoIds = (_LST_VAL_ID)hijos[0];
            usqlTablaCartesiana lstTablas = nodoIds.getTablaFinal();
            //cargando la tabla cartesiana en el entorno para poder operarla
            tablaEntornos.tablaFrom = lstTablas;
            usqlTabla tablaOriginal = nodoIds.getTablaUsql();

            /*
             * +-----------------
             * | WHERE
             * +-----------------
             */
            _VALOR nodoValor = (_VALOR)hijos[1];

            itemValor val = nodoValor.operarTabla(tablaEntornos);
            if (val.tablaCartesiana == null)
            {
                println("tabla vacia");
                return null;
            }
            val.tablaCartesiana.listaNombreTablas = lstTablas.listaNombreTablas;
            val.tablaCartesiana.titulo = lstTablas.titulo;
             

            /*
             * +-----------------
             * | SELECT
             * +-----------------
             */

            var salidaConsulta = from s in val.tablaCartesiana.filas select selectMenos(s);
            val.tablaCartesiana.filas = salidaConsulta.ToList<tupla>();
            val.tablaCartesiana.titulo.filaTitulo.Remove("aux1");
            val.tablaCartesiana.titulo.filaTitulo.Remove("aux2");


            /*
             * +-----------------
             * | BORRAR
             * +-----------------
             */
              
            var salidaConsulta2 = tablaOriginal.filas.Except(val.tablaCartesiana.filas, new CompararTuplaCompleta());
            tablaOriginal.filas = salidaConsulta2.ToList<tupla>();

             
            return val.tablaCartesiana;
        }


    }
}
