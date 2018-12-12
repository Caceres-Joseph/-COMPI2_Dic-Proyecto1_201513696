
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Nodos.Inicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Listas
{
    class lstPrincipal : lstPolimorfismo
    {
        public lstPrincipal(tablaSimbolos tabla, string nombre) : base(tabla, nombre)
        {
        }


        public override void ejecutar(elementoEntorno elem)
        {
            if (tabla.hayErrores("lstPrincipal_ejecutar"))
                return;

            if (listaPolimorfa.Count>0)
            {
                elementoPolimorfo temp = listaPolimorfa[0];
                if (temp.LST_CUERPO.nombre.Equals("LST_CUERPO"))
                {
                    _LST_CUERPO val = (_LST_CUERPO)temp.LST_CUERPO;
                    itemValor retornoFuncion = new itemValor();

                    retornoFuncion.setTypeVacio();
                    
                    val.ejecutar(elem );
                    imprimir(elem);

                }
            }
            else
            {
                tabla.tablaErrores.insertErrorSemantic("No se encuentra el main", new token());
            }
 
        }

        public void imprimir(elementoEntorno elem)
        {
          //  Console.WriteLine("-----La tabla de simbolos de pincipal----");
            elem.imprimir();
             
        }


        public void println(String mensaje)
        {
            Console.WriteLine("[lstVariablesGlobales]" + mensaje);
        }
    }
}
