using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;

namespace DBMS.Usql.Arbol.Nodos.Expresion.Id
{
    class _ID_VAR_FUNC : nodoModelo
    {
        /*                  | ID_VAR_FUNC_1
                            | ID_VAR_FUNC_2
                            | ID_VAR_FUNC_3
                            | ID_VAR_FUNC_4
                            | ID_VAR_FUNC_5
         
             */
        public _ID_VAR_FUNC(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Devolviendo destino
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public virtual itemEntorno getDestino(elementoEntorno elementoEntorno)
        {
            itemEntorno retorno = null;
            
            foreach(_ID_VAR_FUNC nodoHijo in hijos)
            {
                return nodoHijo.getDestino(elementoEntorno);
            }

            return retorno;

        }

         
        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Recuperando valor
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
         

        public virtual itemValor getValor(elementoEntorno elementoEntor)
        {

            itemValor retorno = new itemValor();

            foreach (_ID_VAR_FUNC nodoHijo in hijos)
            {
                return nodoHijo.getValor(elementoEntor);
            }
            return retorno;
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Funciones
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public itemEntorno getEntornoId(token idVal, elementoEntorno elem, List<int> lstDimensiones)
        // aquí hay que buscar dentro de la tabla de simbolos y devoler el valor, e ir buscando
        // hacia atraás para encontral el id
        {

            itemValor retorno = new itemValor();
            retorno.setTypeNulo();


            itemEntorno et = elem.getItemValor(idVal.valLower);
            if (et != null)
            {
                et.lstDimensionesAcceso = lstDimensiones;
                return et;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("La variable : " + idVal.val + "no se encuentra en el ambito correcto para su acceso, no se ha declarado  o no tiene permisos para acceder a ella", idVal);
            }

            return null;
        }


        public itemValor getValId(token idVal, elementoEntorno elem)
        // aquí hay que buscar dentro de la tabla de simbolos y devoler el valor, e ir buscando
        // hacia atraás para encontral el id
        {

            itemValor retorno = new itemValor();
            retorno.setTypeNulo();


            itemEntorno et = elem.getItemValor(idVal.valLower);
            if (et != null)
            {
               
                return et.valor;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("La variable : " + idVal.val + "no se encuentra en el ambito correcto para su acceso, no se ha declarado  o no tiene permisos para acceder a ella", idVal);
            }

            return retorno;
        }
    }
}
