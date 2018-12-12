using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Nodos.Expresion.E;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Asignar
{
    class _VAL : nodoModelo
    {
        public _VAL(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        public itemValor getValor(elementoEntorno elemento, token tipo)
        {


            itemValor retorno = new itemValor();
            retorno.setTypeNulo();


            if (hayErrores())
                return retorno;

            if (hijos.Count > 0)
            {
                nodoModelo hijo = hijos[0];
                _VALOR ope = (_VALOR)hijo;
                return ope.getValor(elemento, tipo);
            }

            return retorno;
        }

        public token getTokenIgual()
        {
            return lstAtributos.getToken(0);
        }
    }
}
