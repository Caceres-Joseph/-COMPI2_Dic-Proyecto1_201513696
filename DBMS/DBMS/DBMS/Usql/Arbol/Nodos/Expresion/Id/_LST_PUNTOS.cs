using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Objetos;

namespace DBMS.Usql.Arbol.Nodos.Expresion.Id
{
    class _LST_PUNTOS : nodoModelo
    {
        /*
         * sPunto + valId
         */
        public _LST_PUNTOS(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | DESTINO
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public itemEntorno getDestino(elementoEntorno elementoEntorno, itemValor item)
        {

            objetoClase tempObjeto = item.getObjeto();
            if (tempObjeto == null)
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se pudo parsear el objeto", lstAtributos.listaAtributos[1].tok);
                return new itemEntorno(tablaSimbolos);
            }

            String item1 = lstAtributos.listaAtributos[1].nombretoken;
            token nombreVar = lstAtributos.getToken(1);

            return getEntornoId(lstAtributos.listaAtributos[1].tok, tempObjeto.tablaEntorno.raiz, new List<int>());

        }
         
        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Recuperando valor
        |-------------------------------------------------------------------------------------------------------------------
        |
        */


        public itemValor getValor(elementoEntorno elementoEntorno, itemValor item)
        {


            objetoClase tempObjeto = item.getObjeto();
            if (tempObjeto == null)
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se pudo parsear el objeto", lstAtributos.listaAtributos[1].tok);
                return new itemValor();
            }

             
            String item1 = lstAtributos.listaAtributos[1].nombretoken;
            token nombreVar = lstAtributos.getToken(1);

            return getValId(nombreVar, tempObjeto.tablaEntorno.raiz);
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | FUNCIONES
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

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
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se ha declarado la variable : " + idVal.val + " o no tiene permisos para acceder a ella", idVal);
            }

            return retorno;

        }

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

    }
}
