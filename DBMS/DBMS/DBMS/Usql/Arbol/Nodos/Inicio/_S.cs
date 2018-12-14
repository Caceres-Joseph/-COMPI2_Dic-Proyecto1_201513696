using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;

namespace DBMS.Usql.Arbol.Nodos
{
    class _S : nodoModelo
    {
        public _S(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        public override itemRetorno ejecutar(elementoEntorno tablaEntornos)
        {


            itemRetorno resultado = ejecutarHijos(tablaEntornos);
            return resultado;

        }

        public override itemRetorno ejecutarHijos(elementoEntorno elem)
        {

            itemRetorno retorno = new itemRetorno(0);

            if (hayErrores())
                return retorno;


            foreach (nodoModelo temp in hijos)
            {

                itemRetorno resultado = temp.ejecutar(elem);
                if (resultado.isNormal())
                {
                    //continua normal
                }
                else
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("No puede venir un denter en ámbito global",new token(""));
                    return resultado;
                }

            }

            return retorno;
        }

    }
}
