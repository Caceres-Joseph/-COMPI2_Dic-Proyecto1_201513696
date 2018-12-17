using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Usql.Arbol.Nodos.Dll;
using DBMS.Usql.Arbol.Nodos.Inicio;

namespace DBMS.Usql.Arbol.Nodos.Listas.Atributo
{
    class _ATRIBUTO : _ARIBUTO1
    {
        /*
         * ATRIBUTO.Rule= TIPO + valId
                    | TIPO + valId + DDL_COMPLEMENTO
                   
         */


        public _ATRIBUTO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Metodos
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public celdaTitulo getCeldaTitulo()
        {
            token idCela = lstAtributos.getToken(0);
            celdaTitulo nuevaCelda = new celdaTitulo(tablaSimbolos, idCela);



            //agregando los modificadores si tiene
            if (hijos.Count==2)
            {

                //aquí se cargan los complementos en la celda
                _DDL_COMPLEMENTO comp = (_DDL_COMPLEMENTO)hijos[1];
                comp.cargarComplemento(nuevaCelda);
                
            }

            return nuevaCelda;
        }
    }
}
