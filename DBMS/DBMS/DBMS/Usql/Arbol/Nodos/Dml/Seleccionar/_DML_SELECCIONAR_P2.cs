using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Usql.Arbol.Nodos.Expresion.E;
using DBMS.Usql.Arbol.Nodos.Listas.Valor;

namespace DBMS.Usql.Arbol.Nodos.Dml.Seleccionar
{
    class _DML_SELECCIONAR_P2 : _DML_SELECCIONAR_P
    {
        /*
         * tSeleccionar + sPor + tDe + LST_VAL_ID + tDonde + VALOR;
         */
        public _DML_SELECCIONAR_P2(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

         

        /*
        |-------------------------------------------------------------------------------------------------------------------
        | GET TABLA
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override usqlTablaCartesiana getTablaCartesiana(elementoEntorno tablaEntornos, nodoOrdenar ord)
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
             * | ORDENAR
             * +-----------------
             */

            if ((ord.orden != -1) && !hayErrores())
            {
                celdaTitulo temp = getIndicesOrder(ord.val, val.tablaCartesiana, lstAtributos.getToken(0));
                if (temp != null)
                {
                    try
                    {
                        if (ord.orden == 0)
                        {

                            var ordenando = val.tablaCartesiana.filas.OrderBy(s => s.getItemValor(temp.posEnColumna).valor);
                            val.tablaCartesiana.filas = ordenando.ToList<tupla>();

                        }
                        else
                        {
                            var ordenando = val.tablaCartesiana.filas.OrderByDescending(s => s.getItemValor(temp.posEnColumna).valor);
                            val.tablaCartesiana.filas = ordenando.ToList<tupla>();

                        }
                    }
                    catch (Exception e)
                    {
                        println("error al ordenar" + e);
                    }
                }
            }


            /*
             * +-----------------
             * | SELECT
             * +-----------------
             */

            var salidaConsulta = from s in val.tablaCartesiana.filas select selectMenos(s);
            val.tablaCartesiana.filas = salidaConsulta.ToList<tupla>();
            val.tablaCartesiana.titulo.filaTitulo.Remove("aux1");
            val.tablaCartesiana.titulo.filaTitulo.Remove("aux2");
            return val.tablaCartesiana;
        }



        public tupla selectMenos(tupla t)
        {
            tupla nuevaTupla = new tupla();
            nuevaTupla.listaValores.AddRange(t.listaValores);
            nuevaTupla.listaValores.RemoveRange(t.listaValores.Count - 2, 2); 
            return nuevaTupla;
        }

    }
}
