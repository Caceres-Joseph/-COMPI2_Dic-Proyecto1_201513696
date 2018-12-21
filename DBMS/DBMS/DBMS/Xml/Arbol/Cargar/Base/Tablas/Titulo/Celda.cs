using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Xml.Arbol.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Globales;

namespace DBMS.Xml.Arbol.Cargar.Base.Tablas.Titulo
{
    class Celda : cargarModelo
    {
        public Celda(xmlProcesado raiz, tablaSimbolos tabla) : base(raiz, tabla)
        {
        }



        public void cargarCeldasEnTitulo(tuplaTitulo tuplaTitulo)
        {




            xmlProcesado id = raiz.getIndiceNodo(0);
            xmlProcesado posEnColumna = raiz.getIndiceNodo(1);

            token nombreCelda = new token(id.valor.getCadena());

            celdaTitulo nuevaCelda = new celdaTitulo(tabla, nombreCelda);

            nuevaCelda.posEnColumna = posEnColumna.valor.getEntero();

            //cargando los modificadores de la celda
            Modificador mod = new Modificador(raiz.getIndiceNodo(2), tabla);
            mod.cargarModificadores(nuevaCelda);


            //almacenando la nueva celda titulo
            tuplaTitulo.insertar(nuevaCelda);

        }


    }
}
