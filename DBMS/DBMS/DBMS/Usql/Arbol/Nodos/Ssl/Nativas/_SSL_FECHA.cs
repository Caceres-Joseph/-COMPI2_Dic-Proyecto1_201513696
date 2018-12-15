using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Nativas
{
    class _SSL_FECHA : _SSL_OPE_TIPO
    {
        /*
         * tFecha + sAbreParent + sCierraParent;
        */
        public _SSL_FECHA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public override itemValor getValor(elementoEntorno elementoEntor)
        {

            itemValor retorno = new itemValor();

            DateTime fecha = DateTime.Today;
            retorno.setValorDate(fecha);


            return retorno;
        }

    }
}
