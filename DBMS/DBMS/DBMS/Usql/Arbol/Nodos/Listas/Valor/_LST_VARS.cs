using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Usql.Arbol.Nodos.Listas.Valor
{
    /*
     * LST_VARS.Rule = MakePlusRule(LST_VARS, sComa, VARS);
     */
    class _LST_VARS : nodoModelo
    {
        public _LST_VARS(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        //retornando una lista de tokens 
        public List<token> getLstId()
        {
            List<token> retorno = new List<token>();

            foreach(_VARS varId in hijos)
            {
                retorno.Add(varId.getId());
            }
            return retorno; 
        }
    }
}
