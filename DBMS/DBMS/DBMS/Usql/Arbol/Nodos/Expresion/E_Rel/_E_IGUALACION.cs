﻿using System;
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
    class _E_IGUALACION : IgualQue
    {


        public _E_IGUALACION(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }

        /*
        |--------------------------------------------------------------------------
        |  VALOR VALOR
        |--------------------------------------------------------------------------
        */

        public override itemValor operarValorValor(elementoEntorno entorno)
        {

            return opIgualacion("igualacion",entorno);
        }
        /*
        |--------------------------------------------------------------------------
        | Sobrescribiendo el DONDE
        |--------------------------------------------------------------------------
        */
        SelectIgualQue igualQue = new SelectIgualQue();
        public override bool Donde(itemValor s1, itemValor s2)
        {

            itemValor resultado = igualQue.opIgualacionSelect(s1, s2, "IGUALACION");
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
        public itemValor igualacionUsql(String ambito, elementoEntorno elem, token tokLinea)
        {

            return operarRelacional(ambito, elem, tokLinea);
        }


        public void println(String mensaje)
        {
            Console.WriteLine("[_E_IGUALACION]" + mensaje);
        }
    }
}
