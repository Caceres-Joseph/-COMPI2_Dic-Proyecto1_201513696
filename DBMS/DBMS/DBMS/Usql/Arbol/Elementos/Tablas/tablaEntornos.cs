using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas
{
    class tablaEntornos
    {
        public elementoEntorno raiz;
        public tablaSimbolos tabla;
        public tablaEntornos(tablaSimbolos tabla, objetoClase este)
        {
            raiz = new elementoEntorno(null, tabla, "global");
        }


        public void imprimir()
        {

            raiz.imprimir();
            return;
            elementoEntorno actual = raiz;

            do
            {

                actual.imprimir();
                actual = actual.anterior;
            } while (actual.anterior != null);
        }

    }
}
