using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.Tuplas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Tuplas
{
    class tuplaTitulo : tuplaTituloPadre
    {
        /*
         * Constructor
         */
        public tuplaTitulo(tablaSimbolos tabla) : base(tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | XML
        |-------------------------------------------------------------------------------------------------------------------
        |
            public tablaSimbolos tabla;
            public Dictionary<String, celdaTitulo> filaTitulo = new Dictionary<String, celdaTitulo>();
            int numColumna = 0;
        */
        public String getXml()
        {

            String contenidoXML = "";
            String tab1 = "\n\t\t";
            String tab2 = "\n\t\t\t";


             
            
            foreach (KeyValuePair<string, celdaTitulo> keyVal in filaTitulo)
            {
                contenidoXML += tab1 + "<CELDA>";
                contenidoXML += tab2 + "<nombre>" + keyVal.Key + "</nombre>";
                contenidoXML += keyVal.Value.getXml(); 
                contenidoXML += tab1 + "</CELDA>";
            }


            return contenidoXML;
        }
    }

}
