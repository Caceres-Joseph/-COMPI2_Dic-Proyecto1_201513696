using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.DB;

namespace DBMS.Usql.Arbol.Nodos.Dml.Usar
{
    class _DML_USAR : nodoModelo
    {
        /*
         * tUsar + valId;
         */
        public _DML_USAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override itemRetorno ejecutar(elementoEntorno tablaEntornos)
        /*
        |---------------------------- 
        | EJECUTAR 
        |----------------------------
        | 0= normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */
        {

            itemRetorno retorno = new itemRetorno(0);
            if (hayErrores())
                return retorno;

            token idBase = lstAtributos.getToken(1);

            tablaSimbolos.listaBaseDeDatos.usarBase(idBase);
            //mensaje de exitoso
            tablaSimbolos.tablaMensajesUsql.println("Se seleccionó la  base de datos:" + idBase.val );

            return retorno;
        }
    }
}
