using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Xml.Arbol.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Xml.Arbol.Cargar.Base.Tablas.Titulo;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Xml.Arbol.Cargar.Base.Tablas.Cuerpo;

namespace DBMS.Xml.Arbol.Cargar.Base.Tablas
{
    class TablaDb : cargarModelo
    {
        public TablaDb(xmlProcesado raiz, tablaSimbolos tabla) : base(raiz, tabla)
        {
        }


        public override void cargar()
        {


            xmlProcesado nombre = raiz.getIndiceNodo(0);
            xmlProcesado indices = raiz.getIndiceNodo(1);


            //nombre de la tabla
            String nombreTabla = nombre.valor.getCadena();
            token idTabla = new token(nombreTabla);



            //titulo de la tabla
            xTitulo nodoTitulo = new xTitulo(raiz.getIndiceNodo(2), tabla);
            tuplaTitulo tuplaTitulo = nodoTitulo.getTuplaTitulo();


            //creando la tabla
            usqlTabla nuevaTabla = new usqlTabla(idTabla, tuplaTitulo, tabla);

            //recuperando las filas de la tabla
            xCuerpo nodCuerpo = new xCuerpo(raiz.getIndiceNodo(3), tabla);
            List<tupla> cuerpoTabla = nodCuerpo.getFilasTabla();
            nuevaTabla.filas = cuerpoTabla;

            tabla.listaBaseDeDatos.usar.insertarTabla(nuevaTabla);
            
            tabla.tablaMensajesUsql.println("[Xml]Tabla cargada exitosamente");

        }

    }
}
