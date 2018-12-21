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
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Usql.Arbol.Nodos.Listas.Atributo;

namespace DBMS.Usql.Arbol.Nodos.Dml.Alterar
{
    class _DML_ALT_TABLA_ADD : nodoModelo
    {
        /*
         * tAlterar + tTabla + valId + tAgregar + sAbreParent + LST_ATRIBUTO + sCierraParent;
         */
        public _DML_ALT_TABLA_ADD(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            if (tablaSimbolos.listaBaseDeDatos.usar == null)
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se ha seleccionado una base de datos para realizar la operacion de alterar tabla", lstAtributos.getToken(0));
                return retorno;
            }

            //recupero la tabla
            token idTabla = lstAtributos.getToken(2);
            usqlTabla tablaFinal = tablaSimbolos.listaBaseDeDatos.usar.getTabla(idTabla);
            if (hayErrores())
                return retorno;




            //filas de la tabla
            tuplaTitulo tuplaTitulo = new tuplaTitulo(tablaSimbolos);
            _LST_ATRIBUTO atribs = (_LST_ATRIBUTO)hijos[0];
            atribs.insertarCeldas(tuplaTitulo);
            
            //concatenando el titulo
            tablaFinal.titulo.concatenarAlterar(tuplaTitulo);


            //ahora debo llenar de null las nuevas columnas pvto
            llenarColumnasExtras(tablaFinal, atribs.hijos.Count);


            //mensaje de exitoso
            tablaSimbolos.tablaMensajesUsql.println("La tabla: " + idTabla.val + " se altero exitosamente");

            return retorno;
        }


        public void llenarColumnasExtras(usqlTabla tablaFinal, int cantidad)
        {
            foreach( tupla item in tablaFinal.filas)
            {

                for(int i=0; i<cantidad; i++)
                {
                    //llenando de valores null
                    itemValor val = new itemValor();
                    val.setValor(-1);
                    item.listaValores.Add(val);
                }

            }
        }

    }
}
