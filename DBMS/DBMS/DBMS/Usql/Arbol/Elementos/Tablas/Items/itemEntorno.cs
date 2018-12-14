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

        /*
        public itemEntorno(tablaSimbolos tabla)
        {
            this.tipo = new token("nulo");
            this.nombre = new token("--");
            this.valor = new itemValor();
            valor.setTypeNulo();
            this.visibilidad = new token("privado");
            this.dimension = 0;
            this.tabla = tabla;
        }*/

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

                elementoClase temp = tabla.getClase(tipo);
                if (temp != null)
                {
                    objetoClase nuevoObjeto = new objetoClase(temp, tabla);
                    lstValores lstValores2 = new lstValores();
                    nuevoObjeto.ejecutarGlobales();//cargando sus valores globales 

                    //asignando el objeto
                    this.valor.setValue(nuevoObjeto, tipo.valLower);
                }

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



        /*public Boolean validandoTipo(String tipo1, String tipo2, itemValor valor2)
        {
            //aquí también hay que verificar las dimensiones


            //if (tipo1.Equals(tipo2) || tipo2.Equals("nulo"))
            itemValor tempIt = new itemValor();
            String tipoDato1 = tempIt.getTipoApartirDeString(tipo1);

            if (tipoDato1.Equals("objeto") && valor2.isTypeObjeto())
            //validando que sean los mismos tipos
            {
                if (tipo1.Equals(valor2.nombreObjeto))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (tipoDato1.Equals(tipo2) || tipo2.Equals("nulo"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }*/


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
