using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.DB
{
    class lstBaseDeDatos
    {
        public Dictionary<String, baseDeDatos> listaDeBases = new Dictionary<string, baseDeDatos>();

        public baseDeDatos usar;


        tablaSimbolos tabla;

        public lstBaseDeDatos(tablaSimbolos tabla)
        {
            this.tabla = tabla;
        }


        public void insertar(baseDeDatos nuevaBase)
        {

            if (listaDeBases.ContainsKey(nuevaBase.nombre.valLower))
            {
                tabla.tablaErrores.insertErrorSemantic("Ya se encuentra la base de datos con nombre:" + nuevaBase.nombre.val, nuevaBase.nombre);
            }
            else
            {
                listaDeBases.Add(nuevaBase.nombre.valLower, nuevaBase);
            }
        }


        public void usarBase(token nombreBase)
        {
            if (listaDeBases.ContainsKey(nombreBase.valLower))
            {
                this.usar = listaDeBases[nombreBase.valLower];
            }
            else
            {
                tabla.tablaErrores.insertErrorSemantic("No se encuentra la base de datos con nombre:" + nombreBase.val, nombreBase);

            }
        }


    }
}
