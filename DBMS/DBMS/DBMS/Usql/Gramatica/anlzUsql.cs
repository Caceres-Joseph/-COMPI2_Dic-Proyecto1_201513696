using DBMS.Ast;
using DBMS.Usql.Arbol;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Nodos;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Gramatica
{
    class anlzUsql
    {
        public tablaSimbolos tablaDeSimbolos;
        public nodoModelo raizArbol;


        public anlzUsql()
        {


            tablaDeSimbolos = new tablaSimbolos(); 
            raizArbol = new nodoModelo("raiz", tablaDeSimbolos);
        }

        public String iniciarAnalisis(String cadena)
        {


            gramUsql gramatica = new gramUsql(tablaDeSimbolos.tablaErrores,"usql");
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;


            if (raiz == null)
            {
                Console.WriteLine("Arbol Vacio");
                return "";
                 
            }
            else
            {

                // seman.S(raiz);
                //grafo.generarImagen(raiz);

                //generando el arbol
                arbolUsql generar = new arbolUsql(gramatica.nombreArchivo);
                raizArbol = generar.generar(raizArbol, raiz, tablaDeSimbolos);
                raizArbol.ejecutar();

                Console.WriteLine("--- Aalisis USQL Exitoso ----");

                return "";

            }

            //return false;
        }
    }
}
