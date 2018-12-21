using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Tuplas
{
    class usqlTabla : usqlTablaXml
    {
        /*
         * CONSTRUCTORES
         */
        public usqlTabla(usqlTabla tablaOrigen) : base(tablaOrigen)
        {
        }

        public usqlTabla(usqlTabla tablaOrigen, int indice) : base(tablaOrigen, indice)
        {
        }

        public usqlTabla(token nombre, tuplaTitulo titulo, tablaSimbolos tablaSimbolos) : base(nombre, titulo, tablaSimbolos)
        {
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | XML
        |-------------------------------------------------------------------------------------------------------------------
        |
            public token nombre;
            public int numIndices = 1;
            public IList<tupla> filas;
            public tuplaTitulo titulo;
            public tablaSimbolos tablaSimbolos;
        */
        public String getXml()
        {

            String contenidoXML = "";
            String tab1 = "\n\t";
            String tab2 = "\n\t\t";
            String tab3 = "\n\t\t\t";


            contenidoXML += tab1 + "<indices>" + numIndices.ToString() + "</indice>";

            contenidoXML += tab1 + "<TITULO>";
            contenidoXML += titulo.getXml();
            contenidoXML += tab1 + "</TITULO>";
             

            contenidoXML += tab1 + "<CUERPO>";
            foreach (tupla fila in filas)
            {
                contenidoXML += tab2 + "<FILA>";
                foreach (itemValor val in fila.listaValores)
                {
                    if (val.isTypeCadena())
                    {

                        contenidoXML += tab3 + "<celda>\"" + val.getCadena() + "\"</celda>";
                    }
                    else
                    {
                        contenidoXML += tab3 + "<celda>" + val.getCadena() + "</celda>";
                    }
                }
                contenidoXML += tab2 + "</FILA>";
            }
            contenidoXML += tab1 + "</CUERPO>";
            return contenidoXML;
        }

    }
}
