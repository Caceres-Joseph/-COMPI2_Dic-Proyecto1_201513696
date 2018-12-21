using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Globales
{
    class escribirArchivo
    {
        String cadena = "";
        String nombre = "";

        public escribirArchivo(String cadena, String nombre)
        {
            this.cadena = cadena;
            this.nombre = nombre;
        }


        public void escribir()
        {
             
            string cad = cadena;
            StreamWriter w = new StreamWriter(nombre + ".xml");
            w.WriteLine(cad);
            w.Close(); 
        }
          
    }
}
