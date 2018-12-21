using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Xml.Arbol.Cargar.Maestro;
using DBMS.Xml.Arbol.Elementos;
using DBMS.Xml.Arbol.Nodos;
using DBMS.Xml.Gramatica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Xml.Arbol.Cargar
{
    class cargarMaestro
    {

        tablaSimbolos tablaSimbolos;
        public cargarMaestro(tablaSimbolos tabla)
        {

            this.tablaSimbolos = tabla;
        }


        /*
         * Metodo que se encarga de cargar el xml
         */
        public void cargar()
        {


            try
            { 
                string text = System.IO.File.ReadAllText("maestro.xml");
                
                anlzXml analizador = new anlzXml();
                xmlProcesado raiz = analizador.iniciarAnalisis(text);
                if (raiz == null || analizador.tabla.listaErrores.Count != 0)
                    return;

                BASES nodoBases = new BASES(raiz.getIndiceNodo(0), tablaSimbolos);
                nodoBases.cargar();


            }
            catch (Exception e)
            {
                Console.WriteLine("No se puedo leer el texto" + e);
            }

             

        }
    }
}
