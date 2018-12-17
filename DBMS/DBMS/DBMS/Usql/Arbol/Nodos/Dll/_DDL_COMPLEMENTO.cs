using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;

namespace DBMS.Usql.Arbol.Nodos.Dll
{
    class _DDL_COMPLEMENTO : nodoModelo
    {
        /*
         * MakePlusRule(DDL_COMPLEMENTO, DDL_COMPLEMENTO_P)
         */
        public _DDL_COMPLEMENTO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

        public virtual void cargarComplemento(celdaTitulo celda)
        {
            foreach(_DDL_COMPLEMENTO comp in hijos)
            { 
                comp.cargarComplemento(celda);
            }

        }
    }
}
