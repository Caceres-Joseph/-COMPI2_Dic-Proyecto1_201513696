using DBMS.Ast;
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
        public String iniciarAnalisis(String cadena)
        {


            gramUsql gramatica = new gramUsql("usql");
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
                grafo.generarImagen(raiz);

                //generando el arbol
                /*arbolPlycs generar = new arbolPlycs(gramatica.nombreArchivo);
                raizArbol = generar.generar(raizArbol, raiz);
                itemRetorno ret = raizArbol.ejecutar();

                if (ret.isRetorno())
                {
                    Console.WriteLine("retornando : " + ret.cadenaRetorno);
                }
                */

                return "";

            }

            //return false;
        }
    }
}
