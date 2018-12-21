using DBMS.Xml.Arbol.Elementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Xml.Arbol.Nodos
{
    class _LST_HIJO : nodoModeloXml
    {
        /*
         * LST_HIJO.Rule = ABRE + LST_PADRE + CIERRA
                | ABRE + VALOR + CIERRA
                | ABRE + CIERRA;
         */
        public _LST_HIJO(string nombre) : base(nombre)
        {

        }

        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */


        public xmlProcesado getParte()
        {
            xmlProcesado nuevo = new xmlProcesado(hijos[0].lstAtributos.getToken(1).valLower);


            if (hijos.Count == 3)
            {
                if (hijos[1].nombre.Equals("LST_PADRE"))
                {
                    _LST_PADRE nodoPadre = (_LST_PADRE)hijos[1];
                    nodoPadre.cargarHijos(nuevo);
                }
                else
                {
                    _VALOR nodoVal = (_VALOR)hijos[1];
                    nuevo.valor = nodoVal.getValor();
                }
            }


            return nuevo;

        }
    }
}
