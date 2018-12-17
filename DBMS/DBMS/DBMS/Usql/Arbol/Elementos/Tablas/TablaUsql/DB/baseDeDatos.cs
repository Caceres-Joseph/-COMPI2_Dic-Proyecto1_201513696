using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.DB
{
    class baseDeDatos
    {
        public Dictionary<String, usqlTabla> lstTablas = new Dictionary<string, usqlTabla>();
        public tablaSimbolos tablaSimbolos;
        public token nombre;

        public baseDeDatos(token nombre, tablaSimbolos tablaSimbolos)
        {
            this.tablaSimbolos = tablaSimbolos;
            this.nombre = nombre;

        }


        public void insertarTabla(usqlTabla nuevaTabla)
        {
            if (lstTablas.ContainsKey(nuevaTabla.nombre.valLower))
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("Ya se encuentra la tabla con nombre:" + nuevaTabla.nombre.val + " en la base de datos :" + nombre.val, nuevaTabla.nombre);
            }
            else
            {
                lstTablas.Add(nuevaTabla.nombre.valLower, nuevaTabla);
            }
        }


        public usqlTabla getTabla(token nombreTabla)
        {


            if (lstTablas.ContainsKey(nombreTabla.valLower))
            {
                return lstTablas[nombreTabla.valLower];
            }

            tablaSimbolos.tablaErrores.insertErrorSemantic("No se encontró la tabla con nombre:" + nombreTabla.val + " en la base de datos :" + nombre.val, nombreTabla);


            return new usqlTabla(new token("temp"),null,tablaSimbolos);
        }

    }
}
