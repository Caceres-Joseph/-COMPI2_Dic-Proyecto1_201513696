﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Alterar
{
    class _DML_ALT_OBJ_ADD : nodoModelo
    {
        public _DML_ALT_OBJ_ADD(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
