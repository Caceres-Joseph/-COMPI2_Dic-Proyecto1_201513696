using DBMS.PlyCs.Arbol.Elementos;
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


        public override itemRetorno ejecutar()
        {


            itemRetorno retorno = new itemRetorno(0);
            String primerAtributo = lstAtributos.getValItem(0);


            if (primerAtributo.ToLower()=="instruccion")
            {


                //ejecutando la cadena
                Console.WriteLine(lstAtributos.getValItem(2));


                //el retorno del analizador
                String respuestaUSQL = "Respuesta de retorno";




                retorno = new itemRetorno(respuestaUSQL);
                return retorno; 

            }
            return retorno;
        }
    }
}
