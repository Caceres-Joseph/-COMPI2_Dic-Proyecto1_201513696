using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.Tuplas;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Usql.Arbol.Nodos.Expresion.E;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E_Logico
{
    class _E_NOT : opModelo
    {
        public _E_NOT(nodoModelo hijo1, tablaSimbolos tabla, token signo) : base(hijo1, tabla, signo)
        {
        }

        public itemValor notUsql(String ambito, elementoEntorno elem, token tokLinea)
        {
            itemValor retorno = new itemValor();
            retorno.setValor(false);
            if (elem.tablaFrom == null)
            {
                tabla.tablaErrores.insertErrorSemantic("La tabla  es  nula  [ ! null]", tokLinea);
                return retorno;
            }
            
            usqlTablaCartesiana tempTabla = new usqlTablaCartesiana(elem.tablaFrom, 0); 
            IList<tupla> concatList = new List<tupla>();
          
            tempTabla.filas = concatList;
            tempTabla.numIndices = concatList.Count;
            retorno.setValor(true);
            retorno.tablaCartesiana = tempTabla;
            return retorno;
        }



        public void println(String mensaje)
        {
            Console.WriteLine("[E_NOT]" + mensaje);
        }
    }
}
