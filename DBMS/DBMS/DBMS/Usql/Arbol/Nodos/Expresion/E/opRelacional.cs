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
            return true;
        }

        public virtual tupla Seleccionar(tupla s, itemValor s1, itemValor s2, int columnasExtras)
        {
            return s;
        }


        public virtual IList<tupla> agregarValAux2(IList<tupla> tabla1, IList<tupla> tabla2)
        {
            IList<tupla> retorno = new List<tupla>();

            if (tabla1.Count != tabla2.Count)
            {
                Console.WriteLine("[opRErl]El tamaño de las tablas no coinciden");
                return retorno;
            }


            for (int i = 0; i < tabla1.Count; i++)
            {
                tupla temp = tabla1[i];
                tupla temp2 = tabla2[i];

                //a la ultima posicion le asigno la penultima de la tabla2
                itemValor vale2= temp2.listaValores[temp2.listaValores.Count - 2];
                itemValor vale = temp.listaValores[temp.listaValores.Count - 1];
                vale.tipo = vale2.tipo;
                vale.valor = vale2.valor;


                retorno.Add(temp);
            }
            return retorno;
        }

        public virtual itemValor operarValorValor(elementoEntorno entorno)
        {

            itemValor val = new itemValor();

            return val;
        }



        public itemValor operarRelacional(String ambito, elementoEntorno elem, token tokLinea)
        {
            itemValor retorno = new itemValor();
            itemValor val1 = hijo1.operarTabla(elem);
            itemValor val2 = hijo2.operarTabla(elem);


            if (val1 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[operacion]" + ambito + "Hijo1 es null", tokLinea);
                return retorno;
            }
            if (val2 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[operacion]" + ambito + " Hijo1 es null", tokLinea);
                return retorno;
            }


            //aquí ejecuto las sentencia where 
            /*
            |--------------------------------------------------------------------------
            | Columna Extra
            |--------------------------------------------------------------------------
            */

            /*
             *columnaExtra == columnaExtra 
             */
            if (val1.isTypeColumnaExtra() && val2.isTypeColumnaExtra())
            { 

                int indice = val1.tablaCartesiana.titulo.filaTitulo.Count;
                int indice2 = val2.tablaCartesiana.titulo.filaTitulo.Count+1;

                if (indice == -1)
                    return retorno;


                IList<tupla> tablaResultado = agregarValAux2(val1.tablaCartesiana.filas, val2.tablaCartesiana.filas);
                

                usqlTablaCartesiana tempTabla = new usqlTablaCartesiana(val1.tablaCartesiana, 0);
                tempTabla.filas = tablaResultado;



                //hago la consulta
                var salidaConsulta = from s in tempTabla.filas
                                     where Donde(s.getItemValor(indice), s.getItemValor(indice2)) 
                                     select Seleccionar(s, s.getItemValor(indice), s.getItemValor(indice2), 2); 


                IList<tupla> concatList = salidaConsulta.ToList<tupla>();

                return getTablaFinal(concatList, tempTabla);
            }

            /*
             *columnaExtra == columna 
             */
            else if (val1.isTypeColumnaExtra() && val2.isTypeCartColumna())
            {

                usqlTablaCartesiana tempTabla = new usqlTablaCartesiana(val1.tablaCartesiana, 0);


                int indice = val1.tablaCartesiana.titulo.filaTitulo.Count;
                int indice2 = indiceColumnaEnTabla(val2.nombreCartColumna, elem);

                if (indice == -1)
                    return retorno;

                //hago la consulta
                var salidaConsulta = from s in tempTabla.filas
                                     where Donde(s.getItemValor(indice), s.getItemValor(indice2))
                                     //where s.getItemValor(indice).valor.Equals(s.getItemValor(indice2).valor)
                                     //where s.getItemValor(indice).valor.Equals(s.getItemValor(indice2).valor)
                                     select Seleccionar(s, s.getItemValor(indice), s.getItemValor(indice2), 1);

                IList<tupla> concatList = salidaConsulta.ToList<tupla>();

                return getTablaFinal(concatList, tempTabla);
            }

            /*
             *columnaExtra == Tablacolumna 
             */
            else if (val1.isTypeColumnaExtra() && val2.isTypeCartTablaColumna())
            { 

                usqlTablaCartesiana tempTabla = new usqlTablaCartesiana(val1.tablaCartesiana, 0);

                int indice = val1.tablaCartesiana.titulo.filaTitulo.Count;
                int indice2 = indiceColumnaEnTabla(val2.nombreCartColumna, val2.nombreCartTabla, elem);
                if (indice == -1)
                    return retorno;

                //hago la consulta
                var salidaConsulta = from s in tempTabla.filas
                                     where Donde(s.getItemValor(indice), s.getItemValor(indice2))
                                     //where s.getItemValor(indice).valor.Equals(s.getItemValor(indice2).valor)
                                     //where s.getItemValor(indice).valor.Equals(s.getItemValor(indice2).valor)
                                     select Seleccionar(s, s.getItemValor(indice), s.getItemValor(indice2), 1);

                IList<tupla> concatList = salidaConsulta.ToList<tupla>();

                return getTablaFinal(concatList, tempTabla);
            }

            /*
             *columnaExtra == valor 
             */
            else if (val1.isTypeColumnaExtra())
            { 
                usqlTablaCartesiana tempTabla = new usqlTablaCartesiana(val1.tablaCartesiana, 0);

                int indice = val1.tablaCartesiana.titulo.filaTitulo.Count;
                if (indice == -1)
                    return retorno;

                //hago la consulta
                var salidaConsulta = from s in tempTabla.filas
                                     where Donde(s.getItemValor(indice), val2)
                                     //where s.getItemValor(indice).valor.Equals(val2.valor)
                                     //where s.getItemValor(indice).valor.Equals(val2.valor)
                                     select Seleccionar(s, s.getItemValor(indice), val2, 1);


                IList<tupla> concatList = salidaConsulta.ToList<tupla>();
                return getTablaFinal(concatList, tempTabla);

            }
            /*
            |--------------------------------------------------------------------------
            | Columna
            |--------------------------------------------------------------------------
            */
            /*
             *columna == columna 
             */

            else if (val1.isTypeCartColumna() && val2.isTypeCartColumna())
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
                                     //where s.getItemValor(indice).valor.Equals(s.getItemValor(indice2).valor)
                                     select Seleccionar(s, s.getItemValor(indice), s.getItemValor(indice2), 0);

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
             *columna == columnaExtra 
             */
            else if (val1.isTypeColumnaExtra() && val2.isTypeColumnaExtra())
            {

                usqlTablaCartesiana tempTabla = new usqlTablaCartesiana(val2.tablaCartesiana, 0);

                int indice = indiceColumnaEnTabla(val1.nombreCartColumna, elem);
                int indice2 = val2.tablaCartesiana.titulo.filaTitulo.Count;

                if (indice == -1)
                    return retorno;

                //hago la consulta
                var salidaConsulta = from s in tempTabla.filas
                                     where Donde(s.getItemValor(indice), s.getItemValor(indice2))
                                     //where s.getItemValor(indice).valor.Equals(s.getItemValor(indice2).valor)
                                     //where s.getItemValor(indice).valor.Equals(s.getItemValor(indice2).valor)
                                     select Seleccionar(s, s.getItemValor(indice), s.getItemValor(indice2), 1);


                IList<tupla> concatList = salidaConsulta.ToList<tupla>();
                return getTablaFinal(concatList, tempTabla);
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
                                     select Seleccionar(s, s.getItemValor(indice), val2, 0);


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
                                     select Seleccionar(s, s.getItemValor(indice), s.getItemValor(indice2), 0);

                IList<tupla> concatList = salidaConsulta.ToList<tupla>();

                return getTablaFinal(concatList, tempTabla);
            }
            /*
             *Tablacolumna == columnaExtra 
             */
            else if (val1.isTypeColumnaExtra() && val2.isTypeColumnaExtra())
            {

                usqlTablaCartesiana tempTabla = new usqlTablaCartesiana(val2.tablaCartesiana, 0);


                int indice = indiceColumnaEnTabla(val1.nombreCartColumna, val1.nombreCartTabla, elem);
                int indice2 = val2.tablaCartesiana.titulo.filaTitulo.Count;

                if (indice == -1)
                    return retorno;

                //hago la consulta
                var salidaConsulta = from s in tempTabla.filas
                                     where Donde(s.getItemValor(indice), s.getItemValor(indice2))
                                     //where s.getItemValor(indice).valor.Equals(s.getItemValor(indice2).valor)
                                     //where s.getItemValor(indice).valor.Equals(s.getItemValor(indice2).valor)
                                     select Seleccionar(s, s.getItemValor(indice), s.getItemValor(indice2), 1);


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
                                     select Seleccionar(s, s.getItemValor(indice), val2, 0);

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
                                     select Seleccionar(s, s.getItemValor(indice), val1, 0);


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
                                     select Seleccionar(s, s.getItemValor(indice), val1, 0);

                IList<tupla> concatList = salidaConsulta.ToList<tupla>();
                return getTablaFinal(concatList, tempTabla);
            }
            /*
             *valor == columnaExtra 
             */
            else if (val1.isTypeColumnaExtra() && val2.isTypeColumnaExtra())
            { 
                usqlTablaCartesiana tempTabla = new usqlTablaCartesiana(val2.tablaCartesiana, 0);

                int indice2 = val2.tablaCartesiana.titulo.filaTitulo.Count;


                //hago la consulta
                var salidaConsulta = from s in tempTabla.filas
                                     where Donde(val1, s.getItemValor(indice2))
                                     select Seleccionar(s, val1, s.getItemValor(indice2), 1);


                IList<tupla> concatList = salidaConsulta.ToList<tupla>();
                return getTablaFinal(concatList, tempTabla);
            }
            /*
             *valor == valor 
             */
            else
            {

                return operarValorValor(elem);
            }
        }


    }
}
