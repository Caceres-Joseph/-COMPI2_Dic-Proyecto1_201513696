﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using DBMS.Usql.Arbol.Nodos.Expresion.E.OpeAritmetica;
using DBMS.Usql.Arbol.Nodos.Expresion.E.OpeLogico;
using DBMS.Usql.Arbol.Nodos.Expresion.E.Operelacional;
using DBMS.Usql.Arbol.Nodos.Expresion.Id;
using DBMS.Usql.Arbol.Nodos.Ssl.Nativas;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E
{
    class _E : _E_PADRE
    {
        /*
         * tablaActual
         */
        public usqlTablaCartesiana tablaCartesiana;

        public _E(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

        /*
        |-------------------------------------------------------------------------------------------------------------------
        | SELECT
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public itemValor operarTabla(elementoEntorno elmen)
        {
            itemValor ob = new itemValor();
            ob.setTypeNulo();

            if (hayErrores())
                return ob;

            switch (hijos.Count)
            {
                case 0:
                    if (lstAtributos.listaAtributos.Count > 0)
                    {

                        return parseandoDato(lstAtributos.listaAtributos[0]);

                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSyntax("[E] Se esperaba un valor ", new token());
                        return ob;
                        //hay un error
                    }

                case 1:

                    if (hijos[0].nombre.Equals("SSL_OPE_TIPO"))
                    {
                        _SSL_OPE_TIPO opeTipo = (_SSL_OPE_TIPO)hijos[0];
                        return opeTipo.getValor(elmen);
                    }
                    else if (hijos[0].nombre.Equals("SSL_OPE_TIPO"))
                    {

                        return hijos[0].ope_tipo(elmen);
                    }
                    else if (hijos[0].nombre.Equals("SI_SIMPLIFICADO"))
                    {
                        //_SI_SIMPLIFICADO simplif = (_SI_SIMPLIFICADO)hijos[0];
                        //return simplif.getValor(elmen);
                        return ob;
                    }
                    else if (hijos[0].nombre.Equals("LEN"))
                    {
                        /*_LEN len = (_LEN)hijos[0];
                        return len.getValor(elmen);*/

                        return ob;
                    }
                    //operador unario
                    else if (lstAtributos.listaAtributos.Count > 0)
                    {
                        String signo = lstAtributos.getValItem(0);
                        switch (signo)
                        {
                            //Logico
                            case "-":
                                negativo opNeg = new negativo(hijos[0], tablaSimbolos, lstAtributos.getToken(0));
                                return opNeg.opNot(" Asignando valor Negativo", elmen);

                            case "!":
                                Not opeNot = new Not(hijos[0], tablaSimbolos, lstAtributos.getToken(0));
                                return opeNot.notUsql("Not", elmen, lstAtributos.getToken(0));
                            case "(":
                                _E ope = (_E)hijos[0];
                                itemValor te = ope.getValor(elmen);
                                return te;
                            default:
                                tablaSimbolos.tablaErrores.insertErrorSyntax("[E]No se reconoció el signo", lstAtributos.getToken(0));
                                return ob;
                        }
                    }
                    else
                    //ID_VAR_FUNC
                    {
                        nodoModelo busq = getNodo("ID_VAR_FUNC");
                        if (busq != null)
                        {

                            _ID_VAR_FUNC idFunc = (_ID_VAR_FUNC)busq;
                            return idFunc.getValor(elmen);

                        }

                        tablaSimbolos.tablaErrores.insertErrorSyntax("[E]Se esperaba un signo para operación unaria", new token());
                        return ob;
                    }

                case 2:
                    //operador binario
                    if (lstAtributos.listaAtributos.Count > 0)
                    {
                        String signo = lstAtributos.getValItem(0);
                        switch (signo)
                        {
                            //Aritmetica
                            case "+":
                                suma ope = new suma(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return ope.opSuma(elmen);
                            case "-":
                                resta opeRes = new resta(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeRes.opResta(elmen);
                            case "*":
                                multiplicacion opeMul = new multiplicacion(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeMul.opMultiplicacion(elmen);
                            case "/":
                                division opeDiv = new division(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeDiv.opDivision(elmen);
                            case "^":
                                potencia opePot = new potencia(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opePot.opPotencia(elmen);


                            //Relacional
                            case "==":
                                IgualQue opeIgualacion = new IgualQue(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeIgualacion.igualacionUsql("Igualación", elmen, lstAtributos.getToken(0));
                            case "!=":
                                DiferenteQue opeDiferenciacion = new DiferenteQue(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeDiferenciacion.diferenciacionUsql("Diferenciación", elmen, lstAtributos.getToken(0));
                            case ">":
                                MayorQue opeMayor = new MayorQue(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeMayor.mayorQueUsql("Mayor Que", elmen, lstAtributos.getToken(0));
                            case ">=":
                                MayorIgualQue opeMayorIgual = new MayorIgualQue(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeMayorIgual.mayorIgualQueUsql("Mayor o Igual Que", elmen, lstAtributos.getToken(0));
                            case "<":
                                MenorQue opeMenor = new MenorQue(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeMenor.menorQueUsql("Menor Que", elmen, lstAtributos.getToken(0));
                            case "<=":
                                MenorIgualQue opeMenorIgual = new MenorIgualQue(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeMenorIgual.menorIgualQueUsql("Menor o Igual Que", elmen, lstAtributos.getToken(0));

                            //logicas 
                            case "&&":
                                And opeAnd = new And(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeAnd.andUsql("And", elmen, lstAtributos.getToken(0));
                            case "||":
                                Or opeOr = new Or(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeOr.orUsql("Or", elmen, lstAtributos.getToken(0));

                            default:
                                tablaSimbolos.tablaErrores.insertErrorSyntax("[E]No se reconoció el signo", lstAtributos.getToken(0));
                                return ob;
                        }
                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSyntax("[E]Se esperaba un signo para operación binaria", new token());
                        return ob;
                    }
                default:
                    return ob;
            }
        }

    }
}
