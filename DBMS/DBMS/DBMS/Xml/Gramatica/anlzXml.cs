using DBMS.Ast;
using DBMS.PlyCs.Arbol.Elementos;
using DBMS.TablaErrores;
using DBMS.Xml.Arbol;
using DBMS.Xml.Arbol.Elementos;
using DBMS.Xml.Arbol.Nodos;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Xml.Gramatica
{
    class anlzXml
    {

        public tablaErrores tabla = new tablaErrores();
        public nodoModeloXml raizArbol = new nodoModeloXml("raiz");

        public xmlProcesado iniciarAnalisis(String cadena)
        {


            gramXml gramatica = new gramXml(tabla, "xml");
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;


            if (raiz == null)
            {
                Console.WriteLine("Arbol Vacio");
                return null;
            }
            else
            {
                Console.WriteLine("[XML]--- Analizando ---");

                arbolXml generar = new arbolXml(gramatica.nombreArchivo);
                raizArbol = generar.generar(raizArbol, raiz);
                xmlProcesado ret = raizArbol.ejecutarXML();
                //ret.imprimir();

                //raizArbol.imprimirNodos();
                //itemRetorno ret = raizArbol.ejecutar();


                //Console.WriteLine("arbol generado");
                // seman.S(raiz);
                //grafo.generarImagen(raiz);
                return ret;
            }
        }



        public nodoModeloXml graficar(String cadena)
        {


            gramXml gramatica = new gramXml(tabla, "xml");
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;


            if (raiz == null)
            {
                Console.WriteLine("Arbol Vacio");
                return null;
            }
            else
            { 
                grafo.generarImagen(raiz);
                return raizArbol;
            }
        }

    }
}
