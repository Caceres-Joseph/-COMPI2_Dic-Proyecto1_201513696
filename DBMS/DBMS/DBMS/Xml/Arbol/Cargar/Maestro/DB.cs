using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.DB;
using DBMS.Xml.Arbol.Elementos;
using DBMS.Xml.Arbol.Nodos;

namespace DBMS.Xml.Arbol.Cargar.Maestro
{
    class DB : cargarModelo
    {
        public DB(xmlProcesado raiz, tablaSimbolos tabla) : base(raiz, tabla)
        {
        }

        public override void cargar()
        {
            println("---- Cargando BASE DE DATOS -----");

            xmlProcesado nombre = raiz.getIndiceNodo(0);
            xmlProcesado path = raiz.getIndiceNodo(1);
            token tokNombre = new token(nombre.valor.getCadena());


            baseDeDatos nuevaBase = new baseDeDatos(tokNombre, tabla);
            tabla.listaBaseDeDatos.insertar(nuevaBase);
            tabla.listaBaseDeDatos.usarBase(tokNombre);
            tabla.tablaMensajesUsql.println("[Xml]Se cargó la base de datos correctamente");
             
            //ahora actualizo el usar



            cargarBase archivoBase = new cargarBase(tabla);
            archivoBase.cargar(path.valor.getCadena());


        }


    }
}
