using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Listas.Valor
{
    /*VARS.Rule = sArroba + valId;
     */
    class _VARS : nodoModelo
    {
        public _VARS(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public token getId()
        {
            return lstAtributos.getToken(1);
        }
    }
}
