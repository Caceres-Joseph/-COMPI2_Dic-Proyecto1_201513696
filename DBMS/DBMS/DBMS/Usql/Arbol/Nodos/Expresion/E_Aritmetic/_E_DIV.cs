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
using DBMS.Usql.Arbol.Nodos.Expresion.E.OpeAritmetica;
namespace DBMS.Usql.Arbol.Nodos.Expresion.E_Aritmetic
{
    class _E_DIV : division
    {
        public _E_DIV(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }

         

        /*
        |--------------------------------------------------------------------------
        |  VALOR VALOR
        |--------------------------------------------------------------------------
        */

        public override itemValor operarValorValor(elementoEntorno entorno)
        {

            return opDivision(entorno);
        }

        /*
        |--------------------------------------------------------------------------
        | Sobrescribiendo el SELECCIONAR
        |--------------------------------------------------------------------------
        */


        public override tupla Seleccionar(tupla s, itemValor s1, itemValor s2, int columnasExtras)
        {

            //primero intento parsear los valores a decimal

            double val1 = s1.getDecimal();
            double val2 = s2.getDecimal();

            double result = val1 / val2;

            //obteniendo el penultimo
            itemValor val = s.listaValores[s.listaValores.Count - 2];
            val.setValor(result);

            return s;
        }

        /*
        |--------------------------------------------------------------------------
        | OPERACION
        |--------------------------------------------------------------------------
        */
        public itemValor divUsql(String ambito, elementoEntorno elem, token tokLinea)
        {

            itemValor retorno = operarRelacional(ambito, elem, tokLinea);

            //indico que opere la ultima 
            retorno.setColumnaExtra();
            return retorno;
        }

        public void println(String mensaje)
        {
            Console.WriteLine("[_E_DIVISION]" + mensaje);
        }

    }
}
