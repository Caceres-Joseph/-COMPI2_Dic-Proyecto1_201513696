﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Llaves
{
    class llaveParametro
    {

       public  String nombre;
       public  String tipo;
       public int dimension;

        public llaveParametro(String nombre, String tipo, int dimension)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.dimension = dimension;
        }
    }
}
