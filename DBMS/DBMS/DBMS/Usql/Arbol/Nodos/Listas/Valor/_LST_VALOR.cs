using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Usql.Arbol.Nodos.Expresion.E;

namespace DBMS.Usql.Arbol.Nodos.Listas.Valor
{
    class _LST_VALOR : nodoModelo
    {
        /*
         * 
            LST_VALOR.Rule = MakePlusRule(LST_VALOR, sComa, VALOR);
         */
        public _LST_VALOR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }





        public lstValores getLstValores(elementoEntorno elemento)
        {

            lstValores retorno = new lstValores();

            foreach (nodoModelo hijo in hijos)
            {
                _VALOR temp = (_VALOR)hijo;
                itemValor temporal1 = temp.getValor(elemento, new token());

                retorno.insertar(temporal1);
            }
            return retorno;

        }



        /*
         * Solo debo aceptar columna y columnaTabla
         */
        public Dictionary<String, celdaTitulo> getIndicesSelect(elementoEntorno elemento, usqlTablaCartesiana tablaFinal, token tokLinea)
        {
            Dictionary<string, celdaTitulo> retorno = new Dictionary<string, celdaTitulo>();


            foreach (nodoModelo hijo in hijos)
            {
                _VALOR temp = (_VALOR)hijo;
                itemValor temporal1 = temp.getValor(elemento, new token());

                if (temporal1.isTypeCartColumna())
                {
                    celdaTitulo indice = indiceColumnaEnTabla(temporal1.nombreCartColumna, tablaFinal, retorno);

                }
                else if (temporal1.isTypeCartTablaColumna())
                {
                    celdaTitulo indice = indiceColumnaEnTabla(temporal1.nombreCartColumna, temporal1.nombreCartTabla, tablaFinal, retorno);

                }
                else
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("No puede venir el tipo:" + temporal1.getTipo() + " en especificacion de columna de un select", tokLinea);
                    return retorno;
                }

                if (hayErrores())
                    return retorno;
            }
            return retorno;
        }



        /*
        |--------------------------------------------------------------------------
        | Retorno de indice
        |--------------------------------------------------------------------------
        */
        public celdaTitulo indiceColumnaEnTabla(token nombreCol, usqlTablaCartesiana tablaFrom, Dictionary<string, celdaTitulo> retorno)
        {

            String nombreColumna = "0||" + nombreCol.valLower;
            if (tablaFrom.titulo.filaTitulo.ContainsKey(nombreColumna))
            {
                celdaTitulo temp = tablaFrom.titulo.filaTitulo[nombreColumna];
                retorno.Add(nombreColumna, temp);
                return temp;
            }

            tablaSimbolos.tablaErrores.insertErrorSemantic("No existe la columna:" + nombreCol.valLower + " en la tabla", nombreCol);
            return null;
        }


        public celdaTitulo indiceColumnaEnTabla(token nombreCol, token nombreTabla, usqlTablaCartesiana tablaFrom, Dictionary<string, celdaTitulo> retorno)
        {
            int indice = tablaFrom.getIndiceDeTabla(nombreTabla);
            String nombreColumna = indice.ToString() + "||" + nombreCol.valLower;

            if (tablaFrom.titulo.filaTitulo.ContainsKey(nombreColumna))
            {
                celdaTitulo temp = tablaFrom.titulo.filaTitulo[nombreColumna];


                //verificando si se repiten las columnas
                if (retorno.ContainsKey(nombreColumna))
                {
                    Random rnd = new Random();
                    int month = rnd.Next(999);
                    retorno.Add(month.ToString() + nombreColumna, temp);
                }
                else
                {
                    retorno.Add(nombreColumna, temp);
                }
                return temp;
            }

            tablaSimbolos.tablaErrores.insertErrorSemantic("No existe la columna:" + nombreCol.valLower + " en la tabla", nombreCol);
            return null;
        }


    }
}
