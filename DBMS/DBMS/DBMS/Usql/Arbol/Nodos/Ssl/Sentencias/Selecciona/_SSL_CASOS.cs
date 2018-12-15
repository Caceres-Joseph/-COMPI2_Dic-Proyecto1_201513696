using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Selecciona
{
    class _SSL_CASOS : nodoModelo
    {
        /*
         * MakePlusRule(SSL_CASOS, SSL_CASO);
         */
        public _SSL_CASOS(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

        public itemRetorno ejecutar(elementoEntorno elementoEntor, itemValor expresion)
        /*
        |---------------------------- 
        | EJECUTAR 
        |----------------------------
        | 0 = normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */
        {
            itemRetorno retorno = new itemRetorno(0);
            if (hayErrores())
                return retorno;



            foreach(_SSL_CASO hijo in hijos)
            {

               retorno = hijo.ejecutar(elementoEntor, expresion);



                if (retorno.isRomper())
                //este codigo sirve para eliminar el romper en los nodos, más arriba, y solo se quede en el case
                {
                    return retorno;
                }
                else if (retorno.isRetorno())
                {
                    return retorno;
                }
                else if (retorno.isContinuar())
                {
                    return new itemRetorno(0);
                    //retorno = new itemRetorno(0);
                }
                else if (hayErrores())
                {
                    return retorno;
                }

            }
            return retorno;

        }
    }
}
