using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.DB;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Usql.Arbol.Nodos.Listas.Valor;


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

            token idTabla = lstAtributos.getToken(3);

            //recuperando id
            _LST_VAL_ID lstId = (_LST_VAL_ID)hijos[0];
            lstAtributos atribs= lstId.getLstVal();
            

            //recuperando los valores
            _LST_VALOR nodoValor = (_LST_VALOR)hijos[1];
            tupla nuevaTupla = new tupla();
            lstValores valores = nodoValor.getLstValores(tablaEntornos);

            nuevaTupla.listaValores = valores.listaValores;


            //recuperando la tabla
            usqlTabla tablaTemp = tablaSimbolos.listaBaseDeDatos.usar.getTabla(idTabla);

            //insertando
            tablaTemp.insertRow(nuevaTupla, atribs, idTabla);


            if (hayErrores())
                return retorno;


            //mensaje de exitoso
            tablaSimbolos.tablaMensajesUsql.println("Nuevo registro en la tabla:" + idTabla.val);

            return retorno;
        }
    }
}
