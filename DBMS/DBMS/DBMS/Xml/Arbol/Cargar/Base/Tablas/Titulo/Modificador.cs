using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Xml.Arbol.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
namespace DBMS.Xml.Arbol.Cargar.Base.Tablas.Titulo
{
    class Modificador : cargarModelo
    {
        public Modificador(xmlProcesado raiz, tablaSimbolos tabla) : base(raiz, tabla)
        {
        }

        public void cargarModificadores(celdaTitulo nuevaCelda)
        {

            foreach (xmlProcesado temp in raiz.hijos)
            {

                xmlProcesado modificador = raiz.getIndiceNodo(0);
                int numModificador = modificador.valor.getEntero();
                nuevaCelda.modificadores.Add(numModificador);
            }
        }
    }
}
