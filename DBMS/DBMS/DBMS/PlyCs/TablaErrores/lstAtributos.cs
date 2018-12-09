using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.TablaErrores
{
    class lstAtributos
    {
        public List<itemAtributo> listaAtributos;
         
        public lstAtributos()
        {

            listaAtributos = new List<itemAtributo>();
        }

        public void insertar(String nombre, token tok)
        {
            itemAtributo elem = new itemAtributo(tok, nombre);
            listaAtributos.Add(elem);


        }
        public String getValItem(int indice)
        {
            String retorno = "";
            if (listaAtributos.Count < indice)
            {
                  Console.WriteLine("Indice fuera de rango");
            }
            else
            {
                retorno = listaAtributos[indice].tok.val;
            }

            return retorno;
        }

        public token getToken(int indice)
        {
            token retorno = new token("", 0, 0, "---");
            if (listaAtributos.Count < indice)
            {
                Console.WriteLine("Indice fuera de rango");
            }
            else
            {
                retorno = listaAtributos[indice].tok;
            }

            return retorno;
        }

        /*
        public void insertarP(String llave, token tok, int inicio)
        {

            if (listaAtributos.ContainsKey(llave))
            {
                insertarP(llave, tok, inicio + 1);
            }
            else
            {
                listaAtributos.Add(llave, tok);
            }

        }



        public void imprimirAtributos()
        {
          

            int i = 0;
            foreach (KeyValuePair<string, token> kvp in listaAtributos)
            {
                token temp= kvp.Value;
                println("\t[" + i + "] val:" + temp.val + "\tlinea:" + temp.linea + "\ttcol:" + temp.columna);
                //Console.WriteLine("Key = {0}, Value = {1}",
                //    kvp.Key, kvp.Value);
                i++;
            }
 

        }
        */


        public void imprimir()
        {

            int i = 0;
            foreach (itemAtributo item in listaAtributos)
            {
                token temp = item.tok;
                println("\t[" + i + "] val:" + temp.val + "\tlinea:" + temp.linea + "\ttcol:" + temp.columna + "\tamb:" + temp.archivo);
                i++;
            }
        }

        public void println(String mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
