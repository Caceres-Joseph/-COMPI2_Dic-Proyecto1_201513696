﻿using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.Tuplas
{
    class tuplaTituloPadre
    {
        public tablaSimbolos tabla;
        public Dictionary<String, celdaTitulo> filaTitulo = new Dictionary<String, celdaTitulo>();
        public int numColumna = 0;

        public tuplaTituloPadre(tablaSimbolos tabla)
        {
            this.tabla = tabla;
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | PARA LA TABLA CARTESIANA
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public void concatenar(tuplaTitulo filaTitulo2, int indiceTabla)
        {

            foreach (KeyValuePair<string, celdaTitulo> entry in filaTitulo2.filaTitulo)
            {
                // do something with entry.Value or entry.Key
                insertar(entry.Value, indiceTabla);
            }
        }

        /*
        |-------------------------------------------------------------------------------------------------------------------
        | CONSULTA USQL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public void insertarNuevaColumna(token nombreCol)
        {

            if (filaTitulo.ContainsKey(nombreCol.valLower))
            {
                tabla.tablaErrores.insertErrorSemantic("La columna:" + nombreCol.val + " ya existe, cambie el nombre", nombreCol);
                return;
            }


            celdaTitulo nuevaCelda = new celdaTitulo(tabla, nombreCol);
            nuevaCelda.posEnColumna = numColumna++;

            filaTitulo.Add(nombreCol.valLower, nuevaCelda);

        }


        public void insertar(celdaTitulo nuevaCelda)
        {

            if (filaTitulo.ContainsKey(nuevaCelda.nombre.valLower))
            {
                tabla.tablaErrores.insertErrorSemantic("La columna:" + nuevaCelda.nombre.val + " ya existe, cambie el nombre", nuevaCelda.nombre);
                return;
            }

            nuevaCelda.posEnColumna = numColumna++;


            String clave = nuevaCelda.nombre.valLower;

            if (filaTitulo.ContainsKey(clave))
            {
                println("ERROR ya hay un registro con el mismo valor ___");
            }
            else
            {
                filaTitulo.Add(nuevaCelda.nombre.valLower, nuevaCelda);
            }
        }


        public void insertar(celdaTitulo nuevaCelda, int indice)
        {

            if (filaTitulo.ContainsKey(nuevaCelda.nombre.valLower))
            {
                tabla.tablaErrores.insertErrorSemantic("La columna:" + nuevaCelda.nombre.val + " ya existe, cambie el nombre", nuevaCelda.nombre);
                return;
            }

            nuevaCelda.posEnColumna = numColumna++;
            String clave = indice.ToString() + "||" + nuevaCelda.nombre.valLower;

            if (filaTitulo.ContainsKey(clave))
            {
                println("ERROR ya hay un registro con el mismo valor");
            }
            else
            {

                filaTitulo.Add(indice.ToString() + "||" + nuevaCelda.nombre.valLower, nuevaCelda);
            }
        }


        public celdaTitulo getCeldaIndex(int indice)
        {


            foreach (KeyValuePair<string, celdaTitulo> entry in filaTitulo)
            {
                // do something with entry.Value or entry.Key

                if (entry.Value.posEnColumna == indice)
                {
                    return entry.Value;
                }
            }

            return null;
        }


        public void println(String mensaje)
        {
            Console.WriteLine("[tuplaTitulo]" + mensaje);
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | PARA EL ALTERAR TABLA
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public void concatenarAlterar(tuplaTitulo filaTitulo2)
        {

            foreach (KeyValuePair<string, celdaTitulo> entry in filaTitulo2.filaTitulo)
            {
                // do something with entry.Value or entry.Key
                insertarAlterar(entry.Value);
            }
        }
         
        public void insertarAlterar(celdaTitulo nuevaCelda)
        {

            if (filaTitulo.ContainsKey(nuevaCelda.nombre.valLower))
            {
                tabla.tablaErrores.insertErrorSemantic("La columna:" + nuevaCelda.nombre.val + " ya existe, cambie el nombre", nuevaCelda.nombre);
                return;
            }

            nuevaCelda.posEnColumna = numColumna++;
            filaTitulo.Add(nuevaCelda.nombre.valLower, nuevaCelda);

        }



    }
}
