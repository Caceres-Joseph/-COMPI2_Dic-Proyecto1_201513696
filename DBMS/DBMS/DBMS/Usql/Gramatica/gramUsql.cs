using DBMS.Usql.Arbol.Elementos.Tablas;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Gramatica
{
    class gramUsql : Grammar
    {

        tablaErrores tablaErrores;
        public String nombreArchivo;
        public gramUsql(tablaErrores tabla, String archivo) : base(caseSensitive: false)//Diferencia entre mayusculas y minusculas
        {

            this.tablaErrores = tabla;
            this.nombreArchivo = archivo;

            #region ER



            /*
             +-----------------------------
             | Fechas
             +----------------------------
             */
            RegexBasedTerminal valTime = new RegexBasedTerminal("valTime", "[0-9][0-9]:[0-9][0-9]:[0-9][0-9]");

            RegexBasedTerminal valDate = new RegexBasedTerminal("valDate", "[0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]");


            /*
             +-----------------------------
             | Cometarios
             +----------------------------
             */

            CommentTerminal comentariobloque = new CommentTerminal("comentariobloque", "#*", "*#");
            CommentTerminal comentariolinea = new CommentTerminal("comentariolinea", "#", "\n", "\r\n");



            /*Se ignoran los terminales solo se reconoce*/
            NonGrammarTerminals.Add(comentariobloque);
            NonGrammarTerminals.Add(comentariolinea);

            /*
             +-----------------------------
             | Valores
             +----------------------------
             */
            RegexBasedTerminal valBoolean = new RegexBasedTerminal("valBoolean", "(false|true|verdadero|falso)");

            //StringLiteral valCaracter = new StringLiteral("valCaracter", "\'");
            StringLiteral valCadena = new StringLiteral("valCadena", "\'");
            StringLiteral valCadena2 = new StringLiteral("valCadena", "\"");



            /*
             +-----------------------------
             | Numeros
             +----------------------------
             */
            NumberLiteral valNumero = new NumberLiteral("valNumero");
            var valDecimal = new RegexBasedTerminal("valDecimal", "[0-9]+\\.[0-9]+");

            IdentifierTerminal valId = new IdentifierTerminal("valId");

            #endregion

            #region Terminales


            /*
             +-----------------------------
             | Simbolos
             +----------------------------
             */

            var sDobleMenor = ToTerm("<<");
            var sDobleMayor = ToTerm(">>");

            var sMas = ToTerm("+");
            var sMenos = ToTerm("-");
            var sPor = ToTerm("*");
            var sDiv = ToTerm("/");
            var sPot = ToTerm("^");
            var sMod = ToTerm("%");

            var sIgualacion = ToTerm("==");
            var sDiferenciacion = ToTerm("!=");
            var sMenorQue = ToTerm("<");
            var sMayorQue = ToTerm(">");
            var sMenorIgualQue = ToTerm("<=");
            var sMayorIgualQue = ToTerm(">=");
            var sAnd = ToTerm("&&");
            var sOr = ToTerm("||");
            var sNot = ToTerm("!");



            var sAbreParent = ToTerm("(");
            var sCierraParent = ToTerm(")");

            var sAbreLlave = ToTerm("{");
            var sCierraLlave = ToTerm("}");

            var sAbreCorchete = ToTerm("[");
            var sCierraCorchete = ToTerm("]");
            var sPunto = ToTerm(".");
            var sComa = ToTerm(",");
            var sPuntoComa = ToTerm(";");
            var sArroba = ToTerm("@");
            var sIgual = ToTerm("=");

            var sCierraInterrogante = ToTerm("?");
            var sDosPuntos = ToTerm(":");


            /*
             +-----------------------------
             | Palabras reservadas
             +----------------------------
             */

            var tCrear = ToTerm("crear");
            var tBase_datos = ToTerm("base_datos");
            var tTabla = ToTerm("tabla");
            var tObjeto = ToTerm("objeto");
            var tProcedimiento = ToTerm("procedimiento");
            var tFuncion = ToTerm("funcion");
            var tUsuario = ToTerm("usuario");
            var tColocar = ToTerm("colocar");
            var tPassword = ToTerm("password");

            var tText = ToTerm("text");
            var tInteger = ToTerm("integer");
            var tDouble = ToTerm("double");
            var tBool = ToTerm("bool");
            var tDate = ToTerm("date");
            var tDatetime = ToTerm("datetime");


            var tNulo = ToTerm("nulo");
            var tNo = ToTerm("no");
            var tAutoincrementable = ToTerm("autoincrementable");
            var tLlave_primaria = ToTerm("llave_primaria");
            var tLlave_foranea = ToTerm("llave_foranea");
            var tUnico = ToTerm("unico");

            var tRestaurar = ToTerm("restaurar");
            var tCompleto = ToTerm("completo");
            var tBackup = ToTerm("backup");
            var tUsqldump = ToTerm("usqldump");
            var tFecha = ToTerm("fecha");
            var tFecha_hora = ToTerm("fecha_hora");
            var tImprimir = ToTerm("imprimir");
            var tMientras = ToTerm("mientras");
            var tPara = ToTerm("para");
            var tDefecto = ToTerm("defecto");
            var tCaso = ToTerm("caso");
            var tSino = ToTerm("sino");
            var tSi = ToTerm("si");
            var tDeclarar = ToTerm("declarar");
            var tSelecciona = ToTerm("selecciona");
            var tRetorno = ToTerm("retorno");
            var tDetener = ToTerm("detener");


            var tUsar = ToTerm("usar");
            var tAlterar = ToTerm("alterar");
            var tAgregar = ToTerm("agregar");
            var tQuitar = ToTerm("quitar");
            var tCambiar = ToTerm("cambiar");
            var tEliminar = ToTerm("eliminar");
            var tInsertar = ToTerm("insertar");
            var tEn = ToTerm("en");
            var tValores = ToTerm("valores");
            var tDonde = ToTerm("donde");
            var tActualizar = ToTerm("actualizar");
            var tBorrar = ToTerm("borrar");
            var tSeleccionar = ToTerm("seleccionar");
            var tDe = ToTerm("de");
            var tAsc = ToTerm("asc");
            var tDesc = ToTerm("desc");


            var tOrdenar = ToTerm("ordenar");
            var tPor = ToTerm("por");


            var tOtorgar = ToTerm("otorgar");
            var tPermisos = ToTerm("permisos");
            var tDenegar = ToTerm("denegar");
            var tContar = ToTerm("contar");
            #endregion
            #region NoTerminales


            NonTerminal S = new NonTerminal("S");

            NonTerminal GLOBAL = new NonTerminal("GLOBAL");
            NonTerminal LST_CUERPO = new NonTerminal("LST_CUERPO");
            NonTerminal CUERPO = new NonTerminal("CUERPO");
            NonTerminal DDL2 = new NonTerminal("DDL2");
            NonTerminal DDL = new NonTerminal("DDL");
            NonTerminal DDL_CREAR_BASE = new NonTerminal("DDL_CREAR_BASE");
            NonTerminal DDL_CREAR_TABLA = new NonTerminal("DDL_CREAR_TABLA");
            NonTerminal DDL_CREAR_OBJETO = new NonTerminal("DDL_CREAR_OBJETO");
            NonTerminal DDL_CREAR_USUARIO = new NonTerminal("DDL_CREAR_USUARIO");
            NonTerminal DDL_CREAR_PROC = new NonTerminal("DDL_CREAR_PROC");
            NonTerminal DDL_CREAR_FUNCION = new NonTerminal("DDL_CREAR_FUNCION");
            NonTerminal DDL_COMPLEMENTO = new NonTerminal("DDL_COMPLEMENTO");
            NonTerminal DDL_COMPLEMENTO_P = new NonTerminal("DDL_COMPLEMENTO_P");
            NonTerminal DDL_RETORNO = new NonTerminal("DDL_RETORNO");
            NonTerminal DDL_DETENER = new NonTerminal("DDL_DETENER");
            NonTerminal DML = new NonTerminal("DML");
            NonTerminal DML_USAR = new NonTerminal("DML_USAR");
            NonTerminal DML_ALTERAR = new NonTerminal("DML_ALTERAR");
            NonTerminal DML_ALT_TABLA_ADD = new NonTerminal("DML_ALT_TABLA_ADD");
            NonTerminal DML_ALT_TABLA_QUIT = new NonTerminal("DML_ALT_TABLA_QUIT");
            NonTerminal DML_ALT_OBJ_ADD = new NonTerminal("DML_ALT_OBJ_ADD");
            NonTerminal DML_ALT_OBJ_QUIT = new NonTerminal("DML_ALT_OBJ_QUIT");
            NonTerminal DML_ATL_US = new NonTerminal("DML_ATL_US");
            NonTerminal DML_ELIMINAR = new NonTerminal("DML_ELIMINAR");
            NonTerminal DML_DEL_TABLA = new NonTerminal("DML_DEL_TABLA");
            NonTerminal DML_DEL_BASE = new NonTerminal("DML_DEL_BASE");
            NonTerminal DML_DEL_OBJ = new NonTerminal("DML_DEL_OBJ");
            NonTerminal DML_DEL_US = new NonTerminal("DML_DEL_US");
            NonTerminal DML_INSERTAR = new NonTerminal("DML_INSERTAR");
            NonTerminal DML_INSERTAR_1 = new NonTerminal("DML_INSERTAR_1");
            NonTerminal DML_INSERTAR_2 = new NonTerminal("DML_INSERTAR_2");
            NonTerminal DML_ACTUALIZAR = new NonTerminal("DML_ACTUALIZAR");
            NonTerminal DML_ACTUALIZAR_1 = new NonTerminal("DML_ACTUALIZAR_1");
            NonTerminal DML_ACTUALIZAR_2 = new NonTerminal("DML_ACTUALIZAR_2");
            NonTerminal DML_BORRAR = new NonTerminal("DML_BORRAR");
            NonTerminal DML_BORRAR_1 = new NonTerminal("DML_BORRAR_1");
            NonTerminal DML_BORRAR_2 = new NonTerminal("DML_BORRAR_2");
            NonTerminal DML_SELECCIONAR = new NonTerminal("DML_SELECCIONAR");
            NonTerminal DML_SELECCIONAR_P = new NonTerminal("DML_SELECCIONAR_P");
            NonTerminal DML_SELECCIONAR_P1 = new NonTerminal("DML_SELECCIONAR_P1");
            NonTerminal DML_SELECCIONAR_P3 = new NonTerminal("DML_SELECCIONAR_P3");
            NonTerminal DML_SELECCIONAR_P2 = new NonTerminal("DML_SELECCIONAR_P2");
            NonTerminal DML_SELECCIONAR_P4 = new NonTerminal("DML_SELECCIONAR_P4");
            NonTerminal DML_ORDENAR = new NonTerminal("DML_ORDENAR");
            NonTerminal DCL = new NonTerminal("DCL");
            NonTerminal DCL_OTORGAR = new NonTerminal("DCL_OTORGAR");
            NonTerminal DCL_OTORGAR1 = new NonTerminal("DCL_OTORGAR1");
            NonTerminal DCL_DENEGAR = new NonTerminal("DCL_DENEGAR");
            NonTerminal DCL_DENEGAR1 = new NonTerminal("DCL_DENEGAR1");
            NonTerminal SSL = new NonTerminal("SSL");
            NonTerminal SSL_DECLARAR = new NonTerminal("SSL_DECLARAR");
            NonTerminal SSL_ASIGNAR = new NonTerminal("SSL_ASIGNAR");
            NonTerminal SSL_ASIGNAR_1 = new NonTerminal("SSL_ASIGNAR_1");
            NonTerminal SSL_ASIGNAR_2 = new NonTerminal("SSL_ASIGNAR_2");
            NonTerminal SSL_ASIGNAR_3 = new NonTerminal("SSL_ASIGNAR_3");
            NonTerminal VAL = new NonTerminal("VAL");
            NonTerminal SSL_SENTENCIAS = new NonTerminal("SSL_SENTENCIAS");
            NonTerminal SSL_NATIVAS = new NonTerminal("SSL_NATIVAS");
            NonTerminal SSL_SI = new NonTerminal("SSL_SI");
            NonTerminal SSL_SI_1 = new NonTerminal("SSL_SI_1");
            NonTerminal SSL_SI_2 = new NonTerminal("SSL_SI_2");
            NonTerminal SSL_SINO = new NonTerminal("SSL_SINO");
            NonTerminal SSL_SELECCIONA = new NonTerminal("SSL_SELECCIONA");
            NonTerminal SSL_SELECCIONA_1 = new NonTerminal("SSL_SELECCIONA_1");
            NonTerminal SSL_SELECCIONA_2 = new NonTerminal("SSL_SELECCIONA_2");
            NonTerminal SSL_CASOS = new NonTerminal("SSL_CASOS");
            NonTerminal SSL_CASO = new NonTerminal("SSL_CASO");
            NonTerminal SSL_SEL_DEFECTO = new NonTerminal("SSL_SEL_DEFECTO");
            NonTerminal SSL_PARA = new NonTerminal("SSL_PARA");
            NonTerminal SSL_PARA_1 = new NonTerminal("SSL_PARA_1");
            NonTerminal SSL_PARA_2 = new NonTerminal("SSL_PARA_2");
            NonTerminal SSL_PARA_3 = new NonTerminal("SSL_PARA_3");
            NonTerminal SSL_PARA_4 = new NonTerminal("SSL_PARA_4");
            NonTerminal SSL_PARA_5 = new NonTerminal("SSL_PARA_5");
            NonTerminal SSL_PARA_6 = new NonTerminal("SSL_PARA_6");
            NonTerminal SSL_MIENTRAS = new NonTerminal("SSL_MIENTRAS");
            NonTerminal SSL_IMPRIMIR = new NonTerminal("SSL_IMPRIMIR");
            NonTerminal SSL_OPE_TIPO = new NonTerminal("SSL_OPE_TIPO");
            NonTerminal SSL_FECHA = new NonTerminal("SSL_FECHA");
            NonTerminal SSL_FECHA_HORA = new NonTerminal("SSL_FECHA_HORA");
            NonTerminal SSL_CONTAR = new NonTerminal("SSL_CONTAR");
            NonTerminal SSL_BACKUP = new NonTerminal("SSL_BACKUP");
            NonTerminal SSL_DUMP = new NonTerminal("SSL_DUMP");
            NonTerminal SSL_COMPLETO = new NonTerminal("SSL_COMPLETO");
            NonTerminal SSL_RESTAURAR_DUMP = new NonTerminal("SSL_RESTAURAR_DUMP");
            NonTerminal SSL_RESTAURAR_COMPLETO = new NonTerminal("SSL_RESTAURAR_COMPLETO");
            NonTerminal LST_PARAMETRO = new NonTerminal("LST_PARAMETRO");
            NonTerminal PARAMETRO = new NonTerminal("PARAMETRO");
            NonTerminal LST_VALOR = new NonTerminal("LST_VALOR");
            NonTerminal LST_VAL_ID = new NonTerminal("LST_VAL_ID");
            NonTerminal LST_VARS = new NonTerminal("LST_VARS");
            NonTerminal VARS = new NonTerminal("VARS");
            NonTerminal LST_ATRIBUTO = new NonTerminal("LST_ATRIBUTO");
            NonTerminal ATRIBUTO = new NonTerminal("ATRIBUTO");
            NonTerminal TIPO = new NonTerminal("TIPO");
            NonTerminal ID_VAR_FUNC = new NonTerminal("ID_VAR_FUNC");
            NonTerminal ID_VAR_FUNC_1 = new NonTerminal("ID_VAR_FUNC_1");
            NonTerminal ID_VAR_FUNC_2 = new NonTerminal("ID_VAR_FUNC_2");
            NonTerminal ID_VAR_FUNC_3 = new NonTerminal("ID_VAR_FUNC_3");
            NonTerminal ID_VAR_FUNC_4 = new NonTerminal("ID_VAR_FUNC_4");
            NonTerminal ID_VAR_FUNC_5 = new NonTerminal("ID_VAR_FUNC_5");
            NonTerminal LST_PUNTOS = new NonTerminal("LST_PUNTOS");
            NonTerminal VALOR = new NonTerminal("VALOR");
            NonTerminal E = new NonTerminal("E");
            NonTerminal E_NEGATIVO = new NonTerminal("E_NEGATIVO");
            NonTerminal E_POT = new NonTerminal("E_POT");
            NonTerminal E_DIV = new NonTerminal("E_DIV");
            NonTerminal E_POR = new NonTerminal("E_POR");
            NonTerminal E_MAS = new NonTerminal("E_MAS");
            NonTerminal E_MENOS = new NonTerminal("E_MENOS");
            NonTerminal E_IGUALACION = new NonTerminal("E_IGUALACION");
            NonTerminal E_DIFEREN = new NonTerminal("E_DIFEREN");
            NonTerminal E_MENOR_QUE = new NonTerminal("E_MENOR_QUE");
            NonTerminal E_MENOR_IGUAL = new NonTerminal("E_MENOR_IGUAL");
            NonTerminal E_MAYOR_QUE = new NonTerminal("E_MAYOR_QUE");
            NonTerminal E_MAYOR_IGUAL = new NonTerminal("E_MAYOR_IGUAL");
            NonTerminal E_AND = new NonTerminal("E_AND");
            NonTerminal E_OR = new NonTerminal("E_OR");
            NonTerminal E_NOT = new NonTerminal("E_NOT");
            NonTerminal E_PARENT = new NonTerminal("E_PARENT");
            NonTerminal E_ID = new NonTerminal("E_ID");
            NonTerminal E_BOOL = new NonTerminal("E_BOOL");
            NonTerminal E_CAD = new NonTerminal("E_CAD");
            NonTerminal E_CAD1 = new NonTerminal("E_CAD1");
            NonTerminal E_DEC = new NonTerminal("E_DEC");
            NonTerminal E_NUM = new NonTerminal("E_NUM");
            NonTerminal E_SSL = new NonTerminal("E_SSL");
            NonTerminal E_CONT = new NonTerminal("E_CONT");
            NonTerminal DDL_RETORNO1 = new NonTerminal("DDL_RETORNO1");

            #endregion

            #region Gramatica 

            /*
            |-------------------------------------------------------------------------------------------------------------------
            | INICIO
            |-------------------------------------------------------------------------------------------------------------------
            |  
            */
            S.Rule = LST_CUERPO;



            LST_CUERPO.Rule = MakeStarRule(LST_CUERPO, CUERPO);

            CUERPO.Rule = DDL + sPuntoComa
                | DCL + sPuntoComa
                | ID_VAR_FUNC + sPuntoComa
                | DML + sPuntoComa
                | SSL
                | DDL_RETORNO + sPuntoComa
                | DDL_RETORNO1 + sPuntoComa
                | DDL_DETENER + sPuntoComa
                | DDL2
                | SSL_CONTAR + sPuntoComa
                ;


            /*
            |-------------------------------------------------------------------------------------------------------------------
            | DDL
            |-------------------------------------------------------------------------------------------------------------------
            |  
            */

            DDL2.Rule = DDL_CREAR_FUNCION
                | DDL_CREAR_PROC
                ;

            DDL.Rule = DDL_CREAR_BASE
                | DDL_CREAR_TABLA
                | DDL_CREAR_OBJETO
                | DDL_CREAR_OBJETO
                | DDL_CREAR_USUARIO
                ;

            DDL_CREAR_BASE.Rule = tCrear + tBase_datos + valId;

            DDL_CREAR_TABLA.Rule = tCrear + tTabla + valId + sAbreParent + LST_ATRIBUTO + sCierraParent
                ;

            DDL_CREAR_OBJETO.Rule = tCrear + tObjeto + valId + sAbreParent + LST_ATRIBUTO + sCierraParent
                ;

            DDL_CREAR_USUARIO.Rule = tCrear + tUsuario + valId + tColocar + tPassword + sIgual + VALOR;

            DDL_CREAR_PROC.Rule = tCrear + tProcedimiento + valId + sAbreParent + LST_PARAMETRO + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;

            DDL_CREAR_FUNCION.Rule = tCrear + tFuncion + valId + sAbreParent + LST_PARAMETRO + sCierraParent + TIPO + sAbreLlave + LST_CUERPO + sCierraLlave;

            DDL_RETORNO.Rule = tRetorno + VALOR;
            DDL_RETORNO1.Rule = tRetorno;
            DDL_DETENER.Rule = tDetener;



            /*
            +-----------------------------
            | DCL
            +-----------------------------
            */
            DCL.Rule = DCL_OTORGAR
                    | DCL_OTORGAR1
                    | DCL_DENEGAR
                    | DCL_DENEGAR1;


            //  ''' OTORGAR '''


            DCL_OTORGAR.Rule = tOtorgar + tPermisos + valId + sComa + valId + sPunto + valId;

            DCL_OTORGAR1.Rule = tOtorgar + tPermisos + valId + sComa + valId + sPunto + sPor;


            DCL_DENEGAR.Rule = tDenegar + tPermisos + valId + sComa + valId + sPunto + valId;

            DCL_DENEGAR1.Rule = tDenegar + tPermisos + valId + sComa + valId + sPunto + sPor;




            /*
            +-----------------------------
            | DML
            +-----------------------------
            */
            DML.Rule = DML_USAR
                        | DML_ALTERAR
                        | DML_ELIMINAR
                        | DML_INSERTAR
                        | DML_ACTUALIZAR
                        | DML_BORRAR
                        | DML_SELECCIONAR
                        ;


            //  ''' USAR '''

            DML_USAR.Rule = tUsar + valId;



            //  ''' ALTERAR '''
            DML_ALTERAR.Rule = DML_ALT_TABLA_ADD
                                    | DML_ALT_TABLA_QUIT
                                    | DML_ALT_OBJ_ADD
                                    | DML_ALT_OBJ_QUIT
                                    | DML_ATL_US
                                    ;

            DML_ALT_TABLA_ADD.Rule = tAlterar + tTabla + valId + tAgregar + sAbreParent + LST_ATRIBUTO + sCierraParent;



            DML_ALT_TABLA_QUIT.Rule = tAlterar + tTabla + LST_VAL_ID + tQuitar + LST_VALOR;

            DML_ALT_OBJ_ADD.Rule = tAlterar + tObjeto + valId + tAgregar + sAbreParent + LST_ATRIBUTO + sCierraParent;


            //#DML_ALT_OBJ_QUIT 		.Rule = tAlterar objeto valId quitar LST_VALOR
            DML_ALT_OBJ_QUIT.Rule = tAlterar + tObjeto + valId + tQuitar + LST_VAL_ID;


            DML_ATL_US.Rule = tAlterar + tUsuario + valId + tCambiar + tPassword + sIgual + VALOR;



            //  ''' ELIMINAR '''
            DML_ELIMINAR.Rule = DML_DEL_TABLA
                                    | DML_DEL_BASE
                                    | DML_DEL_OBJ
                                    | DML_DEL_US
                                    ;

            DML_DEL_TABLA.Rule = tEliminar + tTabla + valId;


            DML_DEL_BASE.Rule = tEliminar + tBase_datos + valId;


            DML_DEL_OBJ.Rule = tEliminar + tObjeto + valId;


            DML_DEL_US.Rule = tEliminar + tUsuario + valId;


            //  ''' INSERTAR '''
            DML_INSERTAR.Rule = DML_INSERTAR_2
                | DML_INSERTAR_1
                                    ;

            DML_INSERTAR_1.Rule = tInsertar + tEn + tTabla + valId + sAbreParent + LST_VALOR + sCierraParent;

            DML_INSERTAR_2.Rule = tInsertar + tEn + tTabla + valId + sAbreParent + LST_VAL_ID + sCierraParent + tValores + sAbreParent + LST_VALOR + sCierraParent;


            //  ''' ACTUALIZAR '''
            DML_ACTUALIZAR.Rule = DML_ACTUALIZAR_1
                                     | DML_ACTUALIZAR_2
                                     ;


            DML_ACTUALIZAR_1.Rule = tActualizar + tTabla + LST_VAL_ID + sAbreParent + LST_VALOR + sCierraParent + tValores + sAbreParent + LST_VALOR + sCierraParent;

            DML_ACTUALIZAR_2.Rule = tActualizar + tTabla + LST_VAL_ID + sAbreParent + LST_VALOR + sCierraParent + tValores + sAbreParent + LST_VALOR + sCierraParent + tDonde + VALOR;


            //  ''' BORRAR '''
            DML_BORRAR.Rule = DML_BORRAR_1
                                    | DML_BORRAR_2
                                    ;

            DML_BORRAR_1.Rule = tBorrar + tEn + tTabla + LST_VAL_ID + tDonde + VALOR;


            DML_BORRAR_2.Rule = tBorrar + tEn + tTabla + valId;


            //  ''' SELECCIONAR '''
            DML_SELECCIONAR.Rule = DML_SELECCIONAR_P
                                    | DML_SELECCIONAR_P + DML_ORDENAR
                                    ;

            DML_SELECCIONAR_P.Rule = DML_SELECCIONAR_P1
                                     | DML_SELECCIONAR_P2
                                     | DML_SELECCIONAR_P3
                                     | DML_SELECCIONAR_P4
                                     ;

            DML_SELECCIONAR_P1.Rule = tSeleccionar + LST_VALOR + tDe + LST_VAL_ID + tDonde + VALOR;
            DML_SELECCIONAR_P3.Rule = tSeleccionar + LST_VALOR + tDe + LST_VAL_ID;
            DML_SELECCIONAR_P2.Rule = tSeleccionar + sPor + tDe + LST_VAL_ID + tDonde + VALOR;
            DML_SELECCIONAR_P4.Rule = tSeleccionar + sPor + tDe + LST_VAL_ID;



            DML_ORDENAR.Rule = tOrdenar + tPor + VALOR + tAsc
                                    | tOrdenar + tPor + VALOR + tDesc
                                    | tOrdenar + tPor + VALOR
                                    ;

            /*
            +-----------------------------
            | SSL
            +-----------------------------
            */


            SSL.Rule = SSL_DECLARAR + sPuntoComa
                    | SSL_ASIGNAR + sPuntoComa
                    | SSL_SENTENCIAS
                    | SSL_NATIVAS + sPuntoComa
                    | SSL_BACKUP + sPuntoComa
                    // | SSL_CONTAR + sPuntoComa

                    ;


            //''' DECLARAR '''
            SSL_DECLARAR.Rule = tDeclarar + LST_VARS + TIPO + VAL
                    | tDeclarar + LST_VARS + TIPO
                ;


            //  ''' ASIGNAR '''
            SSL_ASIGNAR.Rule = SSL_ASIGNAR_1
                    | SSL_ASIGNAR_2
                    | SSL_ASIGNAR_3
                    ;


            SSL_ASIGNAR_1.Rule = ID_VAR_FUNC + VAL;
            SSL_ASIGNAR_2.Rule = ID_VAR_FUNC + sMas + sMas;
            SSL_ASIGNAR_3.Rule = ID_VAR_FUNC + sMenos + sMenos;


            VAL.Rule = sIgual + VALOR;



            SSL_SENTENCIAS.Rule = SSL_SI
                    | SSL_SELECCIONA
                    | SSL_PARA
                    | SSL_MIENTRAS
                    ;



            SSL_NATIVAS.Rule = SSL_IMPRIMIR;



            //  ''' SI '''

            SSL_SI.Rule = SSL_SI_1
                        | SSL_SI_2;

            SSL_SI_1.Rule = tSi + sAbreParent + VALOR + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;

            SSL_SI_2.Rule = tSi + sAbreParent + VALOR + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave + SSL_SINO;





            SSL_SINO.Rule = tSino + sAbreLlave + LST_CUERPO + sCierraLlave;

            //''' SELECCIONA '''


            SSL_SELECCIONA.Rule = SSL_SELECCIONA_1
                    | SSL_SELECCIONA_2
                    ;


            SSL_SELECCIONA_1.Rule = tSelecciona + sAbreParent + VALOR + sCierraParent + sAbreLlave + SSL_CASOS + sCierraLlave;
            SSL_SELECCIONA_2.Rule = tSelecciona + sAbreParent + VALOR + sCierraParent + sAbreLlave + SSL_CASOS + SSL_SEL_DEFECTO + sCierraLlave;


            SSL_CASOS.Rule = MakePlusRule(SSL_CASOS, SSL_CASO);

            SSL_CASO.Rule = tCaso + VALOR + sDosPuntos + LST_CUERPO;


            SSL_SEL_DEFECTO.Rule = tDefecto + sDosPuntos + LST_CUERPO;



            //  ''' PARA '''
            SSL_PARA.Rule = SSL_PARA_1
                                | SSL_PARA_2
                                | SSL_PARA_3
                                | SSL_PARA_4
                                | SSL_PARA_5
                                | SSL_PARA_6;

            SSL_PARA_1.Rule = tPara + sAbreParent + SSL_DECLARAR + sPuntoComa + VALOR + sPuntoComa + SSL_ASIGNAR + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;
            SSL_PARA_2.Rule = tPara + sAbreParent + SSL_DECLARAR + sPuntoComa + VALOR + sPuntoComa + sMenos + sMenos + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;
            SSL_PARA_3.Rule = tPara + sAbreParent + SSL_DECLARAR + sPuntoComa + VALOR + sPuntoComa + sMas + sMas + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;
            SSL_PARA_4.Rule = tPara + sAbreParent + SSL_ASIGNAR + sPuntoComa + VALOR + sPuntoComa + SSL_ASIGNAR + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;
            SSL_PARA_5.Rule = tPara + sAbreParent + SSL_ASIGNAR + sPuntoComa + VALOR + sPuntoComa + sMenos + sMenos + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;
            SSL_PARA_6.Rule = tPara + sAbreParent + SSL_ASIGNAR + sPuntoComa + VALOR + sPuntoComa + sMas + sMas + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;


            //''' MIENTRAS '''
            SSL_MIENTRAS.Rule = tMientras + sAbreParent + VALOR + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;

            ///''' IMPRIMIR  '''


            SSL_IMPRIMIR.Rule = tImprimir + sAbreParent + VALOR + sCierraParent;



            ///''' OPE_TIPO  '''
            SSL_OPE_TIPO.Rule = SSL_FECHA
                                | SSL_FECHA_HORA
                                ;



            SSL_FECHA.Rule = tFecha + sAbreParent + sCierraParent;
            SSL_FECHA_HORA.Rule = tFecha_hora + sAbreParent + sCierraParent;


            //  ''' CONTAR  '''
            SSL_CONTAR.Rule = tContar + sAbreParent + sDobleMenor + DML_SELECCIONAR + sDobleMayor + sCierraParent;

            //  ''' BACKUP  '''
            SSL_BACKUP.Rule = SSL_DUMP
                                | SSL_COMPLETO
                                | SSL_RESTAURAR_DUMP
                                | SSL_RESTAURAR_COMPLETO
                                ;


            SSL_DUMP.Rule = tBackup + tUsqldump + valId + valId;

            SSL_COMPLETO.Rule = tBackup + tCompleto + valId + valId;


            SSL_RESTAURAR_DUMP.Rule = tRestaurar + tUsqldump + VALOR;


            SSL_RESTAURAR_COMPLETO.Rule = tRestaurar + tCompleto + VALOR;




            /*
            +-----------------------------
            | LISTAS
            +-----------------------------
            */


            LST_PARAMETRO.Rule = MakeStarRule(LST_PARAMETRO, sComa, PARAMETRO);

            PARAMETRO.Rule = TIPO + sArroba + valId;

            LST_VALOR.Rule = MakePlusRule(LST_VALOR, sComa, VALOR);

            LST_VAL_ID.Rule = MakePlusRule(LST_VAL_ID, sComa, valId);

            LST_VARS.Rule = MakePlusRule(LST_VARS, sComa, VARS);

            VARS.Rule = sArroba + valId;

            LST_ATRIBUTO.Rule = MakePlusRule(LST_ATRIBUTO, sComa, ATRIBUTO);



            ATRIBUTO.Rule = TIPO + valId
                    | TIPO + valId + DDL_COMPLEMENTO
                    ;

            DDL_COMPLEMENTO.Rule = MakePlusRule(DDL_COMPLEMENTO, DDL_COMPLEMENTO_P);

            DDL_COMPLEMENTO_P.Rule = tNulo
                       | tNo + tNulo
                       | tAutoincrementable
                       | tLlave_primaria
                       | tLlave_foranea + valId+ valId
                       | tUnico
                       ;
            /*
            +-----------------------------
            | TIPOS
            +-----------------------------
            */


            TIPO.Rule = tText
                        | tInteger
                        | tDouble
                        | tBool
                        | tDate
                        | tDatetime
                        | valId;


            /*
            +-----------------------------
            | ID VAR 
            +-----------------------------
            */


            ID_VAR_FUNC.Rule = ID_VAR_FUNC_1
                            | ID_VAR_FUNC_2
                            | ID_VAR_FUNC_3
                            | ID_VAR_FUNC_4
                            | ID_VAR_FUNC_5
                            ;


            ID_VAR_FUNC_1.Rule = ID_VAR_FUNC + LST_PUNTOS;
            ID_VAR_FUNC_2.Rule = sArroba + valId;
            ID_VAR_FUNC_3.Rule = valId;
            ID_VAR_FUNC_4.Rule = valId + sAbreParent + sCierraParent;
            ID_VAR_FUNC_5.Rule = valId + sAbreParent + LST_VALOR + sCierraParent;

            LST_PUNTOS.Rule = sPunto + valId;

            /*
            +-----------------------------
            | VALOR
            +-----------------------------
            */

            VALOR.Rule =
                //valBoolean
                E
                ;

            E.Rule = sMenos + E

                //Aritemeticas
                | E + sPot + E
                | E + sDiv + E
                | E + sPor + E
                | E + sMas + E
                | E + sMenos + E

                //Relacional

                | E + sIgualacion + E
                | E + sDiferenciacion + E
                | E + sMenorQue + E
                | E + sMenorIgualQue + E
                | E + sMayorQue + E
                | E + sMayorIgualQue + E

                //logicos

                | E + sAnd + E
                | E + sOr + E
                | sNot + E

                | sAbreParent + E + sCierraParent

                | ID_VAR_FUNC
                | valBoolean
                | valCadena
                | valCadena2
                | valDecimal
                | valNumero
                | valDate + valTime
                | valDate
                | SSL_OPE_TIPO
                | SSL_CONTAR

                //| E_SSL
                //| E_CONT
                ;


            /*
                        E_NEGATIVO.Rule = sMenos + E;
                        E_POT.Rule = E + sPot + E;
                        E_DIV.Rule=E + sDiv + E;
                        E_POR.Rule=E + sPor + E;
                        E_MAS.Rule=E + sMas + E;
                        E_MENOS.Rule=E + sMenos + E;

                        E_IGUALACION.Rule=E + sIgualacion + E;
                        E_DIFEREN.Rule=E + sDiferenciacion + E;
                        E_MENOR_QUE.Rule=E + sMenorQue + E;
                        E_MENOR_IGUAL.Rule=E + sMenorIgualQue + E;
                        E_MAYOR_QUE.Rule=E + sMayorQue + E;
                        E_MAYOR_IGUAL.Rule=E + sMayorIgualQue + E;

                        E_AND.Rule=E + sAnd + E;
                        E_OR.Rule=E + sOr + E;
                        E_NOT.Rule=sNot + E;


                        E_PARENT.Rule=sAbreParent + E + sCierraParent;
                        E_ID.Rule=ID_VAR_FUNC;

                        E_BOOL.Rule=valBoolean;
                        E_CAD.Rule=valCadena;
                        E_CAD1.Rule=valCadena2; 
                        E_DEC.Rule=valDecimal;
                        E_NUM.Rule=valNumero;

                        E_SSL.Rule=SSL_OPE_TIPO; 
                        E_CONT.Rule=SSL_CONTAR;
            */

            /*
             +-----------------------------
             | Asociatividad
             +----------------------------
             */

            RegisterOperators(1, Associativity.Left, sOr);
            RegisterOperators(2, Associativity.Left, sAnd);
            RegisterOperators(3, Associativity.Left, sNot);
            RegisterOperators(4, Associativity.Left, sMayorQue, sMenorQue, sMayorIgualQue, sMenorIgualQue, sIgualacion, sDiferenciacion);
            RegisterOperators(5, Associativity.Left, sMas, sMenos);
            RegisterOperators(6, Associativity.Left, sPor, sDiv, sMod);
            RegisterOperators(7, Associativity.Left, sPot);



            this.Root = S;
            #endregion
        }

        public override void ReportParseError(ParsingContext context)
        {
            String error = (String)context.CurrentToken.ValueString;
            int fila;
            int columna;

            fila = context.Source.Location.Line;
            columna = context.Source.Location.Column;

            if (error.Contains("Invalid character"))
            {
                string delimStr = ":";
                char[] delimiter = delimStr.ToCharArray();
                string[] division = error.Split(delimiter, 2);
                division = division[1].Split('.');
                error = "Caracter Invalido " + division[0];
                tablaErrores.insertErrorLexical(nombreArchivo, fila, columna, "Caractero no reconocido:" + division[0]);
            }
            else
            {

                fila = context.Source.Location.Line;
                columna = context.Source.Location.Column;
                tablaErrores.insertErrorSyntax(nombreArchivo, fila, columna, "No se esperaba token:" + error);
            }

            base.ReportParseError(context);
        }

    }
}
