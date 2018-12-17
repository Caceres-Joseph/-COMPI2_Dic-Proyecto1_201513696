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
        public int numIndices = 0;
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



            for(int index=0; index < titulo.filaTitulo.Count; index++)
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
                        tablaSimbolos.tablaErrores.insertErrorSemantic("No puede dejar vacio un valor para la columna "+ tempCel.nombre.val+ " con el complemento NO NULO", nombreTabla);
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

    }
}
