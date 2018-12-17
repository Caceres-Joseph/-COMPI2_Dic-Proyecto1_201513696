using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas
{
    class tablaMensajesUsql
    {
        List<String> mensajes = new List<String>();

        public void println(String mensaje)
        {
            Console.WriteLine("[tablaMensajesUsql]" + mensaje);
            this.mensajes.Add(mensaje);
        }
    }
}
