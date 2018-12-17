﻿using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Tuplas
{

    class celdaTitulo
    {
        public token nombre;
        public int posEnColumna = -1;
        public List<int> modificadores;

        tablaSimbolos tablaSimbolo;
        /*
        |---------------------------- 
        | EJECUTAR 
        |----------------------------
        | 0 = Nada
        | 1 = Nulo;
        | 2 = NoNulo
        | 3 = Autoincrementable
        | 4 = LlavePrimaria
        | 5 = LlaveForanea
        | 6 = Unico
        */

        public celdaTitulo(tablaSimbolos tabla, token nombre)
        {
            this.nombre = nombre;
            this.tablaSimbolo = tabla;
            modificadores = new List<int>();
        }

        public void insertarModificador(token modificador)
        {
            switch (modificador.valLower)
            {
                case "nulo":
                    modificadores.Add(1);
                    break;
                case "no":
                    modificadores.Add(2);
                    break;
                case "autoincrementable":
                    modificadores.Add(3);
                    break;
                case "llave_primaria":
                    modificadores.Add(4);
                    break;
                case "llave_foranea":
                    modificadores.Add(5);
                    break;
                case "unico":
                    modificadores.Add(6);
                    break;
                default:
                    modificadores.Add(7);
                    tablaSimbolo.tablaErrores.insertErrorSemantic("No se reconoce el complemento(modificador) de tipo:" + modificador.val, modificador);
                    break;
            }
        }


        public Boolean esAutoincrementable()
        {

            foreach(int item in modificadores)
            {
                if (item == 3)
                {
                    return true;
                }
            }
            return false;
        }


        public Boolean esNoNulo()
        {
            foreach (int item in modificadores)
            {
                if (item == 2)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
