using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E
{
    class _VALOR : nodoModelo
    {
        public _VALOR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public itemValor getValor(elementoEntorno elementoEntor, token tipo)
        {
             
            itemValor retorno = new itemValor();
            retorno.setTypeNulo();
             


            if (hayErrores())
                return retorno;
            nodoModelo hijo = hijos[0];
            _E ope = (_E)hijo;
            return ope.getValor(elementoEntor); 
        }



        public itemValor getValor(elementoEntorno elementoEntor)
        {

            itemValor retorno = new itemValor();
            retorno.setTypeNulo();



            if (hayErrores())
                return retorno;
            nodoModelo hijo = hijos[0];
            _E ope = (_E)hijo;
            return ope.getValor(elementoEntor);
        }
    }
}
