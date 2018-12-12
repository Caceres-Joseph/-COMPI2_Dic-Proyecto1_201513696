using DBMS.TablaErrores;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.PlyCs.Gramatica
{
    class gramPlycs : Grammar
    {
        tablaErrores tablaErrores;
        public String nombreArchivo;


        public gramPlycs(tablaErrores tabla, String archivo) : base(caseSensitive: false)//Diferencia entre mayusculas y minusculas
        {
            this.tablaErrores = tabla;
            this.nombreArchivo = archivo;

            #region ER
            //////////////////////////////////////////
            //------------COMENTARIOS-----------------

            CommentTerminal comentariobloque = new CommentTerminal("comentariobloque", "$#", "#$");
            CommentTerminal comentariolinea = new CommentTerminal("comentariolinea", "$$", "\n", "\r\n");
            /*Se ignoran los terminales solo se reconoce*/
            NonGrammarTerminals.Add(comentariobloque);
            NonGrammarTerminals.Add(comentariolinea);

            //////////////////////////////////////////
            //------------OTROS-----------------
            RegexBasedTerminal valBoolean = new RegexBasedTerminal("valBoolean", "(false|true|verdadero|falso)");

            StringLiteral valCaracter = new StringLiteral("valCaracter", "\'");
            //StringLiteral valCadena = new StringLiteral("valCadena", "\"");
            var valCadena2 = new StringLiteral("valCadena2", "‘(.)*’");


            //RegexBasedTerminal valNumero = new RegexBasedTerminal("numeroValor", "[0-9]+");
            NumberLiteral valNumero = new NumberLiteral("valNumero");
            var valDecimal = new RegexBasedTerminal("valDecimal", "[0-9]+\\.[0-9]+");

            IdentifierTerminal valId = new IdentifierTerminal("valId");


            RegexBasedTerminal valCadena = new RegexBasedTerminal("valCadena", "\"([^\"]+|[\r\n])*\"");

            #endregion

            #region Terminales
            /*
            =============================
             Simbolos
            =============================
             */


            var sMas = ToTerm("+");
            var sMenos = ToTerm("-");
            var sPor = ToTerm("*");
            var sDiv = ToTerm("/");
            var sPot = ToTerm("^");
            var sMod = ToTerm("%");

            var sIgualacion = ToTerm("==");
            var sDiferenciacion = ToTerm("!=");
            var sMenorQue = ToTerm("<");
            var sMayorQue = ToTerm(">");
            var sMenorIgualQue = ToTerm("<=");
            var sMayorIgualQue = ToTerm(">=");
            var sAnd = ToTerm("&&");
            var sOr = ToTerm("||");
            var sNot = ToTerm("!");


            //
            var sAbreParent = ToTerm("(");
            var sCierraParent = ToTerm(")");

            var sAbreLlave = ToTerm("{");
            var sCierraLlave = ToTerm("}");

            var sAbreCorchete = ToTerm("[");
            var sCierraCorchete = ToTerm("]");
            var sPunto = ToTerm(".");
            var sComa = ToTerm(",");
            var sPuntoComa = ToTerm(";");
            var sArroba = ToTerm("@");
            var sIgual = ToTerm("=");

            var sCierraInterrogante = ToTerm("?");
            var sDosPuntos = ToTerm(":");


            #endregion
            #region NoTerminales



            NonTerminal S = new NonTerminal("S");
            NonTerminal PARENT = new NonTerminal("PARENT");

            NonTerminal INSTR = new NonTerminal("INSTR");
            NonTerminal LST_INSTR = new NonTerminal("LST_INSTR"); 
            NonTerminal E = new NonTerminal("E");
            NonTerminal VAL_CADENA = new NonTerminal("VAL_CADENA");


            #endregion

            #region Gramatica 

            S.Rule = PARENT;


            PARENT.Rule = sAbreCorchete + LST_INSTR + sCierraCorchete;

            LST_INSTR.Rule = MakePlusRule(LST_INSTR, sComa, INSTR);

            INSTR.Rule =  VAL_CADENA + sDosPuntos + VAL_CADENA
                        | VAL_CADENA + sDosPuntos + valNumero
                        | VAL_CADENA + sDosPuntos + PARENT ;

            VAL_CADENA.Rule = valCadena;

             

            this.Root = S;
            #endregion
        }

        public override void ReportParseError(ParsingContext context)
        {
            String error = (String)context.CurrentToken.ValueString;
            int fila;
            int columna;

            fila = context.Source.Location.Line;
            columna = context.Source.Location.Column;

            if (error.Contains("Invalid character"))
            {
                string delimStr = ":";
                char[] delimiter = delimStr.ToCharArray();
                string[] division = error.Split(delimiter, 2);
                division = division[1].Split('.');
                error = "Caracter Invalido " + division[0];
                tablaErrores.insertErrorLexical(nombreArchivo, fila, columna, "Caractero no reconocido:" + division[0]);
            }
            else
            {

                fila = context.Source.Location.Line;
                columna = context.Source.Location.Column;
                tablaErrores.insertErrorSyntax(nombreArchivo, fila, columna, "No se esperaba token:" + error);
            }

            base.ReportParseError(context);
        }

    }
}
