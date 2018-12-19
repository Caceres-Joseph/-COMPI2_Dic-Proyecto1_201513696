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
using DBMS.Usql.Arbol.Nodos.Expresion.E.Operelacional;
using DBMS.Usql.Arbol.Nodos.Expresion.E.Oprelacional2;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E_Rel
{
    class _E_MAYOR_QUE : MayorQue
    {
        public _E_MAYOR_QUE(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }

        /*
        |--------------------------------------------------------------------------
        |  VALOR VALOR
        |--------------------------------------------------------------------------
        */

        public override itemValor operarValorValor(elementoEntorno entorno)
        {

            return opMayorQue("mayor Que",entorno);
        }
        /*
        |--------------------------------------------------------------------------
        | Sobrescribiendo el DONDE
        |--------------------------------------------------------------------------
        */
        SelectMayorQue mayorQue = new SelectMayorQue();
        public override bool Donde(itemValor s1, itemValor s2)
        {

            itemValor resultado = mayorQue.opMayorQue(s1, s2, "MAYOR QUE");
            if (resultado.isTypeBooleano())
            {
                return resultado.getBooleano();
            }
            else
            {
                return false;
            }
        }

        /*
        |--------------------------------------------------------------------------
        | OPERACION
        |--------------------------------------------------------------------------
        */

        public itemValor mayorQueUsql(String ambito, elementoEntorno elem, token tokLinea)
        { 
            return operarRelacional(ambito, elem, tokLinea); 
        }


        public void println(String mensaje)
        {
            Console.WriteLine("[_E_MAYOR_QUE]" + mensaje);
        }

    }
}
