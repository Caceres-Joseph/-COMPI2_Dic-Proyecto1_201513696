using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Ast
{
    class grafo
    {
        public static string sl = Convert.ToChar(92).ToString() + "n";
        public static void generarImagen(ParseTreeNode raiz)
        {
            imagen grafico = new imagen();

            String grafoDot = ControlDot.getDot(raiz);
            grafico.escribirDot(grafoDot, "arbolAST");
             
        }
    }
}
