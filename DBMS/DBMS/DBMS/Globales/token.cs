﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Globales
{
    class token
    {
        public String val;
        public int linea;
        public int columna;
        public String archivo;
        public String valLower;

        public token()
        {
            this.val = "--";
            this.linea = 0;
            this.columna = 0;
            this.archivo = "---";
            this.valLower = "---";
        }

        public token(String val)
        {
            this.val = val;
            this.linea = 0;
            this.columna = 0;
            this.archivo = "---";
            this.valLower = val.ToLower();
        }

        public token(String val, int linea, int columna, String archivo)
        {
            this.valLower = val.ToLower();
            this.archivo = archivo;
            this.val = val;
            this.linea = linea;
            this.columna = columna;
        }
         
    }
}
