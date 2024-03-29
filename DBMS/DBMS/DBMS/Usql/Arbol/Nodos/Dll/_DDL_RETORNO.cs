﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Nodos.Expresion.E;

namespace DBMS.Usql.Arbol.Nodos.Dll
{
    class _DDL_RETORNO : nodoModelo
    {
        /*
         * tRetorno + VALOR
         */
        public _DDL_RETORNO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            itemRetorno retorno = new itemRetorno(1);
            if (hayErrores())
                return retorno;

            nodoModelo nodoTemp = getNodo("VALOR");
            if (nodoTemp != null)
            {
                _VALOR val = (_VALOR)nodoTemp;
                itemValor tempValor = val.getValor(tablaEntornos, lstAtributos.getToken(0));

                retorno.setValueRetorno(tempValor);
                return retorno;

            }
            else
            {
                Console.WriteLine(nombre+"  Nodo nulo:");
                return retorno;
            }
         } 
    }
}
