using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;

namespace DBMS.Usql.Arbol.Nodos.Listas.Valor
{
    class _LST_VAL_ID : nodoModelo
    {
        /*
         * MakePlusRule(LST_VAL_ID, sComa, valId)
         */
        public _LST_VAL_ID(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public lstAtributos getLstVal()
        {

            return lstAtributos;
        }
    }
}
