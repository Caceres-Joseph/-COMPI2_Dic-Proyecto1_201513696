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
        public _SSL_SELECCIONA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
