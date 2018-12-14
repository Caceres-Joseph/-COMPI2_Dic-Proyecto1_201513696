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
    }
}
