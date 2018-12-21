using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Xml.Arbol.Elementos;
using DBMS.Xml.Arbol.Nodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Xml.Arbol.Cargar
{
    class cargarModelo
    {
        public xmlProcesado raiz;
        public tablaSimbolos tabla;
        public cargarModelo(xmlProcesado raiz, tablaSimbolos tabla)
        {
            this.tabla = tabla;
            this.raiz = raiz;

             
        }


        public virtual void cargar()
        {



        }
        public void println(String mensaje) {
           Console.WriteLine("[" + raiz.nombre + "]"+mensaje);
        }

    }
}
