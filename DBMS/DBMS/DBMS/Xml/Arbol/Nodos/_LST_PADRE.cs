using DBMS.PlyCs.Arbol.Elementos;
using DBMS.Xml.Arbol.Elementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Xml.Arbol.Nodos
{
    class _LST_PADRE : nodoModeloXml
    {
        /*
         * LST_PADRE.Rule = MakePlusRule(LST_PADRE, LST_HIJO);
         */
        public _LST_PADRE(string nombre) : base(nombre)
        {
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public override xmlProcesado ejecutarXML()
        {

            //este es el primer ejecutar

            xmlProcesado padre = new xmlProcesado("raiz");


            foreach(_LST_HIJO temp in hijos)
            {
                //reocorro los hijos y les envio el padre
                padre.hijos.Add(temp.getParte());
            }

            return padre;


        }

        public void cargarHijos(xmlProcesado padre)
        {
            foreach (_LST_HIJO temp in hijos)
            {
                //reocorro los hijos y les envio el padre
                padre.hijos.Add(temp.getParte());
            }
        }
    }
}
