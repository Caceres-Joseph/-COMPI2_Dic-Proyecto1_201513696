using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Validar;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Asignar
{
    class _SSL_ASIGNAR : nodoModelo
    {
        public _SSL_ASIGNAR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | FUNCIONES
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public void asignarValor(itemEntorno destino, itemValor valor)
        {

            validarTipos validador = new validarTipos(tablaSimbolos);



            if (validador.validandoTipo(destino.nombre, destino.tipo, valor))
            {
                //aquí le asigno el valor 
                destino.valor = valor;
            }
        }
    }
}
