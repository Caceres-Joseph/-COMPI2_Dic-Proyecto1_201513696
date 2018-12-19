using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using DBMS.Usql.Arbol.Nodos.Expresion.E;
using DBMS.Usql.Arbol.Nodos.Listas.Valor;

namespace DBMS.Usql.Arbol.Nodos.Dml.Seleccionar
{
    class _DML_SELECCIONAR_P2 : nodoModelo
    {
        /*
         * tSeleccionar + sPor + tDe + LST_VAL_ID + tDonde + VALOR;
         */
        public _DML_SELECCIONAR_P2(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            //producto cartesiano entre tablas
            _LST_VAL_ID nodoIds = (_LST_VAL_ID)hijos[0];
            usqlTablaCartesiana lstTablas = nodoIds.getTablaFinal();
            //cargando la tabla cartesiana en el entorno para poder operarla
            tablaEntornos.tablaFrom = lstTablas;


            //operando la tabla con el donde
            _VALOR nodoValor = (_VALOR)hijos[1];

            itemValor val= nodoValor.operarTabla(tablaEntornos);

            if (val.tablaCartesiana!=null)
            {  
                val.tablaCartesiana.imprimir();
            }
            else
            {
                println("No regresó una tabla pvto");
            }

            return retorno;
        }




    }
}
