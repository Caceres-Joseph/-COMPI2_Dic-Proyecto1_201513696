using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Xml.Arbol.Elementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Xml.Arbol.Cargar.Base.Tablas
{
    class Tablas : cargarModelo
    {
        public Tablas(xmlProcesado raiz, tablaSimbolos tabla) : base(raiz, tabla)
        {
        }

        public override void cargar()
        {

            foreach (xmlProcesado temp in raiz.hijos)
            {

                TablaDb nodoDb = new TablaDb(temp, tabla);
                nodoDb.cargar();
            }
        }
    }
}
