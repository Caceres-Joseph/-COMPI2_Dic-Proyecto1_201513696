using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Nodos.Inicio;

namespace DBMS.Usql.Arbol.Nodos.Listas.Parametro
{
    /*
     * TIPO + sArroba + valId;
     */
    class _PARAMETRO : nodoModelo
    {
        public _PARAMETRO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Carga de parametros
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override void cargarPolimorfismo(elementoPolimorfo elem)
        {
             
            if (hayErrores())
                return;

            nodoModelo tempNodo = getNodo("TIPO");
            if (tempNodo != null)
            {
                _TIPO temp = (_TIPO)tempNodo; 
                elem.insertarParametro(lstAtributos.getToken(1), temp.getTipo() , 0); 
            }
        }
         

    }
}
