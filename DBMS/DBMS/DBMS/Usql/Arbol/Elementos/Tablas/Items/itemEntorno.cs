using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;
using DBMS.Usql.Arbol.Elementos.Tablas.Objetos;
using DBMS.Usql.Arbol.Elementos.Tablas.Validar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Items
{
    class itemEntorno
    {
        public token tipo;
        public token nombre;
        public itemValor valor;



        public token visibilidad = new token("publico");
        public List<int> dimension = new List<int>();
        public tablaSimbolos tabla;


        public List<int> lstDimensionesAcceso = new List<int>();

        
        public itemEntorno(tablaSimbolos tabla)
        {
            this.tipo = new token("nulo");
            this.nombre = new token("--");
            this.valor = new itemValor();
            valor.setTypeNulo();
            this.visibilidad = new token("privado"); 
            this.tabla = tabla;
        }

        public itemEntorno(token nombre, token tipo, itemValor valor, token visibilidad, List<int> dimension, tablaSimbolos tabla)
        {

            this.tabla = tabla;
            this.nombre = nombre;
            this.tipo = tipo;
            this.valor = new itemValor();

            validarTipos validador = new validarTipos(tabla);
            if (!validador.validandoTipo(nombre, tipo, valor))
            {

                return;
            }


            if (itemValor.getTipoApartirDeString(tipo.valLower).Equals("objeto"))
            {
                this.valor = valor;
                 
            }
            else
            {

                if (valor.getTipo().Equals("nulo"))
                {

                    this.valor = new itemValor();
                    this.valor.setValueDefault(tipo.valLower);
                }
                else
                {
                    this.valor = valor;
                }


                //this.valor = valor;
            }




        }

         

        public static Boolean sePuedeParsear(String tipo1, itemValor valor2)
        {

            Object objetoParseado = valor2.getValorParseado(tipo1);
            if (objetoParseado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





        public void imprimir()
        {
            Console.WriteLine("\tnombre->" + nombre.valLower);
            Console.WriteLine("\t\ttipo->" + tipo.valLower);
            valor.imprimirVariable();
            Console.WriteLine("\t\tvisibilidad->" + visibilidad.valLower);
            Console.WriteLine("\t\tdimension->" + dimension.Count);
            int indice = 0;
            foreach (int ent in dimension)
            {
                Console.WriteLine("\t\t\tdim1: " + indice + "[" + ent + "]");
                indice++;
            }
        }

    }
}
