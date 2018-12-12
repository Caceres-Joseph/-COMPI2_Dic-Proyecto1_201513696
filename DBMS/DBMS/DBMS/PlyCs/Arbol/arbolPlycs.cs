using DBMS.PlyCs.Arbol.Nodos;
using DBMS.TablaErrores;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.PlyCs.Arbol
{
    class arbolPlycs
    {
        public String nombreArchivo;
        public arbolPlycs(String archivo)
        {
            this.nombreArchivo = archivo;
        }


        public nodoModelo generar(nodoModelo raiz, ParseTreeNode AST)
        {
            crearArbol(raiz, AST); 
            return raiz;
        }

        private void crearArbol(nodoModelo padre, ParseTreeNode nodoIrony)
        {

            nodoModelo hijoNodo = null;
            if (nodoIrony.ChildNodes.Count == 0)
            {
                if (nodoIrony.Token == null)
                {


                    hijoNodo = getNodo(nodoIrony.ToString());
                    padre.insertar(hijoNodo);
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

                //grafo += nodoIrony.GetHashCode() + "->" + hijo.GetHashCode() + ";\n";

            }

            return;
        }



        public nodoModelo getNodo(String nombreNoTerminal)
        {
            nodoModelo retorno = null;

            switch (nombreNoTerminal)
            {
                case "S":
                    retorno = new _S(nombreNoTerminal); 
                    break; 
                     
                case "INSTR":
                    retorno = new _INSTR(nombreNoTerminal);
                    break;
                case "LST_INSTR":
                    retorno = new _LST_INSTR(nombreNoTerminal);
                    break;
                case "PARENT":
                    retorno = new _PARENT(nombreNoTerminal);
                    break;
                case "VAL_CADENA":
                    retorno = new _VAL_CADENA(nombreNoTerminal);
                    break;
                default:
                    retorno = new nodoModelo("Desc_" + nombreNoTerminal);
                    Console.WriteLine("[generarArbol]No se encontró el nodo:" + nombreNoTerminal);
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
