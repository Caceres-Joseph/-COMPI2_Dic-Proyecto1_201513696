﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Para
{
    class _SSL_PARA : nodoModelo
    {
        public _SSL_PARA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}