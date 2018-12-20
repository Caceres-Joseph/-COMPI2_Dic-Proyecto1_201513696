using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Usql.Arbol.Nodos.Listas.Valor;

namespace DBMS.Usql.Arbol.Nodos.Dml.Seleccionar
{
    class _DML_SELECCIONAR_P4 : _DML_SELECCIONAR_P
    {
        /*
         * tSeleccionar + sPor + tDe + LST_VAL_ID;
         */
        public _DML_SELECCIONAR_P4(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
            var salidaConsulta = from s in lstTablas.filas select selectMenos(s);
            lstTablas.filas = salidaConsulta.ToList<tupla>();
            lstTablas.titulo.filaTitulo.Remove("aux1");
            lstTablas.titulo.filaTitulo.Remove("aux2"); 
            return lstTablas; 
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
