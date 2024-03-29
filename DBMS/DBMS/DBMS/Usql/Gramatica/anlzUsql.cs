﻿using DBMS.Ast;
using DBMS.Usql.Arbol;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.DB;
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
         

        public anlzUsql(tablaSimbolos tabla)
        {



            this.tablaDeSimbolos = tabla; 
            raizArbol = new nodoModelo("raiz", tablaDeSimbolos);
        }

        public String iniciarAnalisis(String cadena)
        {


            gramUsql gramatica = new gramUsql(tablaDeSimbolos.tablaErrores,"usql");
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;


            Console.WriteLine("====================== INICIANDO ANALISIS USQL ====================");
            if (raiz == null)
            {
                Console.WriteLine("======= Arbol Vacio =======");
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


                //cargando las globales de los atributos
                //raizArbol.tablaSimbolos.iniciarEjecucion();



                //esta es la ejecución final
                elementoEntorno global = new elementoEntorno(null, tablaDeSimbolos, "global");
                raizArbol.ejecutar(global);




                //imprimir();

                return "";

            }

            //return false;
        }



        public void dibujarGrafo(String cadena)
        {


            gramUsql gramatica = new gramUsql(tablaDeSimbolos.tablaErrores, "usql");
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;
             
            if (raiz != null)
            {

                grafo.generarImagen(raiz);
            } 
             
        }


        public void imprimir(elementoEntorno global)
        {

            Console.WriteLine("-------------- global ------------------");
            global.imprimir();
            Console.WriteLine("--------------[ Objetos ]---------------------");
            tablaDeSimbolos.imprimirClases(); 
            Console.WriteLine("--------------[ Funciones metodos ]-----------");
            tablaDeSimbolos.lstMetodo_funcion.imprimir(); 
            Console.WriteLine("--------------[ Aalisis USQL Exitoso ]--------");
        }



    }
}
