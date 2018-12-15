using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas; 
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Validar;
using DBMS.Usql.Arbol.Nodos.Expresion.E;
using DBMS.Usql.Arbol.Nodos.Inicio;
using DBMS.Usql.Arbol.Nodos.Ssl.Asignar;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Para
{
    class _SSL_PARA : nodoModelo
    {
        public _SSL_PARA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
