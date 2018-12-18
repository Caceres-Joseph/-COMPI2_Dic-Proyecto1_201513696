using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.Tuplas;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql
{
    class usqlTablaCartesiana : usqlTabla
    {

        /*
         * Lista de tablas concatenadas
         */
       public List<token> listaNombreTablas = new List<token>();

        /*
         * Constructor
         */
        public usqlTablaCartesiana(usqlTabla tablaOrigen) : base(tablaOrigen)
        { 
        }

        /*
        * Constructor para copia
        */
        public usqlTablaCartesiana(usqlTabla tablaOrigen, int indice) : base(tablaOrigen, indice)
        {
        }




        /*
         * Inicializando la tabla cartesiana
         */

        public void inicializar()
        {
            listaNombreTablas.Add(this.nombre); 
           
        }

      


        /*
         * Concatenar tabla
         */

        public void concatenarTabla(usqlTabla tabla2)
        {


            //ahora los titulos
            tuplaTitulo nuevoTitulo = new tuplaTitulo(tablaSimbolos);
            nuevoTitulo.filaTitulo = tabla2.titulo.filaTitulo; 
            this.titulo.concatenar(nuevoTitulo, listaNombreTablas.Count);


            //añadiendo a  la lista de tablas concatenadas
            listaNombreTablas.Add(tabla2.nombre);
        }

        /*
         * Indice nombre de tabla
         */

        public int getIndiceDeTabla(token tok)
        {
            int retorno = 0;
            foreach(token item in listaNombreTablas)
            {
                if (tok.valLower.Equals(item.valLower))
                {
                    return retorno;
                }
                retorno++;
            }
            tablaSimbolos.tablaErrores.insertErrorSemantic("No existe la tabla:" + tok.val, tok);
            return -1;
        }

    }

}

 