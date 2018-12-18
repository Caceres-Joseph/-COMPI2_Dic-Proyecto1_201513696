using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using DBMS.Usql.Arbol.Nodos.Expresion.E;
using DBMS.Usql.Arbol.Nodos.Listas.Valor;

namespace DBMS.Usql.Arbol.Nodos.Dml.Seleccionar
{
    class _DML_SELECCIONAR_P3 : nodoModelo
    {
        /*
         * tSeleccionar + LST_VALOR + tDe + LST_VAL_ID;
         */
        public _DML_SELECCIONAR_P3(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



    }
}
