﻿using DBMS.PlyCs.Arbol.Elementos;
using DBMS.TablaErrores;
using DBMS.Usql.Arbol.Elementos.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.PlyCs.Arbol.Nodos
{
    class nodoModelo
    {
        public String nombre = "";
        public List<nodoModelo> hijos = new List<nodoModelo>();
        public lstAtributos lstAtributos;
        // public elementoClase clase=new elementoClase(new token("",0,0,"--"), new token("", 0, 0, "--"), new token("", 0, 0, "--"), false);
         

        public nodoModelo(String nombre)
        {

            this.nombre = nombre;
            this.lstAtributos = new lstAtributos();
        }

        public void insertar(nodoModelo hijo)
        {
            hijos.Add(hijo);
        }

        /*
        |--------------------------------------------------------------------------
        | EJECUTAR
        |--------------------------------------------------------------------------
        |
        */
        

     

        public virtual itemRetorno ejecutar(tablaSimbolos tabla)
        {


             return ejecutarHijos(tabla);
             

        }

        public itemRetorno ejecutarHijos(tablaSimbolos tabla)
        {


           itemRetorno retorno = new itemRetorno(0);

            foreach (nodoModelo temp in hijos)
            {

                itemRetorno resultado = temp.ejecutar(tabla);

                if (resultado.isRetorno())
                {
                    return resultado;
                }
                 
            } 
            return retorno; 
        }

           
        /*
        |--------------------------------------------------------------------------
        | Imprimir NOdos
        |--------------------------------------------------------------------------
        |
        */

        public void imprimirNodos()
        {
            foreach (nodoModelo temp in hijos)
            {
                Console.WriteLine("padre:" + nombre + "->hijo:" + temp.nombre);
               
            }
        }




            

        public nodoModelo getNodo(String nombre)
        {

            nodoModelo retorno = null;

            foreach (nodoModelo temp in hijos)
            {
                if (temp.nombre.Equals(nombre))
                {
                    retorno = temp;
                    break;
                }
            }

            return retorno;

        }

        public void imprimirAtributos()
        {
            println(nombre + "{");
            lstAtributos.imprimir();
            println("}");

        }


        public void println(String mensaje)
        {
            Console.WriteLine("[" + nombre + "]" + mensaje);
        }

        public void print(String mensaje)
        {
            Console.Write(mensaje);
        }
    }
}
