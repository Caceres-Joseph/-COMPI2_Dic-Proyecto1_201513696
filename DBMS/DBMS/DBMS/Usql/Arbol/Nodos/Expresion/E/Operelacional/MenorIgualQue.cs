﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Nodos.Expresion.E_Rel;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E.Operelacional
{
    class MenorIgualQue : _E_MENOR_IGUAL
    {
        public MenorIgualQue(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }


        public itemValor opMenorIgualQue(String ambito, elementoEntorno elem)
        {
            IgualQue igualQue = new IgualQue(hijo1, hijo2, tabla, signo);

            itemValor retorno = igualQue.opIgualacion(ambito, elem);

            if (retorno.isTypeBooleano())
            {
                if (retorno.getBooleano())
                {
                    retorno.setValue(true);
                    return retorno;
                }
                else
                {

                    MenorQue menorQue = new MenorQue(hijo1, hijo2, tabla, signo);
                    itemValor temp1 = menorQue.opMenorQue(ambito, elem);
                    if (temp1.isTypeBooleano())
                    {
                        if (temp1.getBooleano())
                        {
                            retorno.setValue(true);
                            return retorno;
                        }
                        else
                        {
                            retorno.setValue(false);
                            return retorno;
                        }
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("No se recibió un booleano en" + ambito, signo);
                        return retorno;
                    }
                }
            }
            else
            {
                tabla.tablaErrores.insertErrorSemantic("No se recibió un booleano en" + ambito, signo);
                return retorno;
            }

        }

    }
}
