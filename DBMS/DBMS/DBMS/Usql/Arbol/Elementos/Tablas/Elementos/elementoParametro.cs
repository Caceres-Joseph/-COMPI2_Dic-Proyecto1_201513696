using DBMS.Globales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Elementos
{
    class elementoParametro
    {
        public token tipo;
        public int dimensiones;

        public elementoParametro(token tipo, int dimensiones)
        {
            this.tipo = tipo;
            this.dimensiones = dimensiones;
        }
    }
}
