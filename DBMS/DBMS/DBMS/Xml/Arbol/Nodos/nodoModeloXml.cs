
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;
using DBMS.Xml.Arbol.Elementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Xml.Arbol.Nodos
{
    class nodoModeloXml
    {
        public String nombre = "";
        public List<nodoModeloXml> hijos = new List<nodoModeloXml>();
        public lstAtributos lstAtributos;
        // public elementoClase clase=new elementoClase(new token("",0,0,"--"), new token("", 0, 0, "--"), new token("", 0, 0, "--"), false);


        public nodoModeloXml(String nombre)
        {

            this.nombre = nombre;
            this.lstAtributos = new lstAtributos(new tablaSimbolos());
        }

        public void insertar(nodoModeloXml hijo)
        {
            hijos.Add(hijo);
        }
         


             
        /*
        |--------------------------------------------------------------------------
        | Imprimir NOdos
        |--------------------------------------------------------------------------
        |
        */
        public virtual xmlProcesado ejecutarXML()
        {


            return ejecutarHijosXML();


        }

        public xmlProcesado ejecutarHijosXML()
        {


            xmlProcesado retorno = new xmlProcesado("ad");

            foreach (nodoModeloXml temp in hijos)
            {

                xmlProcesado resultado = temp.ejecutarXML();
                return resultado;

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
            foreach (nodoModeloXml temp in hijos)
            {
                Console.WriteLine("padre:" + nombre + "->hijo:" + temp.nombre);
                temp.imprimirNodos();
            }
        }






        public nodoModeloXml getNodo(String nombre)
        {

            nodoModeloXml retorno = null;

            foreach (nodoModeloXml temp in hijos)
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
