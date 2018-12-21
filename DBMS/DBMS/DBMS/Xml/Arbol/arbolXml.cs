using DBMS.Globales;
using DBMS.Xml.Arbol.Nodos;
using DBMS.Xml.Arbol.Nodos.Maestro;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Xml.Arbol
{
    class arbolXml
    {
        public String nombreArchivo;
        public arbolXml(String archivo)
        {
            this.nombreArchivo = archivo;
        }


        public nodoModeloXml generar(nodoModeloXml raiz, ParseTreeNode AST)
        {
            crearArbol(raiz, AST);
            return raiz;
        }

        private void crearArbol(nodoModeloXml padre, ParseTreeNode nodoIrony)
        {

            nodoModeloXml hijoNodo = null;
            if (nodoIrony.ChildNodes.Count == 0)
            {
                if (nodoIrony.Token == null)
                {


                    hijoNodo = getNodo(nodoIrony.ToString());


                    padre.insertar(hijoNodo);

                    //padre.insertar(hijoNodo);
                }
                else
                {
                    String terminal = escapar(nodoIrony.Token.Value.ToString());
                    String nombreTerminal = nodoIrony.Term.Name;
                    token tok = new token(terminal, nodoIrony.Token.Location.Line, nodoIrony.Token.Location.Column, nombreArchivo);

                    padre.lstAtributos.insertar(nombreTerminal, tok);

                }
            }
            else
            {
                hijoNodo = getNodo(nodoIrony.ToString());


                padre.insertar(hijoNodo);


            }


            foreach (ParseTreeNode hijo in nodoIrony.ChildNodes)
            {



                crearArbol(hijoNodo, hijo);




            }

            return;
        }



        public nodoModeloXml getNodo(String nombreNoTerminal)
        {
            nodoModeloXml retorno = null;

            switch (nombreNoTerminal)
            {
                case "S":
                    retorno = new _S(nombreNoTerminal);
                    break;

                case "ABRE":
                    retorno = new _ABRE(nombreNoTerminal);
                    break;

                case "CIERRA":
                    retorno = new _CIERRA(nombreNoTerminal);
                    break;

                case "LST_PADRE":
                    retorno = new _LST_PADRE(nombreNoTerminal);
                    break;

                case "LST_HIJO":
                    retorno = new _LST_HIJO(nombreNoTerminal);
                    break;

                case "VALOR":
                    retorno = new _VALOR(nombreNoTerminal);
                    break;

                case "E":
                    retorno = new _E(nombreNoTerminal);
                    break;
                default:
                    retorno = new nodoModeloXml("Desc_" + nombreNoTerminal);
                    Console.WriteLine("[arbolXML]No se encontró el nodo:" + nombreNoTerminal);
                    break;
            }

            return retorno;
        }


        private static String escapar(String cadena)
        {
            cadena = cadena.Replace("\\", "\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            return cadena;
        }
    }
}
