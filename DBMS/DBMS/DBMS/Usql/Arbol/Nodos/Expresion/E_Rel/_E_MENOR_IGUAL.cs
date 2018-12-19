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
using DBMS.Usql.Arbol.Nodos.Expresion.E;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E_Rel
{
    class _E_MENOR_IGUAL : opModelo
    {
        public _E_MENOR_IGUAL(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }

        public itemValor menorIgualQueUsql(String ambito, elementoEntorno elem, token tokLinea)
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
                                     where s.getItemValor(indice).getDecimal() <= s.getItemValor(indice2).getDecimal()
                                     select new { tabla1 = s };


                IList<tupla> concatList = new List<tupla>();
                foreach (var item in salidaConsulta)
                {

                    List<itemValor> vale1 = item.tabla1.listaValores;
                    //creando una nueva tupla
                    tupla nuevaTupla = new tupla();
                    nuevaTupla.listaValores.AddRange(vale1);
                    concatList.Add(nuevaTupla);
                }

                tempTabla.filas = concatList;
                tempTabla.numIndices = concatList.Count;
                retorno.setValor(true);
                retorno.tablaCartesiana = tempTabla;
                return retorno;
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
                                     where s.getItemValor(indice).getDecimal() <= val2.getDecimal()
                                     select new { tabla1 = s };


                IList<tupla> concatList = new List<tupla>();
                foreach (var item in salidaConsulta)
                {

                    List<itemValor> vale1 = item.tabla1.listaValores;
                    //creando una nueva tupla
                    tupla nuevaTupla = new tupla();
                    nuevaTupla.listaValores.AddRange(vale1);
                    concatList.Add(nuevaTupla);
                }


                tempTabla.filas = concatList;
                tempTabla.numIndices = concatList.Count;
                retorno.setValor(true);
                retorno.tablaCartesiana = tempTabla;
                return retorno;
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
                                     where s.getItemValor(indice).getDecimal() <= s.getItemValor(indice2).getDecimal()
                                     select new { tabla1 = s };

                IList<tupla> concatList = new List<tupla>();
                foreach (var item in salidaConsulta)
                {
                    List<itemValor> vale1 = item.tabla1.listaValores;

                    //creando una nueva tupla
                    tupla nuevaTupla = new tupla();
                    nuevaTupla.listaValores.AddRange(vale1);
                    concatList.Add(nuevaTupla);
                }
                tempTabla.filas = concatList;
                tempTabla.numIndices = concatList.Count;
                retorno.setValor(true);
                retorno.tablaCartesiana = tempTabla;
                return retorno;
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
                                     where s.getItemValor(indice).getDecimal() <= val2.getDecimal()
                                     select new { tabla1 = s };

                IList<tupla> concatList = new List<tupla>();
                foreach (var item in salidaConsulta)
                {
                    List<itemValor> vale1 = item.tabla1.listaValores;

                    //creando una nueva tupla
                    tupla nuevaTupla = new tupla();
                    nuevaTupla.listaValores.AddRange(vale1);
                    concatList.Add(nuevaTupla);
                }
                tempTabla.filas = concatList;
                tempTabla.numIndices = concatList.Count;
                retorno.setValor(true);
                retorno.tablaCartesiana = tempTabla;
                return retorno;
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
                                     where s.getItemValor(indice).getDecimal() <= val1.getDecimal()
                                     select new { tabla1 = s };


                IList<tupla> concatList = new List<tupla>();
                foreach (var item in salidaConsulta)
                {

                    List<itemValor> vale1 = item.tabla1.listaValores;
                    //creando una nueva tupla
                    tupla nuevaTupla = new tupla();
                    nuevaTupla.listaValores.AddRange(vale1);
                    concatList.Add(nuevaTupla);
                }


                tempTabla.filas = concatList;
                tempTabla.numIndices = concatList.Count;
                retorno.setValor(true);
                retorno.tablaCartesiana = tempTabla;
                return retorno;
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
                                     where s.getItemValor(indice).getDecimal() <= val1.getDecimal()
                                     select new { tabla1 = s };

                IList<tupla> concatList = new List<tupla>();
                foreach (var item in salidaConsulta)
                {
                    List<itemValor> vale1 = item.tabla1.listaValores;

                    //creando una nueva tupla
                    tupla nuevaTupla = new tupla();
                    nuevaTupla.listaValores.AddRange(vale1);
                    concatList.Add(nuevaTupla);
                }
                tempTabla.filas = concatList;
                tempTabla.numIndices = concatList.Count;
                retorno.setValor(true);
                retorno.tablaCartesiana = tempTabla;
                return retorno;
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


        public void println(String mensaje)
        {
            Console.WriteLine("[_E_MENOR_IGUAL_QUE]" + mensaje);
        }

    }
}
