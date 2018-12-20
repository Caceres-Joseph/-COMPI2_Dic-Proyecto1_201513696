
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

namespace DBMS.Usql.Arbol.Nodos.Expresion.E
{
    class opModelo
    {
        public _E hijo1;
        public _E hijo2;
        public token signo;
        public tablaSimbolos tabla;

        /*public opModelo(nodoModelo hijo11, nodoModelo hijo21, tablaSimbolos tabla)
        {
            this.hijo11 = hijo11;
            this.hijo21 = hijo21;
            this.tabla = tabla;
        }*/

        public opModelo(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo)
        {
            this.hijo1 = (_E)hijo1;
            this.hijo2 = (_E)hijo2;
            this.tabla = tabla;
            this.signo = signo;
        }


        public opModelo(nodoModelo hijo1, tablaSimbolos tabla, token signo)
        {
            this.hijo1 = (_E)hijo1;
            this.tabla = tabla;
            this.signo = signo;
        }


        /*
        |--------------------------------------------------------------------------
        | Retorno de indice
        |--------------------------------------------------------------------------
        */
        public int indiceColumnaEnTabla(token nombreCol, elementoEntorno elem)
        {

            String nombreColumna = "0||" + nombreCol.valLower;

            if (elem.tablaFrom.titulo.filaTitulo.ContainsKey(nombreColumna))
            {
                celdaTitulo temp = elem.tablaFrom.titulo.filaTitulo[nombreColumna];
                return temp.posEnColumna;
            }
            else
            {
                tabla.tablaErrores.insertErrorSemantic("No existe la columna:" + nombreCol.valLower + " en la tabla", nombreCol);
            }
            return -1;
        } 


        public int indiceColumnaEnTabla(token nombreCol, token nombreTabla, elementoEntorno elem)
        {
            //encontrar en que indice esta la tabla

            int indice = elem.tablaFrom.getIndiceDeTabla(nombreTabla);


            String nombreColumna = indice.ToString() + "||" + nombreCol.valLower;

            if (elem.tablaFrom.titulo.filaTitulo.ContainsKey(nombreColumna))
            {
                celdaTitulo temp = elem.tablaFrom.titulo.filaTitulo[nombreColumna];
                return temp.posEnColumna;
            }


            tabla.tablaErrores.insertErrorSemantic("No existe la columna:" + nombreCol.valLower + " en la tabla", nombreCol);
            return -1;
        }

        /*
        |--------------------------------------------------------------------------
        | Retorno de tabla cartesiana
        |--------------------------------------------------------------------------
        */
        public usqlTablaCartesiana getTablaCartesiana(elementoEntorno elem)
        {
            if (elem.tablaFrom == null)
            {
                Console.WriteLine("[" + signo.val + "]" + "Tabla form nula");
                return null;
            }
            else
            {


                //creo una tabla con la que voy  e estar concatenando las demas partes
                //para llamar al constructor copia
                usqlTablaCartesiana nuevaTablaRetorno = new usqlTablaCartesiana(elem.tablaFrom, 0);
                return nuevaTablaRetorno;
            }
        }

         






        public itemValor getTablaFinal(IList<tupla> concatList, usqlTablaCartesiana tempTabla)
        {
            itemValor retorno = new itemValor();

             
            tempTabla.filas = concatList;
            tempTabla.numIndices = concatList.Count;
            retorno.setValor(true);
            retorno.tablaCartesiana = tempTabla;
            return retorno;
        }

         


    }
}
