using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Xml.Arbol.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;

namespace DBMS.Xml.Arbol.Cargar.Base.Tablas.Titulo
{
    class xTitulo : cargarModelo
    {
        public xTitulo(xmlProcesado raiz, tablaSimbolos tabla) : base(raiz, tabla)
        {
        }


        public tuplaTitulo getTuplaTitulo()
        {

            //titulo de la tabla
            tuplaTitulo tuplaTitulo = new tuplaTitulo(tabla);

            foreach (xmlProcesado temp in raiz.hijos)
            {
                Celda nodoCelda = new Celda(temp, tabla);
                nodoCelda.cargarCeldasEnTitulo(tuplaTitulo);
            }



            return tuplaTitulo;
        }
    }
}
