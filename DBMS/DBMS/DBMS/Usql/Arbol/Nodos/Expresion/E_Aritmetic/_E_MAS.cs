﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E_Aritmetic
{
    class _E_MAS : nodoModelo
    {
        public _E_MAS(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
