using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Selecciona
{
    class _SSL_SELECCIONA : nodoModelo
    {
        /*
         * SSL_SELECCIONA.Rule = SSL_SELECCIONA_1
                    | SSL_SELECCIONA_2
                    ;
         */
        public _SSL_SELECCIONA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
