using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.Tuplas
{
    class CompararTuplaCompleta : IEqualityComparer<tupla>
    {
        public bool Equals(tupla x, tupla y)
        { 
            if (x.listaValores.Count != y.listaValores.Count)
            {
                return false;
            }

            for (int i = 0; i < x.listaValores.Count; i++)
            {

                if (x.getItemValor(i).valor.Equals(y.getItemValor(i).valor))
                {

                }
                else
                {
                    return false;
                }
            }

            return true;

        }

        public int GetHashCode(tupla obj)
        { 
            return obj.getItemValor(0).GetHashCode();
        }

        public void println(String mensaje)
        {
            // Console.WriteLine("[CompararTupla]" + mensaje);
        }
    }
}
