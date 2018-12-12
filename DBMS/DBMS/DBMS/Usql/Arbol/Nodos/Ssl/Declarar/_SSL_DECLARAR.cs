using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Declarar
{
    /*
     * SSL_DECLARAR.Rule= tDeclarar+ LST_VARS+ TIPO +VAL
                    | tDeclarar+ LST_VARS+ TIPO
     */
    class _SSL_DECLARAR : nodoModelo
    {
        public _SSL_DECLARAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }




    }
}
