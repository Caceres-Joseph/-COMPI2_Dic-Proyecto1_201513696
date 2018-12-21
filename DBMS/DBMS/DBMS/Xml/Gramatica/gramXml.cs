using DBMS.TablaErrores;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Xml.Gramatica
{
    class gramXml : Grammar
    {
        tablaErrores tablaErrores;
        public String nombreArchivo;


        public gramXml(tablaErrores tabla, String archivo) : base(caseSensitive: false)//Diferencia entre mayusculas y minusculas
        {
            this.tablaErrores = tabla;
            this.nombreArchivo = archivo;

            #region ER

            /*
             +-----------------------------
             | Fechas
             +----------------------------
             */
            RegexBasedTerminal valTime = new RegexBasedTerminal("valTime", "[0-9][0-9]:[0-9][0-9]:[0-9][0-9]");
            RegexBasedTerminal valDate = new RegexBasedTerminal("valDate", "[0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]");

            /*
             +-----------------------------
             | Valores
             +----------------------------
             */
            RegexBasedTerminal valBoolean = new RegexBasedTerminal("valBoolean", "(false|true|verdadero|falso)");
            StringLiteral valCadena = new StringLiteral("valCadena", "\'");
            StringLiteral valCadena2 = new StringLiteral("valCadena", "\"");

            /*
             +-----------------------------
             | Numeros
             +----------------------------
             */
            NumberLiteral valNumero = new NumberLiteral("valNumero");
            var valDecimal = new RegexBasedTerminal("valDecimal", "[0-9]+\\.[0-9]+");

            /*
             +-----------------------------
             | Identificador
             +----------------------------
             */
            IdentifierTerminal valId = new IdentifierTerminal("valId");

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

            NonTerminal ABRE = new NonTerminal("ABRE");
            NonTerminal CIERRA = new NonTerminal("CIERRA");

            NonTerminal LST_PADRE = new NonTerminal("LST_PADRE");
            NonTerminal LST_HIJO = new NonTerminal("LST_HIJO");

            NonTerminal VALOR = new NonTerminal("VALOR");
            NonTerminal E = new NonTerminal("E");

            #endregion

            #region Gramatica 

            S.Rule = LST_PADRE;


            LST_PADRE.Rule = MakePlusRule(LST_PADRE, LST_HIJO);

            LST_HIJO.Rule = ABRE + LST_PADRE + CIERRA
                | ABRE + VALOR + CIERRA
                | ABRE + CIERRA;

            ABRE.Rule = sMenorQue + valId + sMayorQue;

            CIERRA.Rule = sMenorQue + sDiv + valId + sMayorQue;


            VALOR.Rule = E;


            E.Rule = sMenos + valNumero
                | sMenos + valDecimal
                | valBoolean
                | valCadena
                | valCadena2
                | valDecimal
                | valNumero
                | valDate + valTime
                | valDate
                | valId
                | valId + sPunto + valId
                ;

             
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
