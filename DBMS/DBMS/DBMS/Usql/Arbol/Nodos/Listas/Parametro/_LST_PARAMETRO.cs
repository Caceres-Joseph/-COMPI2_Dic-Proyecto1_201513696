﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Listas.Parametro
{
    class _LST_PARAMETRO : nodoModelo
    {
        public _LST_PARAMETRO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
