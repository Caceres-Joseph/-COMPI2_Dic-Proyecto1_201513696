using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Tuplas
{
    class tupla : lstValores

    {
        public tupla(int longitud)
        {
            listaValores = new List<itemValor>(new itemValor[longitud]);
        }

        public tupla()
        {

        }


        public void insertar(int indice, itemValor item)
        {
            if (indice<listaValores.Count)
            {
                listaValores[indice] = item;
            }
            else
            {
                println("El indice supera la cantidad");
            }
        }


        public void println(String mensaje)
        {
            Console.WriteLine("[tupla]" + mensaje);
        }
    }
}
