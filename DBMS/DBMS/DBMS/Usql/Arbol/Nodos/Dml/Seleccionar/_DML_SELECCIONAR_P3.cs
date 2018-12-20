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
    class _DML_SELECCIONAR_P3 : _DML_SELECCIONAR_P
    {
        /*
         * tSeleccionar + LST_VALOR + tDe + LST_VAL_ID;
         */
        public _DML_SELECCIONAR_P3(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
            _LST_VAL_ID nodoIds = (_LST_VAL_ID)hijos[1];
            usqlTablaCartesiana lstTablas = nodoIds.getTablaFinal();





            /*
             * +-----------------
             * | ORDENAR
             * +-----------------
             */

            if ((ord.orden != -1) && !hayErrores())
            {
                celdaTitulo temp = getIndicesOrder(ord.val, lstTablas, lstAtributos.getToken(0));
                if (temp != null)
                {
                    try
                    {
                        if (ord.orden == 0)
                        {

                            var ordenando = lstTablas.filas.OrderBy(s => s.getItemValor(temp.posEnColumna).valor);
                            lstTablas.filas = ordenando.ToList<tupla>();

                        }
                        else
                        {
                            var ordenando = lstTablas.filas.OrderByDescending(s => s.getItemValor(temp.posEnColumna).valor);
                            lstTablas.filas = ordenando.ToList<tupla>();

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

            _LST_VALOR nodValor = (_LST_VALOR)hijos[0];
            Dictionary<string, celdaTitulo> cols = nodValor.getIndicesSelect(tablaEntornos, lstTablas, lstAtributos.getToken(0));

            var salidaConsulta = from s in lstTablas.filas select seleccionar(s, cols);
            IList<tupla> concatList = salidaConsulta.ToList<tupla>();
            lstTablas = getTablaFinal(concatList, lstTablas, cols);


            return lstTablas;
        }




    }
}
