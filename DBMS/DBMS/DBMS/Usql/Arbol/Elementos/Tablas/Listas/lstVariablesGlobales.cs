using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Objetos;
using DBMS.Usql.Arbol.Nodos.Ssl.Asignar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Listas
{
    class lstVariablesGlobales : lstPolimorfismo
    {
        public lstVariablesGlobales(tablaSimbolos tabla, string nombre) : base(tabla, nombre)
        {
        }

        public override void ejecutar(elementoEntorno elem)
        {
            foreach (elementoPolimorfo polim in listaPolimorfa)
            {


                itemValor val = new itemValor();


                /*
                 * Si es objeto se inicializa
                 */
                  
                if (itemValor.getTipoApartirDeString(polim.tipo.valLower).Equals("objeto"))
                {

                    elementoClase temp = tabla.getClase(polim.tipo);
                    if (temp != null)
                    {
                        objetoClase nuevoObjeto = new objetoClase(temp, tabla);
                        lstValores lstValores2 = new lstValores();
                        nuevoObjeto.ejecutarGlobales();//cargando sus valores globales 

                        //asignando el objeto
                        val.setValue(nuevoObjeto, polim.tipo.valLower);
                    }

                }


                /*
                 * Inesrtando el nuevo objeto a la tabla de simbolos
                 */

                itemEntorno it = new itemEntorno(polim.nombre, polim.tipo, val, polim.visibilidad, polim.getDimension(), tabla);
                 
                elem.insertarEntorno(it);

            }
        }

        /*
        public override void ejecutar(elementoEntorno elem)
        {
            foreach (elementoPolimorfo temp in listaPolimorfa)
            {


                if (temp.LST_CUERPO.nombre.Equals("VAL"))
                {
                    if (tabla.hayErrores("lstVariablesGlobales_ejecutar"))
                        return;

                    _VAL val = (_VAL)temp.LST_CUERPO;
                    itemEntorno it = new itemEntorno(temp.nombre, temp.tipo, val.getValor(elem, temp.tipo), temp.visibilidad, temp.getDimension(), tabla);
                    elem.insertarEntorno(it);
                }
                else
                {
                    println("vienen nulos");

                    itemEntorno it = new itemEntorno(temp.nombre, temp.tipo, new itemValor(), temp.visibilidad, temp.getDimension(), tabla);
                    elem.insertarEntorno(it);
                    //hay que asignarle el valor nulo
                    //println("la variable no tiene valor");
                }
            }
        }
        */




        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Imprimir
        |-------------------------------------------------------------------------------------------------------------------
        |
        */


        public void println(String mensaje)
        {
            Console.WriteLine("[lstVariablesGlobales]" + mensaje);
        }
    }
}
