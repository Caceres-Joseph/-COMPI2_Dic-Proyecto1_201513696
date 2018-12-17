using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;

namespace DBMS.Usql.Arbol.Nodos.Listas.Atributo
{
    /*
            LST_ATRIBUTO.Rule = MakePlusRule(LST_ATRIBUTO, sComa, ATRIBUTO);
     */
    class _LST_ATRIBUTO : nodoModelo
    {
        public _LST_ATRIBUTO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | PARA CREAR TABLAS
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public void insertarCeldas(tuplaTitulo tuplaTitulo)
        { 

            foreach (_ATRIBUTO atrib in hijos)
            {
                tuplaTitulo.insertar(atrib.getCeldaTitulo());

            }
        }

    }
}
