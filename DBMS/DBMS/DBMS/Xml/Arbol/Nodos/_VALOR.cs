using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Xml.Arbol.Nodos
{
    class _VALOR : nodoModeloXml
    {
        /*
         * VALOR.Rule = E;
         */
        public _VALOR(string nombre) : base(nombre)
        {
        }


        public itemValor getValor()
        { 
            _E nodoE = (_E)hijos[0];

            return nodoE.getValor();
             
        }
    }
}
