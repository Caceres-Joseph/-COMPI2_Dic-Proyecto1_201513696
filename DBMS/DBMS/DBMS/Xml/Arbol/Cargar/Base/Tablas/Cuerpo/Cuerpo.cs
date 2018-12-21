using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Xml.Arbol.Elementos;

namespace DBMS.Xml.Arbol.Cargar.Base.Tablas.Cuerpo
{
    class xCuerpo : cargarModelo
    {
        public xCuerpo(xmlProcesado raiz, tablaSimbolos tabla) : base(raiz, tabla)
        {
        }


        public List<tupla> getFilasTabla()
        {

            List<tupla> retorno = new List<tupla>();


            foreach (xmlProcesado temp in raiz.hijos)
            {
                Fila nodoCelda = new Fila(temp, tabla);
                nodoCelda.cargarCeldas(retorno);
            }

            return retorno;
        }
    }
}
