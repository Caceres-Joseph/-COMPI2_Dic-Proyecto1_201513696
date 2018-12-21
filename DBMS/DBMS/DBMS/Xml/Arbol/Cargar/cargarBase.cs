using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Xml.Arbol.Cargar.Base.Tablas;
using DBMS.Xml.Arbol.Elementos;
using DBMS.Xml.Gramatica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Xml.Arbol.Cargar
{
    class cargarBase
    {

        tablaSimbolos tablaSimbolos;
        public cargarBase(tablaSimbolos tabla)
        {

            this.tablaSimbolos = tabla;
        }


        /*
         * Metodo que se encarga de cargar el xml
         */
        public void cargar(String nombreDb)
        {
             
            try
            {
                string text = System.IO.File.ReadAllText(nombreDb);

                 
                anlzXml analizador = new anlzXml();
                xmlProcesado raiz = analizador.iniciarAnalisis(text);
                if (raiz == null || analizador.tabla.listaErrores.Count != 0)
                    return;

                Tablas nodoTablas = new Tablas(raiz.getIndiceNodo(0), tablaSimbolos);
                nodoTablas.cargar(); 
            }
            catch (Exception)
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("[XML]No se pudo leer el archivo de base de datos",new token(""));
            }
             
        }
    }
}
