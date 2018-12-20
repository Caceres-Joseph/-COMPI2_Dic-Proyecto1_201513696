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
    class _E_AND : opModelo
    {
        public _E_AND(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }

        public itemValor andUsql(String ambito, elementoEntorno elem, token tokLinea)
        {
            itemValor retorno = new itemValor();
            itemValor val1 = hijo1.operarTabla(elem);
            itemValor val2 = hijo2.operarTabla(elem);
            retorno.setValor(false);
            if (val1.tablaCartesiana == null)
            {
                tabla.tablaErrores.insertErrorSemantic("La tabla del lado izquiero del and es  nula  [ null && tabla2]", tokLinea);
                return retorno;
            }
            if (val2.tablaCartesiana == null)
            {
                tabla.tablaErrores.insertErrorSemantic("La tabla del lado derecho del and es  nula  [ tabla1 && nulo]", tokLinea);
                return retorno;
            }

            usqlTablaCartesiana tempTabla = new usqlTablaCartesiana(val1.tablaCartesiana, 0);

            usqlTablaCartesiana tabla1 = val1.tablaCartesiana;
            usqlTablaCartesiana tabla2 = val2.tablaCartesiana;


             
            var salidaConsulta = tabla1.filas.Intersect(tabla2.filas, new CompararTupla());
            IList<tupla> concatList = new List<tupla>();
            foreach (var item in salidaConsulta)
            {
                List<itemValor> vale1 = item.listaValores;

                //creando una nueva tupla
                tupla nuevaTupla = new tupla();
                nuevaTupla.listaValores.AddRange(vale1);
                concatList.Add(nuevaTupla);
            }

            tempTabla.filas = concatList;
            tempTabla.numIndices = concatList.Count;
            retorno.setValor(true);
            retorno.tablaCartesiana = tempTabla;
            return retorno; 
        }



        public void println(String mensaje)
        {
            Console.WriteLine("[E_AND]" + mensaje);
        }
    }
     

}
