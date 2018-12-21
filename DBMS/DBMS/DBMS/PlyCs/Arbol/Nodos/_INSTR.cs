using DBMS.PlyCs.Arbol.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Gramatica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.PlyCs.Arbol.Nodos
{
    class _INSTR : nodoModelo
    /*
      INSTR.Rule = valCadena + sDosPuntos + valCadena
                    | valCadena + sDosPuntos + valNumero
                    | valCadena + sDosPuntos + PARENT ;
     */
    {
        public _INSTR(string nombre) : base(nombre)
        {
        }


        public override itemRetorno ejecutar(tablaSimbolos tabl)
        {


            itemRetorno retorno = new itemRetorno(0);
            _VAL_CADENA nodoCad1 = (_VAL_CADENA)hijos[0];
            String primerAtributo = nodoCad1.getCadena();

            if (primerAtributo.ToLower()=="instruccion")
            {


                _VAL_CADENA nodoCad2 = (_VAL_CADENA)hijos[1];
                String segundaCadena = nodoCad2.getCadena();
                //ejecutando la cadena
                //Console.WriteLine("ejecutando la cadena");
                //Console.WriteLine(segundaCadena);


                Form1.analizador = new anlzUsql(tabl);
                try
                {

                    Form1.analizador.iniciarAnalisis(segundaCadena);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al analizar USQL");
                    Console.WriteLine(e.Message.ToString());
                }

                 

                //el retorno del analizador
                String respuestaUSQL = "Respuesta de retorno";




                retorno = new itemRetorno(respuestaUSQL);
                return retorno; 

            }
            return retorno;
        }
    }
}
