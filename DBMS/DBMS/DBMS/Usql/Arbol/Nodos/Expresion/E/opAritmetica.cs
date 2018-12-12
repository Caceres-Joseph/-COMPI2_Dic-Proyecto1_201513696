using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E
{
    class opAritmetica : opModelo
    {
        public opAritmetica(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }
         
    }
}
