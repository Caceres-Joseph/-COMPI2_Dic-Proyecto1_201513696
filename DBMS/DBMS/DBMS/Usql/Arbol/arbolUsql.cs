using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas;
using DBMS.Usql.Arbol.Nodos;
using DBMS.Usql.Arbol.Nodos.Dcl;
using DBMS.Usql.Arbol.Nodos.Dll;
using DBMS.Usql.Arbol.Nodos.Dml;
using DBMS.Usql.Arbol.Nodos.Dml.Actualizar;
using DBMS.Usql.Arbol.Nodos.Dml.Alterar;
using DBMS.Usql.Arbol.Nodos.Dml.Borrar;
using DBMS.Usql.Arbol.Nodos.Dml.Eliminar;
using DBMS.Usql.Arbol.Nodos.Dml.Insertar;
using DBMS.Usql.Arbol.Nodos.Dml.Seleccionar;
using DBMS.Usql.Arbol.Nodos.Dml.Usar;
using DBMS.Usql.Arbol.Nodos.Expresion.E;
using DBMS.Usql.Arbol.Nodos.Expresion.Id;
using DBMS.Usql.Arbol.Nodos.Inicio;
using DBMS.Usql.Arbol.Nodos.Listas.Atributo;
using DBMS.Usql.Arbol.Nodos.Listas.Parametro;
using DBMS.Usql.Arbol.Nodos.Listas.Valor;
using DBMS.Usql.Arbol.Nodos.Ssl;
using DBMS.Usql.Arbol.Nodos.Ssl.Asignar; 
using DBMS.Usql.Arbol.Nodos.Ssl.Contar;
using DBMS.Usql.Arbol.Nodos.Ssl.Declarar;
using DBMS.Usql.Arbol.Nodos.Ssl.Nativas;
using DBMS.Usql.Arbol.Nodos.Ssl.Restore;
using DBMS.Usql.Arbol.Nodos.Ssl.Sentencias;
using DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Mientras;
using DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Para;
using DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Selecciona;
using DBMS.Usql.Arbol.Nodos.Ssl.Sentencias.Si;
using DBMS.Usql.Arbol.Nodos.Ssl.Ssl_back;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol
{
    class arbolUsql
    {

        public String nombreArchivo;
        public arbolUsql(String archivo)
        {
            this.nombreArchivo = archivo;
        }

        public nodoModelo generar(nodoModelo raiz, ParseTreeNode AST, tablaSimbolos tabla)
        {
            crearArbol(raiz, AST, tabla);

            return raiz;
        }

        private void crearArbol(nodoModelo padre, ParseTreeNode nodoIrony, tablaSimbolos tabla)
        {

            nodoModelo hijoNodo = null;
            if (nodoIrony.ChildNodes.Count == 0)
            {
                if (nodoIrony.Token == null)
                {
                    //no terminal sin hijos
                    //Console.WriteLine("NoTerminal->" + nodoIrony.ToString());
                    // grafo += nodoIrony.GetHashCode() + "[label=\"" + nodoIrony.ToString() + "\"];\n";
                    hijoNodo = getNodo(nodoIrony.ToString(), tabla);
                    padre.insertar(hijoNodo);
                }
                else
                {
                    String terminal = escapar(nodoIrony.Token.Value.ToString());
                    String nombreTerminal = nodoIrony.Term.Name;
                    token tok = new token(terminal, nodoIrony.Token.Location.Line, nodoIrony.Token.Location.Column, nombreArchivo);

                    //Console.WriteLine("[generarArbol]crearArbol:"+nodoIrony.Term.ToString());
                    padre.lstAtributos.insertar(nombreTerminal, tok);

                    //Console.WriteLine("terminal->" + terminal);
                    //grafo += nodoIrony.GetHashCode() + "[label=\"" + terminal + "\"];\n";
                }
            }
            else
            {
                hijoNodo = getNodo(nodoIrony.ToString(), tabla);
                //Console.WriteLine("insertando| " + padre.nombre + "->" + hijoNodo.nombre);
                padre.insertar(hijoNodo);
                //grafo += nodoIrony.GetHashCode() + "[label=\"" + nodoIrony + "\"];\n";
            }


            foreach (ParseTreeNode hijo in nodoIrony.ChildNodes)
            {

                crearArbol(hijoNodo, hijo, tabla);

                //grafo += nodoIrony.GetHashCode() + "->" + hijo.GetHashCode() + ";\n";

            }

            return;
        }


        public nodoModelo getNodo(String nombreNoTerminal, tablaSimbolos tabla)
        {
            nodoModelo retorno = null;

            switch (nombreNoTerminal)
            {
                case "S":
                    retorno = new _S(nombreNoTerminal, tabla); 
                    break;

                case "GLOBAL":
                    retorno = new _GLOBAL(nombreNoTerminal, tabla); 
                    break;

                case "LST_CUERPO":
                    retorno = new _LST_CUERPO(nombreNoTerminal, tabla);
                    break;

                case "CUERPO":
                    retorno = new _CUERPO(nombreNoTerminal, tabla);
                    break;

                case "DDL2":
                    retorno = new _DDL2(nombreNoTerminal, tabla);
                    break;

                case "DDL":
                    retorno = new _DDL(nombreNoTerminal, tabla);
                    break;

                case "DDL_CREAR_BASE":
                    retorno = new _DDL_CREAR_BASE(nombreNoTerminal, tabla);
                    break;

                case "DDL_CREAR_TABLA":
                    retorno = new _DDL_CREAR_TABLA(nombreNoTerminal, tabla);
                    break;

                case "DDL_CREAR_OBJETO":
                    retorno = new _DDL_CREAR_OBJETO(nombreNoTerminal, tabla);
                    break;

                case "DDL_CREAR_USUARIO":
                    retorno = new _DDL_CREAR_USUARIO(nombreNoTerminal, tabla);
                    break;

                case "DDL_CREAR_PROC":
                    retorno = new _DDL_CREAR_PROC(nombreNoTerminal, tabla);
                    break;

                case "DDL_CREAR_FUNCION":
                    retorno = new _DDL_CREAR_FUNCION(nombreNoTerminal, tabla);
                    break;

                case "DDL_COMPLEMENTO":
                    retorno = new _DDL_COMPLEMENTO(nombreNoTerminal, tabla);
                    break;

                case "DDL_COMPLEMENTO_P":
                    retorno = new _DDL_COMPLEMENTO_P(nombreNoTerminal, tabla);
                    break;

                case "DDL_RETORNO":
                    retorno = new _DDL_RETORNO(nombreNoTerminal, tabla);
                    break;

                case "DDL_DETENER":
                    retorno = new _DDL_DETENER(nombreNoTerminal, tabla);
                    break;

                case "DML":
                    retorno = new _DML(nombreNoTerminal, tabla);
                    break;

                case "DML_USAR":
                    retorno = new _DML_USAR(nombreNoTerminal, tabla);
                    break;

                case "DML_ALTERAR":
                    retorno = new _DML_ALTERAR(nombreNoTerminal, tabla);
                    break;

                case "DML_ALT_TABLA_ADD":
                    retorno = new _DML_ALT_TABLA_ADD(nombreNoTerminal, tabla);
                    break;

                case "DML_ALT_TABLA_QUIT":
                    retorno = new _DML_ALT_TABLA_QUIT(nombreNoTerminal, tabla);
                    break;

                case "DML_ALT_OBJ_ADD":
                    retorno = new _DML_ALT_OBJ_ADD(nombreNoTerminal, tabla);
                    break;

                case "DML_ALT_OBJ_QUIT":
                    retorno = new _DML_ALT_OBJ_QUIT(nombreNoTerminal, tabla);
                    break;

                case "DML_ATL_US":
                    retorno = new _DML_ATL_US(nombreNoTerminal, tabla);
                    break;

                case "DML_ELIMINAR":
                    retorno = new _DML_ELIMINAR(nombreNoTerminal, tabla);
                    break;

                case "DML_DEL_TABLA":
                    retorno = new _DML_DEL_TABLA(nombreNoTerminal, tabla);
                    break;

                case "DML_DEL_BASE":
                    retorno = new _DML_DEL_BASE(nombreNoTerminal, tabla);
                    break;

                case "DML_DEL_OBJ":
                    retorno = new _DML_DEL_OBJ(nombreNoTerminal, tabla);
                    break;

                case "DML_DEL_US":
                    retorno = new _DML_DEL_US(nombreNoTerminal, tabla);
                    break;

                case "DML_INSERTAR":
                    retorno = new _DML_INSERTAR(nombreNoTerminal, tabla);
                    break;

                case "DML_INSERTAR_1":
                    retorno = new _DML_INSERTAR_1(nombreNoTerminal, tabla);
                    break;

                case "DML_INSERTAR_2":
                    retorno = new _DML_INSERTAR_2(nombreNoTerminal, tabla);
                    break;

                case "DML_ACTUALIZAR":
                    retorno = new _DML_ACTUALIZAR(nombreNoTerminal, tabla);
                    break;

                case "DML_ACTUALIZAR_1":
                    retorno = new _DML_ACTUALIZAR_1(nombreNoTerminal, tabla);
                    break;

                case "DML_ACTUALIZAR_2":
                    retorno = new _DML_ACTUALIZAR_2(nombreNoTerminal, tabla);
                    break;

                case "DML_BORRAR":
                    retorno = new _DML_BORRAR(nombreNoTerminal, tabla);
                    break;

                case "DML_BORRAR_1":
                    retorno = new _DML_BORRAR_1(nombreNoTerminal, tabla);
                    break;

                case "DML_BORRAR_2":
                    retorno = new _DML_BORRAR_2(nombreNoTerminal, tabla);
                    break;

                case "DML_SELECCIONAR":
                    retorno = new _DML_SELECCIONAR(nombreNoTerminal, tabla);
                    break;

                case "DML_SELECCIONAR_P":
                    retorno = new _DML_SELECCIONAR_P(nombreNoTerminal, tabla);
                    break;

                case "DML_SELECCIONAR_P1":
                    retorno = new _DML_SELECCIONAR_P1(nombreNoTerminal, tabla);
                    break;

                case "DML_SELECCIONAR_P3":
                    retorno = new _DML_SELECCIONAR_P3(nombreNoTerminal, tabla);
                    break;

                case "DML_SELECCIONAR_P2":
                    retorno = new _DML_SELECCIONAR_P2(nombreNoTerminal, tabla);
                    break;

                case "DML_SELECCIONAR_P4":
                    retorno = new _DML_SELECCIONAR_P4(nombreNoTerminal, tabla);
                    break;

                case "DML_ORDENAR":
                    retorno = new _DML_ORDENAR(nombreNoTerminal, tabla);
                    break;

                case "DCL":
                    retorno = new _DCL(nombreNoTerminal, tabla);
                    break;

                case "DCL_OTORGAR":
                    retorno = new _DCL_OTORGAR(nombreNoTerminal, tabla);
                    break;

                case "DCL_OTORGAR1":
                    retorno = new _DCL_OTORGAR1(nombreNoTerminal, tabla);
                    break;

                case "DCL_DENEGAR":
                    retorno = new _DCL_DENEGAR(nombreNoTerminal, tabla);
                    break;

                case "DCL_DENEGAR1":
                    retorno = new _DCL_DENEGAR1(nombreNoTerminal, tabla);
                    break;

                case "SSL":
                    retorno = new _SSL(nombreNoTerminal, tabla);
                    break;

                case "SSL_DECLARAR":
                    retorno = new _SSL_DECLARAR(nombreNoTerminal, tabla);
                    break;

                case "SSL_ASIGNAR":
                    retorno = new _SSL_ASIGNAR(nombreNoTerminal, tabla);
                    break;

                case "SSL_ASIGNAR_1":
                    retorno = new _SSL_ASIGNAR_1(nombreNoTerminal, tabla);
                    break;

                case "SSL_ASIGNAR_2":
                    retorno = new _SSL_ASIGNAR_2(nombreNoTerminal, tabla);
                    break;

                case "SSL_ASIGNAR_3":
                    retorno = new _SSL_ASIGNAR_3(nombreNoTerminal, tabla);
                    break;

                case "VAL":
                    retorno = new _VAL(nombreNoTerminal, tabla);
                    break;

                case "SSL_SENTENCIAS":
                    retorno = new _SSL_SENTENCIAS(nombreNoTerminal, tabla);
                    break;

                case "SSL_NATIVAS":
                    retorno = new _SSL_NATIVAS(nombreNoTerminal, tabla);
                    break;

                case "SSL_SI":
                    retorno = new _SSL_SI(nombreNoTerminal, tabla);
                    break;

                case "SSL_SI_1":
                    retorno = new _SSL_SI_1(nombreNoTerminal, tabla);
                    break;

                case "SSL_SI_2":
                    retorno = new _SSL_SI_2(nombreNoTerminal, tabla);
                    break;

                case "SSL_SINO":
                    retorno = new _SSL_SINO(nombreNoTerminal, tabla);
                    break;

                case "SSL_SELECCIONA":
                    retorno = new _SSL_SELECCIONA(nombreNoTerminal, tabla);
                    break;

                case "SSL_SELECCIONA_1":
                    retorno = new _SSL_SELECCIONA_1(nombreNoTerminal, tabla);
                    break;

                case "SSL_SELECCIONA_2":
                    retorno = new _SSL_SELECCIONA_2(nombreNoTerminal, tabla);
                    break;

                case "SSL_CASOS":
                    retorno = new _SSL_CASOS(nombreNoTerminal, tabla);
                    break;

                case "SSL_CASO":
                    retorno = new _SSL_CASO(nombreNoTerminal, tabla);
                    break;

                case "SSL_SEL_DEFECTO":
                    retorno = new _SSL_SEL_DEFECTO(nombreNoTerminal, tabla);
                    break;

                case "SSL_PARA":
                    retorno = new _SSL_PARA(nombreNoTerminal, tabla);
                    break;

                case "SSL_PARA_1":
                    retorno = new _SSL_PARA_1(nombreNoTerminal, tabla);
                    break;

                case "SSL_PARA_2":
                    retorno = new _SSL_PARA_2(nombreNoTerminal, tabla);
                    break;

                case "SSL_PARA_3":
                    retorno = new _SSL_PARA_3(nombreNoTerminal, tabla);
                    break;

                case "SSL_PARA_4":
                    retorno = new _SSL_PARA_4(nombreNoTerminal, tabla);
                    break;

                case "SSL_PARA_5":
                    retorno = new _SSL_PARA_5(nombreNoTerminal, tabla);
                    break;

                case "SSL_PARA_6":
                    retorno = new _SSL_PARA_6(nombreNoTerminal, tabla);
                    break;

                case "SSL_MIENTRAS":
                    retorno = new _SSL_MIENTRAS(nombreNoTerminal, tabla);
                    break;

                case "SSL_IMPRIMIR":
                    retorno = new _SSL_IMPRIMIR(nombreNoTerminal, tabla);
                    break;

                case "SSL_OPE_TIPO":
                    retorno = new _SSL_OPE_TIPO(nombreNoTerminal, tabla);
                    break;

                case "SSL_FECHA":
                    retorno = new _SSL_FECHA(nombreNoTerminal, tabla);
                    break;

                case "SSL_FECHA_HORA":
                    retorno = new _SSL_FECHA_HORA(nombreNoTerminal, tabla);
                    break;

                case "SSL_CONTAR":
                    retorno = new _SSL_CONTAR(nombreNoTerminal, tabla);
                    break;

                case "SSL_BACKUP":
                    retorno = new _SSL_BACKUP(nombreNoTerminal, tabla);
                    break;

                case "SSL_DUMP":
                    retorno = new _SSL_DUMP(nombreNoTerminal, tabla);
                    break;

                case "SSL_COMPLETO":
                    retorno = new _SSL_COMPLETO(nombreNoTerminal, tabla);
                    break;

                case "SSL_RESTAURAR_DUMP":
                    retorno = new _SSL_RESTAURAR_DUMP(nombreNoTerminal, tabla);
                    break;

                case "SSL_RESTAURAR_COMPLETO":
                    retorno = new _SSL_RESTAURAR_COMPLETO(nombreNoTerminal, tabla);
                    break;

                case "LST_PARAMETRO":
                    retorno = new _LST_PARAMETRO(nombreNoTerminal, tabla);
                    break;

                case "PARAMETRO":
                    retorno = new _PARAMETRO(nombreNoTerminal, tabla);
                    break;

                case "LST_VALOR":
                    retorno = new _LST_VALOR(nombreNoTerminal, tabla);
                    break;

                case "LST_VAL_ID":
                    retorno = new _LST_VAL_ID(nombreNoTerminal, tabla);
                    break;

                case "LST_VARS":
                    retorno = new _LST_VARS(nombreNoTerminal, tabla);
                    break;

                case "VARS":
                    retorno = new _VARS(nombreNoTerminal, tabla);
                    break;

                case "LST_ATRIBUTO":
                    retorno = new _LST_ATRIBUTO(nombreNoTerminal, tabla);
                    break;

                case "ATRIBUTO":
                    retorno = new _ATRIBUTO(nombreNoTerminal, tabla);
                    break;

                case "TIPO":
                    retorno = new _TIPO(nombreNoTerminal, tabla);
                    break;

                case "ID_VAR_FUNC":
                    retorno = new _ID_VAR_FUNC(nombreNoTerminal, tabla);
                    break;

                case "ID_VAR_FUNC_1":
                    retorno = new _ID_VAR_FUNC_1(nombreNoTerminal, tabla);
                    break;

                case "ID_VAR_FUNC_2":
                    retorno = new _ID_VAR_FUNC_2(nombreNoTerminal, tabla);
                    break;

                case "ID_VAR_FUNC_3":
                    retorno = new _ID_VAR_FUNC_3(nombreNoTerminal, tabla);
                    break;

                case "ID_VAR_FUNC_4":
                    retorno = new _ID_VAR_FUNC_4(nombreNoTerminal, tabla);
                    break;

                case "ID_VAR_FUNC_5":
                    retorno = new _ID_VAR_FUNC_5(nombreNoTerminal, tabla);
                    break;

                case "LST_PUNTOS":
                    retorno = new _LST_PUNTOS(nombreNoTerminal, tabla);
                    break;

                case "VALOR":
                    retorno = new _VALOR(nombreNoTerminal, tabla);
                    break;

                case "E":
                    retorno = new _E(nombreNoTerminal, tabla);
                    break;

                case "DDL_RETORNO1":
                    retorno = new _DDL_RETORNO1(nombreNoTerminal, tabla);
                    break;
                      
                default:
                    retorno = new nodoModelo("Desc_" + nombreNoTerminal, tabla);
                    Console.WriteLine("[generarArbol]No se encontró el nodo:" + nombreNoTerminal);
                    break;
            }

            return retorno;
        }


        private static String escapar(String cadena)
        {
            cadena = cadena.Replace("\\", "\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            return cadena;
        }
    }
}
