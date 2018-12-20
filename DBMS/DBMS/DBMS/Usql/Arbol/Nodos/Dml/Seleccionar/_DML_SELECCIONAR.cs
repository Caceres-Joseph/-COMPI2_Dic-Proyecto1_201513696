using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;

namespace DBMS.Usql.Arbol.Nodos.Dml.Seleccionar
{
    class _DML_SELECCIONAR : nodoModelo
    {
        /*
         * 
            //  ''' SELECCIONAR '''
            DML_SELECCIONAR.Rule = DML_SELECCIONAR_P
                                    | DML_SELECCIONAR_P + DML_ORDENAR
                                    ;
         */
        public _DML_SELECCIONAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se ha seleccionado una base de datos para realizar la operacion de insertar nueva tabla", lstAtributos.getToken(0));
                return retorno;
            }




            nodoOrdenar ord = new nodoOrdenar();

            if (hijos.Count == 2)
            {
                _DML_ORDENAR nodoOrdenar = (_DML_ORDENAR)hijos[1];
                ord = nodoOrdenar.getIndicePorOrdenar(tablaEntornos);
            }
             
            _DML_SELECCIONAR_P nodoSelect = (_DML_SELECCIONAR_P)hijos[0];
            usqlTablaCartesiana tablaSelect = nodoSelect.getTablaCartesiana(tablaEntornos, ord);

            if (tablaSelect == null)
                return retorno;



            //imprimiendo la tabla
            tablaSelect.imprimir();
            return retorno;
        }








        /*
        |-------------------------------------------------------------------------------------------------------------------
        | FUNCIONES QUE SELECCIONA  LA COLUMNA
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public tupla seleccionar(tupla val, Dictionary<string, celdaTitulo> columnas)
        {

            tupla tuplaRetorno = new tupla();
            //seleccionando los indices 

            foreach (KeyValuePair<string, celdaTitulo> item in columnas)
            {
                if (item.Value.posEnColumna > val.listaValores.Count)
                {
                    Console.WriteLine("[_DML_SELECCIONAR_P3]Supera el limite del seleccionar");
                }
                else
                {
                    tuplaRetorno.listaValores.Add(val.listaValores[item.Value.posEnColumna]);
                }
            }

            return tuplaRetorno;
        }


        public usqlTablaCartesiana getTablaFinal(IList<tupla> concatList, usqlTablaCartesiana tempTabla, Dictionary<string, celdaTitulo> columnas)
        {

            tempTabla.titulo.filaTitulo = columnas;
            tempTabla.filas = concatList;
            tempTabla.numIndices = concatList.Count;
            return tempTabla;
        }
    }
}
