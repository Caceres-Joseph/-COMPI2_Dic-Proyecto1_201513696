﻿
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Objetos;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Elementos
{
    class elementoEntorno
    {
        public Dictionary<String, itemEntorno> lstEntorno;
        public elementoEntorno anterior;
        public tablaSimbolos tabla;
        public String nombre;

        public usqlTablaCartesiana tablaFrom;


        public elementoEntorno(elementoEntorno anterior, tablaSimbolos tabla, String nombre)
        { 
            this.nombre = nombre;
            this.tabla = tabla;
            this.anterior = anterior;
            lstEntorno = new Dictionary<string, itemEntorno>();
        }


        public void insertarEntorno(itemEntorno param)
        {
            if (tabla.hayErrores("elementoEntorno"))
                return;

            String llave = param.nombre.valLower;
            if (!lstEntorno.ContainsKey(llave))
            {
                lstEntorno.Add(llave, param);
            }
            else
            {
                tabla.tablaErrores.insertErrorSemantic("La variable " + param.nombre.val + " ya se encuentra declarada en el mismo ambito.", param.nombre);
            }
        }

        public void imprimir()
        {
            Console.WriteLine("+--------------------+");
            Console.WriteLine("| Entorno [" + nombre + "]");
            Console.WriteLine("+--------------------+");
            foreach (var el in lstEntorno)
            {
                Console.WriteLine("\tkey->" + el.Key);
                el.Value.imprimir();
            }

            if (anterior != null)
            {
                anterior.imprimir();
            }
        }




        public itemEntorno getItemValor(String idVariable)
        {
            itemEntorno retorno = null;




            if (lstEntorno.ContainsKey(idVariable))
            {
                itemEntorno el = lstEntorno[idVariable];
                return el;
            }
            else
            {

                if (anterior != null)
                {
                    return anterior.getItemValor(idVariable);
                }
            }

            return retorno;
        }

        public elementoEntorno getEntornoGlobal()
        {
             
            if (anterior==null)
            {
                return this;
            }
            else
            {
                return anterior.getEntornoGlobal();
            } 
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */


        public elementoEntorno getGlobal()
        {


            if (nombre.Equals("global"))
            {
                return this;
            }
            else
            {
                if (anterior != null)
                {
                    return anterior.getGlobal();
                }
                else
                {
                    return null;
                }
            }
        }


        public String getEtiqueta()
        {
            String retorno = "";
            foreach (var el in lstEntorno)
            {
                if (el.Key.Equals("etiqueta"))
                {

                    Object temp = el.Value.valor.getValorParseado("cadena");
                    if (temp != null)
                    {
                        return (String)temp;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            return retorno;
        }



        public String getSugerir()
        {
            String retorno = "";
            foreach (var el in lstEntorno)
            {
                if (el.Key.Equals("sugerir"))
                {

                    Object temp = el.Value.valor.getValorParseado("cadena");
                    if (temp != null)
                    {
                        return (String)temp;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            return retorno;
        }



        public String getRequerido()
        {
            String retorno = "";
            foreach (var el in lstEntorno)
            {
                if (el.Key.Equals("requeridomsn"))
                {

                    Object temp = el.Value.valor.getValorParseado("cadena");
                    if (temp != null)
                    {
                        return (String)temp;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            return retorno;
        }

    }
}
