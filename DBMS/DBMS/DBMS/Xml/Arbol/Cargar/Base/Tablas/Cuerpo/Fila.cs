using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Xml.Arbol.Elementos;

namespace DBMS.Xml.Arbol.Cargar.Base.Tablas.Cuerpo
{
    class Fila : cargarModelo
    {
        public Fila(xmlProcesado raiz, tablaSimbolos tabla) : base(raiz, tabla)
        {
        }

        public void cargarCeldas(List<tupla> retorno)
        {

            tupla nuevaTupla = new tupla();
            foreach (xmlProcesado temp in raiz.hijos)
            {
                itemValor dato = temp.valor;
                nuevaTupla.insertar(dato);
            }
            retorno.Add(nuevaTupla);
        }
    }
}
