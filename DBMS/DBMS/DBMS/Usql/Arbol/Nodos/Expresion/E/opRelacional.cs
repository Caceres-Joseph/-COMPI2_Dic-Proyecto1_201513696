using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E
{
    class opRelacional : opModelo
    {
        public opRelacional(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }


        public virtual bool Donde(itemValor s1, itemValor s2)
        {

            return false;


        }

        public virtual tupla Seleccionar(tupla s)
        {
            return s;
        }



        public itemValor operarRelacional(String ambito, elementoEntorno elem, token tokLinea)
        {
            itemValor retorno = new itemValor();
            itemValor val1 = hijo1.getValor(elem);
            itemValor val2 = hijo2.getValor(elem);


            if (val1 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opRelacional]" + ambito + "Hijo1 es null", tokLinea);
                return retorno;
            }
            if (val2 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opRelacional]" + ambito + " Hijo1 es null", tokLinea);
                return retorno;
            }


            //aquí ejecuto las sentencia where 
            /*
            |--------------------------------------------------------------------------
            | Columna
            |--------------------------------------------------------------------------
            */
            /*
             *columna == columna 
             */

            if (val1.isTypeCartColumna() && val2.isTypeCartColumna())
            {
                usqlTablaCartesiana tempTabla = getTablaCartesiana(elem);

                int indice = indiceColumnaEnTabla(val1.nombreCartColumna, elem);
                int indice2 = indiceColumnaEnTabla(val2.nombreCartColumna, elem);

                if (indice == -1)
                    return retorno;

                //hago la consulta
                var salidaConsulta = from s in tempTabla.filas
                                     where Donde(s.getItemValor(indice), s.getItemValor(indice2))
                                     //where s.getItemValor(indice).valor.Equals(s.getItemValor(indice2).valor)
                                     select Seleccionar(s);

                IList<tupla> concatList = salidaConsulta.ToList<tupla>();

                return getTablaFinal(concatList, tempTabla);
            }
            /*
             *columna == Tablacolumna 
             */
            else if (val1.isTypeCartColumna() && val2.isTypeCartTablaColumna())
            {

                retorno.setValor(true);
                tabla.tablaErrores.insertErrorSemantic("Debe especificar a que tabla pertenece la columna:" + val1.nombreCartColumna.val, val1.nombreCartColumna);
                return retorno;
            }
            /*
             *columna == valor 
             */
            else if (val1.isTypeCartColumna())
            {
                usqlTablaCartesiana tempTabla = getTablaCartesiana(elem);

                int indice = indiceColumnaEnTabla(val1.nombreCartColumna, elem);
                if (indice == -1)
                    return retorno;

                //hago la consulta
                var salidaConsulta = from s in tempTabla.filas
                                     where Donde(s.getItemValor(indice), val2)
                                     //where s.getItemValor(indice).valor.Equals(val2.valor)
                                     //where s.getItemValor(indice).valor.Equals(val2.valor)
                                     select Seleccionar(s);


                IList<tupla> concatList = salidaConsulta.ToList<tupla>();
                return getTablaFinal(concatList, tempTabla);
            }

            /*
            |--------------------------------------------------------------------------
            | TablaColumna
            |--------------------------------------------------------------------------
            */
            /*
             *Tablacolumna == columna 
             */

            else if (val1.isTypeCartTablaColumna() && val2.isTypeCartColumna())
            {

                retorno.setValor(true);
                tabla.tablaErrores.insertErrorSemantic("Debe especificar a que tabla pertenece la columna:" + val2.nombreCartColumna.val, val2.nombreCartColumna);
                return retorno;
            }

            /*
             *Tablacolumna == Tablacolumna 
             */

            else if (val1.isTypeCartTablaColumna() && val2.isTypeCartTablaColumna())
            {
                usqlTablaCartesiana tempTabla = getTablaCartesiana(elem);

                int indice = indiceColumnaEnTabla(val1.nombreCartColumna, val1.nombreCartTabla, elem);
                int indice2 = indiceColumnaEnTabla(val2.nombreCartColumna, val2.nombreCartTabla, elem);
                if (indice == -1)
                    return retorno;

                //hago la consulta
                var salidaConsulta = from s in tempTabla.filas
                                     where Donde(s.getItemValor(indice), s.getItemValor(indice2))
                                     //where s.getItemValor(indice).valor.Equals(s.getItemValor(indice2).valor)
                                     //where s.getItemValor(indice).valor.Equals(s.getItemValor(indice2).valor)
                                     select Seleccionar(s);

                IList<tupla> concatList = salidaConsulta.ToList<tupla>();

                return getTablaFinal(concatList, tempTabla);
            }
            /*
             *Tablacolumna == valor 
             */
            else if (val1.isTypeCartTablaColumna())
            {
                usqlTablaCartesiana tempTabla = getTablaCartesiana(elem);

                int indice = indiceColumnaEnTabla(val1.nombreCartColumna, val1.nombreCartTabla, elem);
                if (indice == -1)
                    return retorno;

                //hago la consulta
                var salidaConsulta = from s in tempTabla.filas
                                     where Donde(s.getItemValor(indice), val2)
                                     //where s.getItemValor(indice).valor.Equals(val2.valor)
                                     //where s.getItemValor(indice).valor.Equals(val2.valor)
                                     select Seleccionar(s);

                IList<tupla> concatList = salidaConsulta.ToList<tupla>();

                return getTablaFinal(concatList, tempTabla);
            }


            /*
            |--------------------------------------------------------------------------
            | Valor
            |--------------------------------------------------------------------------
            */

            /*
             *valor == columna 
             */
            else if (val2.isTypeCartColumna())
            {
                usqlTablaCartesiana tempTabla = getTablaCartesiana(elem);

                int indice = indiceColumnaEnTabla(val2.nombreCartColumna, elem);
                if (indice == -1)
                    return retorno;

                //hago la consulta
                var salidaConsulta = from s in tempTabla.filas
                                     where Donde(s.getItemValor(indice), val1)
                                     //where s.getItemValor(indice).valor.Equals(val1.valor)
                                     //where s.getItemValor(indice).valor.Equals(val1.valor)
                                     select Seleccionar(s);


                IList<tupla> concatList = salidaConsulta.ToList<tupla>();

                return getTablaFinal(concatList, tempTabla);
            }

            /*
             *valor == Tablacolumna 
             */
            else if (val2.isTypeCartTablaColumna())
            {

                usqlTablaCartesiana tempTabla = getTablaCartesiana(elem);

                int indice = indiceColumnaEnTabla(val2.nombreCartColumna, val2.nombreCartTabla, elem);
                if (indice == -1)
                    return retorno;

                //hago la consulta
                var salidaConsulta = from s in tempTabla.filas
                                     where Donde(s.getItemValor(indice), val1)
                                     //where s.getItemValor(indice).valor.Equals(val1.valor)
                                     //where s.getItemValor(indice).valor.Equals(val1.valor)
                                     select Seleccionar(s);

                IList<tupla> concatList = salidaConsulta.ToList<tupla>();
                return getTablaFinal(concatList, tempTabla);
            }
            /*
             *valor == valor 
             */
            else
            {
                retorno = new itemValor();
                retorno.setValor(true);
                return retorno;
            }
        }


    }
}
