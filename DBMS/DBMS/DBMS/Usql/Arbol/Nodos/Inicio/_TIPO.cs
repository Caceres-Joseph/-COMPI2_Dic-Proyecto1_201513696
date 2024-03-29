﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Inicio
{
    class _TIPO : nodoModelo
    {
        public _TIPO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

        public token getTipo()
        {
            token retorno = new token("vacio");

            if (lstAtributos.listaAtributos.Count > 0)
            {
                retorno = lstAtributos.getToken(0);
            }
            else
            {
                println("getTipo no tiene hijos");
            }


            return retorno;

        }
    }
}
