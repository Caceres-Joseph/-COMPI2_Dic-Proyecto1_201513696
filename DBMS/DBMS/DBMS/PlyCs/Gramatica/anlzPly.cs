using DBMS.Ast;
using DBMS.TablaErrores;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using DBMS.PlyCs.Arbol;
using DBMS.PlyCs.Arbol.Nodos;
using DBMS.PlyCs.Arbol.Elementos;

namespace DBMS.PlyCs.Gramatica
{
    class anlzPly
    {

        public tablaErrores tabla = new tablaErrores();
        public nodoModelo raizArbol=new nodoModelo("raiz");

        public String iniciarAnalisis(String cadena)
        { 


            gramPlycs gramatica = new gramPlycs(tabla, "plycs");
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
                arbolPlycs generar = new arbolPlycs(gramatica.nombreArchivo); 
                raizArbol = generar.generar(raizArbol, raiz);
                itemRetorno ret= raizArbol.ejecutar();



                if (ret.isRetorno())
                {
                    Console.WriteLine("retornando : " + ret.cadenaRetorno);
                }
                return ret.cadenaRetorno;

            }
             
            //return false;
        }
    }
}
