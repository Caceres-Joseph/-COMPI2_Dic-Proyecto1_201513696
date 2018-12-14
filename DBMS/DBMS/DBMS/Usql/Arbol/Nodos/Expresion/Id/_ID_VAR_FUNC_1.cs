using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;

namespace DBMS.Usql.Arbol.Nodos.Expresion.Id
{
    class _ID_VAR_FUNC_1 : _ID_VAR_FUNC
    {
        /*
         * ID_VAR_FUNC_1.Rule =ID_VAR_FUNC + LST_PUNTOS;
         */
        public _ID_VAR_FUNC_1(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | DESTINO
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override itemEntorno getDestino(elementoEntorno elementoEntorno)
        {

            nodoModelo nod = hijos[0];
            nodoModelo nod2 = hijos[1];
            if(!(nod is _ID_VAR_FUNC)||!(nod2 is _LST_PUNTOS))
            {
                Console.WriteLine("[IdVarFun1]Error de parseo nodo");
                return null;
            }


            _ID_VAR_FUNC nodo1 = (_ID_VAR_FUNC)hijos[0];
            _LST_PUNTOS nodo2 = (_LST_PUNTOS)hijos[1];


            itemValor destino1 = nodo1.getValor(elementoEntorno);
            itemEntorno destino2 = nodo2.getDestino(elementoEntorno, destino1);


            return destino2;

        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Recuperando valor
        |-------------------------------------------------------------------------------------------------------------------
        |
        */


        public override itemValor getValor(elementoEntorno elementoEntorno)
        {

            nodoModelo nod = hijos[0];
            nodoModelo nod2 = hijos[1];
            if (!(nod is _ID_VAR_FUNC) || !(nod2 is _LST_PUNTOS))
            {
                Console.WriteLine("[IdVarFun1]Error de parseo nodo");
                return null;
            }


            _ID_VAR_FUNC nodo1 = (_ID_VAR_FUNC)hijos[0];
            _LST_PUNTOS nodo2 = (_LST_PUNTOS)hijos[1];


            itemValor destino1 = nodo1.getValor(elementoEntorno);
            itemValor destino2 = nodo2.getValor(elementoEntorno, destino1);


            return destino2;

        }
    }
}
