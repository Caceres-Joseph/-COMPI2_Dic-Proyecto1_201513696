﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.Tuplas;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;

namespace DBMS.Usql.Arbol.Nodos.Listas.Valor
{
    class _LST_VAL_ID : nodoModelo
    {
        /*
         * MakePlusRule(LST_VAL_ID, sComa, valId)
         */
        public _LST_VAL_ID(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public lstAtributos getLstVal()
        {

            return lstAtributos;
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | CONSULTA USQL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */


        public virtual tupla Seleccionar(tupla s)
        {

            itemValor aux1 = new itemValor();
            aux1.setValor(-1);
            itemValor aux2 = new itemValor();
            aux2.setValor(-1);
            s.listaValores.Add(aux1);
            s.listaValores.Add(aux2);
            return s;
        }

        public usqlTablaCartesiana getTablaFinal()
        {


            if (lstAtributos.listaAtributos.Count < 1)
            {
                return null;
            }

            usqlTabla tablaInicio = getTabla(lstAtributos.listaAtributos[0]);

            //tablaRetorno.titulo.asignarNombreTabla(tablaRetorno.nombre);

            //creo una tabla con la que voy  e estar concatenando las demas partes
            usqlTablaCartesiana nuevaTablaRetorno = new usqlTablaCartesiana(tablaInicio);
            //inicializando la tabla cartesiana pvto
            nuevaTablaRetorno.inicializar();

            usqlTablaCartesiana retorno = productoCartesiano(nuevaTablaRetorno, 1);
            //return retorno;




            //tengo que agregar otras dos columnas
            var salidaConsulta = from s in retorno.filas select new { tabla1 = s }; ;

            IList<tupla> concatList = new List<tupla>();
            foreach (var item in salidaConsulta)
            {

                List<itemValor> vale1 = item.tabla1.listaValores;
                //creando una nueva tupla
                tupla nuevaTupla = new tupla();
                nuevaTupla.listaValores.AddRange(vale1);


                itemValor aux1 = new itemValor();
                aux1.setValor(-1);
                itemValor aux2 = new itemValor();
                aux2.setValor(-1);
                nuevaTupla.listaValores.Add(aux1);
                nuevaTupla.listaValores.Add(aux2);
                concatList.Add(nuevaTupla);
            }
            retorno.filas = concatList;
            retorno.numIndices = concatList.Count;

            //agregando los dos items a la tabla titulo
            retorno.titulo.filaTitulo.Add("aux1", new celdaTitulo(tablaSimbolos, new token("vale1")));
            retorno.titulo.filaTitulo.Add("aux2", new celdaTitulo(tablaSimbolos, new token("vale2")));

            return retorno;

        }



        public usqlTablaCartesiana getTablaFinalAlter()
        {

            if (lstAtributos.listaAtributos.Count < 1)

                return null;

            usqlTabla tablaInicio = getTabla(lstAtributos.listaAtributos[0]);
            usqlTablaCartesiana nuevaTablaRetorno = new usqlTablaCartesiana(tablaInicio);
            nuevaTablaRetorno.inicializar();

            usqlTablaCartesiana retorno = productoCartesiano(nuevaTablaRetorno, 1);
            return retorno;

        }

        public usqlTabla getTablaUsql()
        {

            usqlTabla tablaInicio = getTabla(lstAtributos.listaAtributos[0]);
            return tablaInicio;

        }



        private usqlTablaCartesiana productoCartesiano(usqlTablaCartesiana tablaCart, int indice)
        {

            if (indice >= lstAtributos.listaAtributos.Count)
                return tablaCart;


            usqlTabla tabla2 = getTabla(lstAtributos.listaAtributos[indice]);
            //tablaRetorno.titulo.asignarNombreTabla(tablaRetorno.nombre);
            indice++;




            /*IList<tupla> tup = new List<tupla>();
            foreach(tupla  temp in tablaCart.filas)
            {
                tup.Add(temp);
            }*/



            var salidaConsulta = from s1 in tablaCart.filas
                                 from s2 in tabla2.filas
                                 select new { tabla1 = s1, tabla2 = s2 };


            //uniendo los titulos


            IList<tupla> retorno = new List<tupla>();
            foreach (var item in salidaConsulta)
            {

                List<itemValor> val1 = item.tabla1.listaValores;
                List<itemValor> val2 = item.tabla2.listaValores;

                //val1.AddRange(val2);

                //creando una nueva tupla
                tupla nuevaTupla = new tupla();
                nuevaTupla.listaValores.AddRange(val1);
                nuevaTupla.listaValores.AddRange(val2);

                //haciendo el insert en la nueva tabla
                //nuevaTabla.insertRow(nuevaTupla, lstAtributos.listaAtributos[indice - 1].tok);
                retorno.Add(nuevaTupla);
            }

            tablaCart.concatenarTabla(tabla2);
            tablaCart.filas = retorno;
            tablaCart.numIndices = retorno.Count;

            return productoCartesiano(tablaCart, indice);

        }



        private usqlTabla getTabla(itemAtributo item)
        {
            if (tablaSimbolos.listaBaseDeDatos.usar.lstTablas.ContainsKey(item.tok.valLower))
            {

                usqlTabla tempTabla = tablaSimbolos.listaBaseDeDatos.usar.lstTablas[item.tok.valLower];

                //var salidaConsulta = from s in filas select new {Id= s.getItemValor(0), Nombre= s.getItemValor(1)};
                return tempTabla;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se encuentra la tabla:" + item.tok.val + " en la base de datos actual", item.tok);
                return null;
            }
        }
    }
}
