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

namespace DBMS.Usql.Arbol.Nodos.Dml.Seleccionar
{
    class _DML_SELECCIONAR_P : _DML_SELECCIONAR
    {
        /*
         * DML_SELECCIONAR_P.Rule = DML_SELECCIONAR_P1
                                     | DML_SELECCIONAR_P2
                                     | DML_SELECCIONAR_P3
                                     | DML_SELECCIONAR_P4
                                     ;
        */
        public _DML_SELECCIONAR_P(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | GET TABLA
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public virtual usqlTablaCartesiana getTablaCartesiana(elementoEntorno entorn, nodoOrdenar ordo)
        {

            foreach (_DML_SELECCIONAR_P retorno in hijos)
            {
                return retorno.getTablaCartesiana(entorn, ordo);
            }
            return null;
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | PaRA el ordenar
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public celdaTitulo getIndicesOrder(itemValor temporal1, usqlTablaCartesiana tablaFrom, token tokLinea)
        {


            if (temporal1.isTypeCartColumna())
            {
                String nombreColumna = "0||" + temporal1.nombreCartColumna.valLower;
                if (tablaFrom.titulo.filaTitulo.ContainsKey(nombreColumna))
                {
                    celdaTitulo temp = tablaFrom.titulo.filaTitulo[nombreColumna];
                    return temp;
                }

                tablaSimbolos.tablaErrores.insertErrorSemantic("No existe la columna:" + temporal1.nombreCartColumna.valLower + " en la tabla", tokLinea);
                return null;
            }
            else if (temporal1.isTypeCartTablaColumna())
            {
                int indice = tablaFrom.getIndiceDeTabla(temporal1.nombreCartTabla);
                String nombreColumna = indice.ToString() + "||" + temporal1.nombreCartColumna.valLower;
                if (tablaFrom.titulo.filaTitulo.ContainsKey(nombreColumna))
                {
                    celdaTitulo temp = tablaFrom.titulo.filaTitulo[nombreColumna];
                    return temp;
                }

                tablaSimbolos.tablaErrores.insertErrorSemantic("No existe la columna:" + temporal1.nombreCartColumna.valLower + " en la tabla", tokLinea);
                return null;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No puede venir el tipo:" + temporal1.getTipo() + " en especificacion de columna de un select", tokLinea);
                return null;
            }
        }

    }
}
