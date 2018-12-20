using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Tuplas
{
    class usqlTabla
    {
        public token nombre;
        public int numIndices = 1;
        public IList<tupla> filas;
        public tuplaTitulo titulo;
        public tablaSimbolos tablaSimbolos;


        public usqlTabla(token nombre, tuplaTitulo titulo, tablaSimbolos tablaSimbolos)
        {

            this.tablaSimbolos = tablaSimbolos;
            this.titulo = titulo;
            this.nombre = nombre;
            this.filas = new List<tupla>();
        }

        /*Constructor para la tablaCartesiana*/
        public usqlTabla(usqlTabla tablaOrigen)
        {
            if (tablaOrigen == null)
            {
                println("Tabla nula");
                this.tablaSimbolos = new tablaSimbolos();
                this.titulo = new tuplaTitulo(tablaSimbolos);
                this.nombre = new token("");
                this.filas = new List<tupla>();
                return;
            }


            this.tablaSimbolos = tablaOrigen.tablaSimbolos;
            this.titulo = new tuplaTitulo(tablaSimbolos);
            this.nombre = tablaOrigen.nombre;
            this.filas = tablaOrigen.filas;


            tuplaTitulo nuevoTitulo = new tuplaTitulo(tablaSimbolos);
            nuevoTitulo.filaTitulo = tablaOrigen.titulo.filaTitulo;
            this.titulo.concatenar(nuevoTitulo, 0);
            //colocando los valores 
        }


        /*Constructor para una copia  de tablaCartesiana*/
        public usqlTabla(usqlTabla tablaOrigen, int indice)
        {
            this.tablaSimbolos = tablaOrigen.tablaSimbolos;
            this.titulo = tablaOrigen.titulo;
            this.nombre = tablaOrigen.nombre;
            this.filas = tablaOrigen.filas;

        }


        /*
        public usqlTabla(token nombre1, token nombre2, tuplaTitulo titulo1, tuplaTitulo titulo2, tablaSimbolos tablaSimbolos)
        {

            this.tablaSimbolos = tablaSimbolos;

            ///uniendo los titulos
            tuplaTitulo nuevoTitulo1 = new tuplaTitulo(tablaSimbolos);
            nuevoTitulo1.filaTitulo = titulo1.filaTitulo;
            nuevoTitulo1.asignarNombreTabla(0);

            tuplaTitulo nuevoTitulo2 = new tuplaTitulo(tablaSimbolos);
            nuevoTitulo2.filaTitulo = titulo2.filaTitulo;
            nuevoTitulo1.asignarNombreTabla(0);


            tuplaTitulo nuevaTupla = new tuplaTitulo(tablaSimbolos);
            nuevaTupla.concatenar(nuevoTitulo1);
            nuevaTupla.concatenar(nuevoTitulo2);


            this.titulo = nuevaTupla;
            //concateno nombres
            this.nombre = new token(nombre1.val+"||"+nombre2.val);
            //inicializo lista
            this.filas = new List<tupla>();
        }
        */

        public void insertRow(tupla nuevaFila, token nombreTabla)
        {
            //aquí hay que hacer las validaciones de tipos

            if (nuevaFila.listaValores.Count != titulo.filaTitulo.Count)
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("Se estan recibiendo:" + nuevaFila.listaValores.Count + " pero la tabla:" + nombre.val + " tiene " + titulo.filaTitulo.Count + " columnas", nombreTabla);
                return;
            }

            filas.Add(nuevaFila);
            numIndices++;
        }


        public void insertRow(tupla nuevaFila, lstAtributos atribs, token nombreTabla)
        {
            //aquí hay que hacer las validaciones de tipos

            //primero verificando si existe cada una de las columnas, y si es la misma cantidad que se esta recibiendo

            if (nuevaFila.listaValores.Count != atribs.listaAtributos.Count)
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("Se estan recibiendo:" + nuevaFila.listaValores.Count + " pero como columnas indicadas hay: " + atribs.listaAtributos.Count, nombreTabla);
                return;
            }

            //inicializando la tupla
            tupla tuplaFinal = new tupla(titulo.filaTitulo.Count);


            int indice = 0;
            //recorriendo la lista de atribs
            foreach (itemAtributo item in atribs.listaAtributos)
            {
                //corroborando si existe la columna
                token nombreCol = item.tok;

                if (titulo.filaTitulo.ContainsKey(nombreCol.valLower))
                {

                    //hay que insertarlo en la posicion indicada
                    celdaTitulo celda = titulo.filaTitulo[nombreCol.valLower];
                    tuplaFinal.insertar(celda.posEnColumna, nuevaFila.getItemValor(indice++));

                }
                else
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("La columna:" + nombreCol.val + " no existe en la tabla: " + nombre.val, nombreCol);
                    return;
                }
            }



            for (int index = 0; index < titulo.filaTitulo.Count; index++)
            {
                itemValor itemTupl = tuplaFinal.listaValores[index];

                if (itemTupl == null)
                {

                    celdaTitulo tempCel = titulo.getCeldaIndex(index);



                    //verificando si es autoincrementable
                    if (tempCel.esAutoincrementable())
                    {

                        //asignando el valor autoincrementable
                        itemValor val = new itemValor();
                        val.setValor(numIndices);
                        tuplaFinal.listaValores[index] = val;

                    }
                    //no puede ser nulo prro
                    else if (tempCel.esNoNulo())
                    {
                        //mostrando un mensaje de error
                        tablaSimbolos.tablaErrores.insertErrorSemantic("No puede dejar vacio un valor para la columna " + tempCel.nombre.val + " con el complemento NO NULO", nombreTabla);
                    }
                    else
                    //asignando un valor nulo
                    {

                        //asignando el valor nulo
                        itemValor val = new itemValor();
                        tuplaFinal.listaValores[index] = val;
                    }

                }

            }

            //aquí se verifican los autoincrementables y los no nulos prro

            /*indice = 0;
            foreach (itemValor itemTupl in tuplaFinal.listaValores)
            { 
            }*/

            filas.Add(tuplaFinal);
            numIndices++;
        }



        public void imprimir()
        {
            try
            {
                println();
            }
            catch (Exception e)
            {
                Console.WriteLine("[usqlTabla]" + e);
            }
        }
        public void println()
        {

            Console.WriteLine("===   TABLA === ");

            //imprimiendo los titulos

            String[] tituloArr = new String[titulo.filaTitulo.Count];
            int i = 0;
            foreach (KeyValuePair<string, celdaTitulo> entry in titulo.filaTitulo)
            {

                tituloArr[i++] = "[" + entry.Key.Replace("||", "]");
            }



            PrintRow(tituloArr);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            foreach (tupla item in filas)
            {


                String[] columna = new String[item.listaValores.Count];
                int indice = 0;
                foreach (itemValor it in item.listaValores)
                {
                    String cad = it.getCadena();
                    columna[indice++] = cad;

                }
                PrintRow(columna);
            }
        }
        public void println(String mensaje)
        {
            Console.WriteLine("[usqlTAbla]" + mensaje);
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | CONSULTA USQL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        static int tableWidth = 120;

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
