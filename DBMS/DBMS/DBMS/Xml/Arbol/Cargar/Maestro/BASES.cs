using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Xml.Arbol.Elementos;
using DBMS.Xml.Arbol.Nodos;

namespace DBMS.Xml.Arbol.Cargar.Maestro
{
    class BASES : cargarModelo
    {
        public BASES(xmlProcesado raiz, tablaSimbolos tabla) : base(raiz, tabla)
        {
        }

        public override void cargar()
        {

            foreach(xmlProcesado temp in raiz.hijos)
            {


                DB nodoDb = new DB(temp, tabla);
                nodoDb.cargar();

                //println("Nombre nodo  " + temp.hijos[0].lstAtributos.getToken(1).valLower);
            }
        }

    }
}
