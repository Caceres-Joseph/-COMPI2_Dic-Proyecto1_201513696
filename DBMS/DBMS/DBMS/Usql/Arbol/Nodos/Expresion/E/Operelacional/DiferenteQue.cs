using System;
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
    class DiferenteQue : _E_DIFEREN
    {
        public DiferenteQue(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }

        public itemValor opDiferenciacion(String ambito, elementoEntorno elem)
        {
            IgualQue dif = new IgualQue(hijo1, hijo2, tabla, signo);

            itemValor retorno = dif.opIgualacion(ambito, elem);
            if (retorno.isTypeBooleano())
            {
                if (retorno.getBooleano())
                {
                    retorno.setValue(false);
                    return retorno;
                }
                else
                {
                    retorno.setValue(true);
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
}
