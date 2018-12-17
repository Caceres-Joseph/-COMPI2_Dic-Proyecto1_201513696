using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Tuplas
{
    class tuplaTitulo
    {
        public tablaSimbolos tabla;
        public List<celdaTitulo> filaTitulo = new List<celdaTitulo>();
       

        public tuplaTitulo(tablaSimbolos tabla)
        {
            this.tabla = tabla;
        }
         
        public void insertarNuevaColumna(token nombreCol)
        { 
            celdaTitulo nuevaCelda = new celdaTitulo(tabla, nombreCol);
            filaTitulo.Add(nuevaCelda);
        }
         
    }

}
