using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Xml.Arbol.Elementos
{
    class xmlProcesado
    {
        public String nombre = "";
        public itemValor valor = new itemValor(); 
        public List<xmlProcesado> hijos = new List<xmlProcesado>();

        public xmlProcesado(String nombre)
        {
            this.nombre = nombre;
        }


        public void imprimir()
        {
            Console.WriteLine("----------");
            Console.WriteLine(nombre);
            foreach (xmlProcesado temp in hijos)
            {
                temp.imprimir();
            }

        }


        public xmlProcesado getIndiceNodo(int index)
        {
            if (index < hijos.Count)
            {
                return hijos[index];
            }
            else
            {
                Console.WriteLine("[xmlProcesado]No existe el indice");
                return new xmlProcesado("error");
            }
        }

    }
}
