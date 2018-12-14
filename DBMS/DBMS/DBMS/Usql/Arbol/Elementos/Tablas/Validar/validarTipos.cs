using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Validar
{
    class validarTipos
    {

        tablaSimbolos tabla;

        public validarTipos(tablaSimbolos tabla)
        {
            this.tabla = tabla;
        }



        public  Boolean validandoTipo(token nombre, token tipo1, itemValor valor2)
        {
            //aquí también hay que verificar las dimensiones


            //if (tipo1.Equals(tipo2) || tipo2.Equals("nulo")) 
            String tipoDato1 = itemValor.getTipoApartirDeString(tipo1.valLower);

            if (valor2.isTypeNulo())
            {
                return true;
            }
            else if (tipoDato1.Equals("objeto") && valor2.isTypeObjeto())
            //validando que sean los mismos tipos
            {
                if (tipo1.valLower.Equals(valor2.nombreObjeto))
                {
                    return true;
                }
                else
                {
                    tabla.tablaErrores.insertErrorSemantic("[objetos]Se está intentando guardar en :" + nombre.val + " de tipo " + tipo1.valLower + ", un valor de tipo " + valor2.nombreObjeto, nombre);

                    return false;
                }
            }

            else if (tipoDato1.Equals(valor2.getTipo()) || valor2.getTipo().Equals("nulo"))
            {
                return true;
            }
            else
            {

                tabla.tablaErrores.insertErrorSemantic("Se está intentando guardar en :" + nombre.val + " de tipo " + tipo1.valLower + ", un valor de tipo " + valor2.getTipo(), nombre);
                return false;
            }

        }




        public Boolean validandoTipoSinMensaje(token nombre, token tipo1, itemValor valor2)
        {
            //aquí también hay que verificar las dimensiones


            //if (tipo1.Equals(tipo2) || tipo2.Equals("nulo")) 
            String tipoDato1 = itemValor.getTipoApartirDeString(tipo1.valLower);

            if (valor2.isTypeNulo())
            {
                return true;
            }
            else if (tipoDato1.Equals("objeto") && valor2.isTypeObjeto())
            //validando que sean los mismos tipos
            {
                if (tipo1.valLower.Equals(valor2.nombreObjeto))
                {
                    return true;
                }
                else
                {
                   
                    return false;
                }
            }

            else if (tipoDato1.Equals(valor2.getTipo()) || valor2.getTipo().Equals("nulo"))
            {
                return true;
            }
            else
            {

                 return false;
            }

        }

         


    }
}
