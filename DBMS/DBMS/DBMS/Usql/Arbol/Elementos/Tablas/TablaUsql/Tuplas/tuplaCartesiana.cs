using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.Tuplas
{
    class tuplaCartesiana : ICloneable
    {
        public usqlTablaCartesiana tabla;
        int var = 0;

        public tuplaCartesiana(usqlTablaCartesiana param)
        {
            //          this.fila = param;

            this.tabla = param;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
