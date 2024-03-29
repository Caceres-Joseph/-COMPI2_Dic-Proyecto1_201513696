﻿using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Ast
{
    class ControlDot
    {
        private static int contador;
        private static String grafo;

        public static String getDot(ParseTreeNode raiz)
        {
            grafo = "digraph G{\n";
            //grafo += "nodo0[label=\"" + escapar(raiz.ToString()) + "\"];\n";
            //  grafo += "nodo0[label=\"etiqueta\"];\n";

            contador = 1;
            concatenar(raiz);

            grafo += "}";
            return grafo;
        }
        private static void recorrerAST(String padre, ParseTreeNode hijos)
        {
            foreach (ParseTreeNode hijo in hijos.ChildNodes)
            {
                String nombreHijo = "nodo" + contador.ToString();
                grafo += nombreHijo + "[label=\"" + escapar(hijo.ToString()) + "\"];\n";

                grafo += padre + "->" + nombreHijo + "\n";
                contador++;
                recorrerAST(nombreHijo, hijo);


            }
        }

        private static void concatenar(ParseTreeNode nodoIrony)
        {
            if (nodoIrony.ChildNodes.Count == 0)
            {
                if (nodoIrony.Token == null)
                {
                    //no terminal sin hijos
                    /// Console.WriteLine("NoTerminal->" + nodoIrony.ToString());
                    grafo += nodoIrony.GetHashCode() + "[label=\"" + nodoIrony.ToString() + "\"];\n";
                }
                else
                {
                    String terminal = escapar(nodoIrony.Token.Value.ToString());
                    String nombreTerminal = nodoIrony.Term.Name;
                    //Console.WriteLine("terminal->"+terminal);
                    grafo += nodoIrony.GetHashCode() + "[label=\"(" + nombreTerminal + ") " + terminal + "\"];\n";
                }
            }
            else
            {
                // Console.WriteLine("NoTerminal2->" + nodoIrony.ToString());
                grafo += nodoIrony.GetHashCode() + "[label=\"" + nodoIrony + "\"];\n";
            }
            foreach (ParseTreeNode hijo in nodoIrony.ChildNodes)
            {
                grafo += nodoIrony.GetHashCode() + "->" + hijo.GetHashCode() + ";\n";
                concatenar(hijo);
            }





        }




        private static String escapar(String cadena)
        {
            cadena = cadena.Replace("\\", "\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            return cadena;
        }
    }
}
