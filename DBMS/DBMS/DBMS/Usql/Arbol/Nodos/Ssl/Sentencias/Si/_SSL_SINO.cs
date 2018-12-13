﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Nodos.Inicio;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Si
{
    class _SSL_SINO : nodoModelo
    {
        /*
         * tSino + sAbreLlave + LST_CUERPO + sCierraLlave;
         */
        public _SSL_SINO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

         
        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override itemRetorno ejecutar(elementoEntorno elementoEntor)
        /*
        |---------------------------- 
        | EJECUTAR 
        |----------------------------
        | 0 = normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */
        { 
            itemRetorno retorno = new itemRetorno(0);
            if (hayErrores())
                return retorno;


            _LST_CUERPO nodoCuerpo = (_LST_CUERPO)getNodo("LST_CUERPO"); 
            return nodoCuerpo.ejecutar(elementoEntor);

              

        }

    }
}
