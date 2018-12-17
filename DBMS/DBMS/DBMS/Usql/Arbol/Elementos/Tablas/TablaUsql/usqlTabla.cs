using DBMS.Globales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Tuplas
{
    class usqlTabla
    {
        public token nombre;
        public int numIndices = 0;
        public IList<tupla> filas;
        public tuplaTitulo titulo;
        public tablaSimbolos tablaSimbolos;





        public usqlTabla(token nombre, tuplaTitulo titulo, tablaSimbolos tablaSimbolos)
        {

            this.tablaSimbolos = tablaSimbolos;
            this.titulo = titulo;
            this.nombre = nombre;
            this.filas = new List<tupla>();
        }


    }
}
