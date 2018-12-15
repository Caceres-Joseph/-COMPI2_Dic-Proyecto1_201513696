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
    class _SSL_OPE_TIPO : nodoModelo
    {
        public _SSL_OPE_TIPO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        public virtual itemValor getValor(elementoEntorno elementoEntor)
        {

            itemValor retorno = new itemValor();
            retorno.setTypeNulo();
            if (hayErrores())
                return retorno;
            foreach (_SSL_OPE_TIPO hijo in hijos )
            {
                return hijo.getValor(elementoEntor);
            }

            return retorno;
        }
    }
}
