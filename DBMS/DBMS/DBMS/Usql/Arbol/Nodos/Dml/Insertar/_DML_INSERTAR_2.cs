using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Insertar
{
    class _DML_INSERTAR_2 : nodoModelo
    {
        /*
         * tInsertar + tEn + tTabla + valId + sAbreParent + LST_VAL_ID + sCierraParent + tValores + sAbreParent + LST_VALOR + sCierraParent;
         */
        public _DML_INSERTAR_2(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
