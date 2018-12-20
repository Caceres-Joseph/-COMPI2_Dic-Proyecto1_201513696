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
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Usql.Arbol.Nodos.Expresion.E;

namespace DBMS.Usql.Arbol.Nodos.Dml.Seleccionar
{
    class _DML_ORDENAR : nodoModelo
    {
        /*
         * 
            DML_ORDENAR.Rule =  tOrdenar + tPor + VALOR + tAsc
                                    | tOrdenar + tPor + VALOR + tDesc
                                    | tOrdenar + tPor + VALOR
         */
        public _DML_ORDENAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }




        public nodoOrdenar getIndicePorOrdenar(elementoEntorno elemento)
        {

            nodoOrdenar retorno = new nodoOrdenar();

            _VALOR nodoVal = (_VALOR)hijos[0];
            itemValor temporal1 = nodoVal.getValor(elemento, new token());


            retorno.val = temporal1;

            /*
             * Indicando el modo de ordenamiento
             */


            if (lstAtributos.listaAtributos.Count == 3)
            {
                if (lstAtributos.getToken(2).valLower.Equals("asc"))
                {
                    retorno.orden = 0;
                }
                else
                {
                    retorno.orden = 1;
                }
            }
            else
            {
                retorno.orden = 0;
            }

            return retorno;
        }




        /*
        |--------------------------------------------------------------------------
        | Retorno de indice
        |--------------------------------------------------------------------------
        */
        public int indiceColumnaEnTabla(token nombreCol, usqlTablaCartesiana tablaFrom)
        {

            String nombreColumna = "0||" + nombreCol.valLower;
            if (tablaFrom.titulo.filaTitulo.ContainsKey(nombreColumna))
            {
                celdaTitulo temp = tablaFrom.titulo.filaTitulo[nombreColumna];
                return temp.posEnColumna;
            }

            tablaSimbolos.tablaErrores.insertErrorSemantic("No existe la columna:" + nombreCol.valLower + " en la tabla", nombreCol);
            return -1;
        }


        public int indiceColumnaEnTabla(token nombreCol, token nombreTabla, usqlTablaCartesiana tablaFrom)
        {
            int indice = tablaFrom.getIndiceDeTabla(nombreTabla);
            String nombreColumna = indice.ToString() + "||" + nombreCol.valLower;

            if (tablaFrom.titulo.filaTitulo.ContainsKey(nombreColumna))
            {
                celdaTitulo temp = tablaFrom.titulo.filaTitulo[nombreColumna];

                return temp.posEnColumna;
            }
            tablaSimbolos.tablaErrores.insertErrorSemantic("No existe la columna:" + nombreCol.valLower + " en la tabla", nombreCol);
            return -1;
        }

    }

    class nodoOrdenar
    {
        public itemValor val = new itemValor();
        public int orden = -1;

    }
}
