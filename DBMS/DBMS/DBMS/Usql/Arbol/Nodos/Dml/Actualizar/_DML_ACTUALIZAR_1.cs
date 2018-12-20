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
using DBMS.Usql.Arbol.Nodos.Dml.Seleccionar;
using DBMS.Usql.Arbol.Nodos.Listas.Valor;

namespace DBMS.Usql.Arbol.Nodos.Dml.Actualizar
{
    class _DML_ACTUALIZAR_1 : _DML_SELECCIONAR_P
    {
        /*
         * tActualizar + tTabla + LST_VAL_ID + sAbreParent + LST_VALOR + sCierraParent + tValores + sAbreParent + LST_VALOR + sCierraParent;

         */
        public _DML_ACTUALIZAR_1(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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


            //validando la misma cantidad,
            if (hijos[1].hijos.Count != hijos[2].hijos.Count)
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se esta recibiendo la misma cantidad que columnas indicadas en el actualizar", lstAtributos.getToken(0));
                return retorno;
            }


            //primero recupero la tabla
            usqlTablaCartesiana tablaFinal = getTablaCartesiana(tablaEntornos);

            //ahora recupero los valores
            _LST_VALOR nodoValores = (_LST_VALOR)hijos[2];
            lstValores listaValores = nodoValores.getLstValores(tablaEntornos);

            if (hayErrores())
                return retorno;

            //var salida = from s in tablaFinal.filas select actualiar(s, listaValores);


            foreach (tupla s in tablaFinal.filas)
            { 
                for (int i = 0; i < s.listaValores.Count; i++)
                {
                    itemValor destino = s.listaValores[i];
                    itemValor val = listaValores.listaValores[i]; 
                    destino.valor = val.valor;
                    destino.tipo = val.tipo; 
                }
            }

            //tablaFinal.imprimir();

            return retorno;
        }

        public tupla actualiar(tupla s, lstValores listaValores)
        {

            for (int i = 0; i < s.listaValores.Count; i++)
            {
                itemValor destino = s.listaValores[i];
                itemValor val = listaValores.listaValores[i];


                destino.valor = val.valor;
                destino.tipo = val.tipo;

            }

            return s;
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
            usqlTablaCartesiana lstTablas = nodoIds.getTablaFinal();



            /*
             * +-----------------
             * | SELECT
             * +-----------------
             */

            _LST_VALOR nodValor = (_LST_VALOR)hijos[1];
            Dictionary<string, celdaTitulo> cols = nodValor.getIndicesSelect(tablaEntornos, lstTablas, lstAtributos.getToken(0));

            var salidaConsulta = from s in lstTablas.filas select seleccionar(s, cols);
            IList<tupla> concatList = salidaConsulta.ToList<tupla>();
            lstTablas = getTablaFinal(concatList, lstTablas, cols);


            return lstTablas;
        }


    }
}
