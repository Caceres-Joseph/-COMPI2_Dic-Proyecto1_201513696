using DBMS.Usql.Arbol.Elementos.Tablas.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Listas
{
    class lstObjetos
    {

        tablaSimbolos tabla;

        List<objetoClase> listaObjetos = new List<objetoClase>();


        public lstObjetos(tablaSimbolos tabla)
        {
            this.tabla = tabla; 
        }

        public void insertar(objetoClase nuevoObjeto)
        {

            this.listaObjetos.Add(nuevoObjeto);

        }


        public objetoClase getObjeto(String nombreObjeto)
        {

            foreach(objetoClase objeto in listaObjetos)
            {
                if (objeto.cuerpoClase.nombreClase.valLower.Equals(nombreObjeto.ToLower()))
                {
                    return objeto;
                }
            }


            return null;
        }



    }
}
