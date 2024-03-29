﻿using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Nodos.Inicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace DBMS.Usql.Arbol.Elementos.Tablas.Listas
{
    class lstConstructores : lstPolimorfismo
    {
        public lstConstructores(tablaSimbolos tabla, string nombre) : base(tabla, nombre)
        {
        }

        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN DE METODO  CONSTRUCTOR
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public void ejecutarMetodo(token nombre, lstValores parametros, elementoEntorno tablaEntorno)
        {
            
            //aqui es donde tengo que buscar si existe 
            Console.WriteLine("ejecutando Metodo:" + nombre.val);
            elementoPolimorfo temp = getElementoPolimorfo2(nombre, parametros);
            if (temp != null)
            //neuvo entorno
            {
                elementoEntorno hijo1 = new elementoEntorno(tablaEntorno, tabla, "main");
               


                if (temp.LST_CUERPO.nombre.Equals("LST_CUERPO"))
                /*
                |---------------------------- 
                |  Ejecutando el cuerpo del metodo
                |-----------------------
                | Los constructores no retornan nada
                */
                {
                    guardarParametrosEnLaTabla(temp.lstParametros, parametros, hijo1);
                    _LST_CUERPO val = (_LST_CUERPO)temp.LST_CUERPO;
                    val.ejecutar(hijo1);

                }else if (temp.LST_CUERPO.nombre.Equals("LST_CUERPO2"))
                /*
                |---------------------------- 
                |  Ejecutando el cuerpo del metodo
                |-----------------------
                | Los constructores no retornan nada
                */
                {
                    //cargo los parametros en el ambito global, jejejejeje
                    guardarParametrosEnLaTabla(temp.lstParametros, parametros, tablaEntorno);
                    //_LST_CUERPO2 val = (_LST_CUERPO2)temp.LST_CUERPO;
                    //val.ejecutarConstructor(hijo1, parametros);

                }

            }
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN DE METODO  CONSTRUCTOR Heredado
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public void ejecutarConstructorHeredad(lstValores parametros, elementoEntorno tablaEntorno, token mensaje)
        {
            //aqui es donde tengo que buscar si existe 
            Console.WriteLine("ejecutando Constructor Heredado:");
            elementoPolimorfo temp = getConstructoHeredado( parametros, mensaje);
            if (temp != null)
            //neuvo entorno
            {
                elementoEntorno hijo1 = new elementoEntorno(tablaEntorno, tabla, "main");
                guardarParametrosEnLaTabla(temp.lstParametros, parametros, hijo1);


                if (temp.LST_CUERPO.nombre.Equals("LST_CUERPO"))
                /*
                |---------------------------- 
                |  Ejecutando el cuerpo del metodo
                |-----------------------
                | Los constructores no retornan nada
                */
                {
                    _LST_CUERPO val = (_LST_CUERPO)temp.LST_CUERPO;
                    val.ejecutar(hijo1);

                }

            }
        }

    }
}
