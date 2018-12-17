using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;

namespace DBMS.Usql.Arbol.Nodos.Dll
{
    class _DDL_COMPLEMENTO_P : _DDL_COMPLEMENTO
    {/*                 tNulo
                       | tNo + tNulo
                       | tAutoincrementable
                       | tLlave_primaria
                       | tLlave_foranea + valId
                       | tUnico
                       ;
        */
        public _DDL_COMPLEMENTO_P(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
         
        public override void cargarComplemento(celdaTitulo celda)
        { 
            token modificador = lstAtributos.getToken(0);
            celda.insertarModificador(modificador); 
        }

    }
}
