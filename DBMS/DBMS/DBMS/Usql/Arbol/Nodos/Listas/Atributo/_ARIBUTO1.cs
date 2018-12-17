using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Nodos.Inicio;

namespace DBMS.Usql.Arbol.Nodos.Listas.Atributo
{
    class _ARIBUTO1:nodoModelo
    {

        /*
         * ATRIBUTO.Rule= TIPO + valId
                    | TIPO + valId + DDL_COMPLEMENTO
                   
         */
        public _ARIBUTO1(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Cargando atributos de objeto
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override void ejecutar(elementoClase simbolo)
        {

            if (hayErrores())
                return;


            // println("llego al contructor");

            token tipo = getTipo();
            token nombre = getIdentificador();
            //nodoModelo LST_CUERPO = getLST_CUERPO();

            token visbilidad = new token("publico");

            int dimension = 0;
            elementoPolimorfo element = new elementoPolimorfo(visbilidad, tablaSimbolos, tipo, nombre, new nodoModelo("---", tablaSimbolos), dimension);

            cargarPolimorfismoHijos(element);
            simbolo.lstVariablesGlobales.insertarElemento(element);
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Metodos
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public token getTipo()
        {

            nodoModelo tempNodo = getNodo("TIPO");
            if (tempNodo != null)
            {
                _TIPO tipo = (_TIPO)tempNodo;
                return tipo.getTipo();
            }
            else
                return new token("nulo");


            //tengo que verificar si existe el tipo de objeto, si no es error prro

        }


        public token getIdentificador()
        {
            token retorno = lstAtributos.getToken(0);
            return retorno;
        }
    }
}
