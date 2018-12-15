using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using DBMS.Usql.Arbol.Elementos.Tablas.Validar;
using DBMS.Usql.Arbol.Nodos.Expresion.E;
using DBMS.Usql.Arbol.Nodos.Expresion.E.OpeAritmetica;
using DBMS.Usql.Arbol.Nodos.Expresion.Id;

namespace DBMS.Usql.Arbol.Nodos.Ssl.Asignar
{
    /*
     * ID_VAR_FUNC + sMenos + sMenos
     */
    class _SSL_ASIGNAR_3 : _SSL_ASIGNAR
    {
        public _SSL_ASIGNAR_3(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override itemRetorno ejecutar(elementoEntorno elementoEntor)
        /*
        |---------------------------- 
        | EJECUTAR 
        |----------------------------
        | 0= normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */
        {

            itemRetorno retorno = new itemRetorno(0);
            if (hayErrores())
                return retorno;


            //PUNTERO DONDE VOY A GUARDAR EL VALOR
            _ID_VAR_FUNC nodoFunc = (_ID_VAR_FUNC)getNodo("ID_VAR_FUNC");
            itemEntorno destino = nodoFunc.getDestino(elementoEntor);
            

            itemValor valor = nodoFunc.getValor(elementoEntor);
            itemValor valor2 = new itemValor();
            valor2.setValue(1);

            resta sumatoria = new resta(new _E("hijo1", tablaSimbolos), new _E("hijo2", tablaSimbolos), tablaSimbolos, lstAtributos.getToken(0));
            itemValor resultado = sumatoria.opRestaExterna(elementoEntor, valor, valor2);


            asignarValor(destino, resultado); 
            return retorno;
        }



        //para obtener el destino en el for  
        public override itemEntorno getUltimaVar(elementoEntorno elementoEntor)
        {
            //PUNTERO DONDE VOY A GUARDAR EL VALOR
            _ID_VAR_FUNC nodoFunc = (_ID_VAR_FUNC)getNodo("ID_VAR_FUNC");
            itemEntorno destino = nodoFunc.getDestino(elementoEntor);
            return destino;
        }
    }
}
