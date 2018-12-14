

S  			->GLOBAL


GLOBAL 		->DDL2
			| LST_CUERPO






LST_CUERPO	-> MakeStarRule(LST_CUERPO, CUERPO);


CUERPO		-> DDL ;
			|  DCL ;
			|  DDL_RETORNO ;
			|  ID_VAR_FUNC ; 
			
			|  DML ;
			|  SSL 
			
			 
 
/*
+-----------------------------
| DDL
+-----------------------------
*/
DDL2		-> DDL_CREAR_FUNCION
			|  DDL_CREAR_PROC

DDL			-> DDL_CREAR_BASE 
			|  DDL_CREAR_TABLA
			|  DDL_CREAR_OBJETO
			|  DDL_CREAR_USUARIO
			


DDL_CREAR_BASE 			->crear base_datos valId 
DDL_CREAR_TABLA			->crear tabla ( LST_ATRIBUTO ) 
DDL_CREAR_OBJETO		->crear objeto ( LST_ATRIBUTO )
DDL_CREAR_USUARIO		->crear usuario valId  colocar sIgual valCadena

DDL_CREAR_PROC			->crear procedimiento valId ( LST_PARAMETRO ) { LST_CUERPO }
DDL_CREAR_FUNCION		->crear funcion ( LST_PARAMETRO ) {LST_CUERPO }


  '''TABLA'''
	#DDL_LST_PARAMETROS 		-> MakeStarRule(DD_LST_PARAMETROS, sComa, DDL_PARAMETRO)

	#DDL_PARAMETRO			-> TIPO valId DDL_COMPLEMENTO


			
  '''OBJETO'''			
						

						
DDL_COMPLEMENTO			-> makePlusRule(DDL_COMPLEMENTO, DDL_COMPLEMENTO_P);
	
 
DDL_COMPLEMENTO_P 		-> Nulo 
						|  No Nulo 
						|  Autoincrementable
						|  Llave_primaria
						|  Llave_foranea
						|  Unico  

						
  '''PROCEDIMIENTO Y FUNCION '''			

 
						
DDL_RETORNO 			->retorno VALOR 
					
	 
	
/*
+-----------------------------
| DML
+-----------------------------
*/

DML 					->DML_USAR 
						| DML_ALTERAR 
						| DML_ELIMINAR
						| DML_INSERTAR 
						| DML_ACTUALIZAR 
						| DML_BORRAR 
						| DML_SELECCIONAR

  ''' USAR '''

DML_USAR 				->   USAR valId 
  
  
  ''' ALTERAR '''	
DML_ALTERAR				->DML_ALT_TABLA_ADD
						| DML_ALT_TABLA_QUIT
						| DML_ALT_OBJ_ADD
						| DML_ALT_OBJ_QUIT
						| DML_ATL_US 

DML_ALT_TABLA_ADD 		->alterar tabla valId agregar (LST_ATRIBUTO)

#DML_ALT_TABLA_QUIT 		->alterar tabla valId quitar LST_VALOR
DML_ALT_TABLA_QUIT 	->alterar tabla valId quitar LST_VAL_ID

DML_ALT_OBJ_ADD 		->alterar objeto valId agregar (LST_ATRIBUTO)

#DML_ALT_OBJ_QUIT 		->alterar objeto valId quitar LST_VALOR
DML_ALT_OBJ_QUIT 		->alterar objeto valId quitar LST_VAL_ID

DML_ATL_US 				->alterar usuario valId cambiar tPassword sIgual valCadena 
						 

  ''' ELIMINAR '''	
DML_ELIMINAR 			->DML_DEL_TABLA 
						| DML_DEL_BASE
						| DML_DEL_OBJ
						| DML_DEL_US 

DML_DEL_TABLA 			->tEliminar tabla valId 

DML_DEL_BASE			->tEliminar base_datos valId
 
DML_DEL_OBJ				->tEliminar objeto valId

DML_DEL_US				->tEliminar usuario valId 
						
  ''' INSERTAR '''	
DML_INSERTAR 			->DML_INSERTAR_1
						| DML_INSERTAR_2

DML_INSERTAR_1			->tInsertar tEn tTabla valId ( LST_VALOR )

DML_INSERTAR_2 			->tInsertar tEn tTabla valId ( LST_VAL_ID ) tValores (LST_VALOR )
#DML_INSERTAR_2 			->tInsertar tEn tTabla valId ( LST_VAL_ID ) tValores (LST_VALOR )					

  ''' ACTUALIZAR '''	
DML_ACTUALIZAR 			->DML_ACTUALIZAR_1
					     |DML_ACTUALIZAR_2 

						 
DML_ACTUALIZAR_1		->tActualizar tTabla  valId (LST_VAL_ID) tValores (LST_VALOR ) 

DML_ACTUALIZAR_2 		->tActualizar tTabla  valId (LST_VAL_ID) tValores (LST_VALOR ) tDonde VALOR 
						 
  ''' BORRAR '''
DML_BORRAR 				->DML_BORRAR_1
						| DML_BORRAR_2

DML_BORRAR_1 			->tBorrar tEn tTabla valId DONDE VALOR

DML_BORRAR_2			->tBorrar tEn tTabla valId 
						
  ''' SELECCIONAR '''
DML_SELECCIONAR 		->DML_SELECCIONAR_P 
						| DML_SELECCIONAR_P DML_ORDENAR

DML_SELECCIONAR_P 		->DML_SELECCIONAR_P1
						 |DML_SELECCIONAR_P2
						 |DML_SELECCIONAR_P3
						 |DML_SELECCIONAR_P4

DML_SELECCIONAR_P1		->tSeleccionar LST_VALOR tDe LST_VAL_ID tDonde VALOR
DML_SELECCIONAR_P3		->tSeleccionar LST_VALOR tDe LST_VAL_ID 
DML_SELECCIONAR_P2		->tSeleccionar * tDe LST_VAL_ID tDonde VALOR
DML_SELECCIONAR_P4		->tSeleccionar * tDe LST_VAL_ID 					 
						
						
DML_ORDENAR 			->tOrdenar_por valId tAsc
						| tOrdenar_por valId tAsc						
						| tOrdenar_por valId
						
 
/*
+-----------------------------
| DCL
+-----------------------------
*/
DCL					->DCL_OTORGAR 
					| DCL_DENEGAR

  ''' OTORGAR '''
  
DCL_OTORGAR			->tOtorgar tPermisos valId,  vaId . valId 
DCL_OTORGAR1		->tOtorgar tPermisos valId,  vaId . * 


DCL_DENEGAR			->tDenegar tPermisos valId, valId . vaId
DCL_DENEGAR1		->tDenegar tPermisos valId, valId . *


/*
+-----------------------------
| SSL
+-----------------------------
*/ 
 
SSL 				->SSL_DECLARAR ;
					| SSL_ASIGNAR  ;
					| SSL_SENTENCIAS
					| SSL_NATIVAS ; 
					| SSL_BACKUP ;
					| SSL_CONTAR;
  ''' DECLARAR '''
SSL_DECLARAR 		->tDeclarar LST_VARS TIPO VAL
					| tDeclarar LST_VARS TIPO 
					
  ''' ASIGNAR '''
SSL_ASIGNAR 		->SSL_ASIGNAR_1
					| SSL_ASIGNAR_2
					| SSL_ASIGNAR_3
					
SSL_ASIGNAR_1 		->ID_VAR_FUNC  VAL 
SSL_ASIGNAR_2 		->ID_VAR_FUNC sMas sMas
SSL_ASIGNAR_3 		->ID_VAR_FUNC sMenos sMenos

VAL 				-> sIgual VALOR 



SSL_SENTENCIAS 		->SSL_SI 
					| SSL_SELECCIONA
					| SSL_PARA
					| SSL_MIENTRAS
					

SSL_NATIVAS 		->SSL_IMPRIMIR



  ''' SI '''

SSL_SI 				->SSL_SI_1
					| SSL_SI_2  

SSL_SI_1			->tSi ( VALOR ) {LST_CUERPO} 
SSL_SI_2			->tSi ( VALOR ) {LST_CUERPO} SSL_SINO 
					
SSL_SINO 			->tSino (VALOR) {LST_CUERPO} 					
		
  ''' SELECCIONA '''			
					
SSL_SELECCIONA		->SSL_SELECCIONA_1
					| SSL_SELECCIONA_2

SSL_SELECCIONA_1	->(VALOR){SSL_CASOS}
SSL_SELECCIONA_2	->(VALOR){SSL_CASOS SSL_SEL_DEFECTO}

					
SSL_CASOS        	->MakePlusRule(SSL_CASOS, SSL_CASO)

SSL_CASO 			->tCaso VALOR sDosPuntos LST_CUERPO

SSL_SEL_DEFECTO		->tDefecto : LST_CUERPO

			
  ''' PARA '''
SSL_PARA 			->SSL_PARA_1
					| SSL_PARA_2
					| SSL_PARA_3
					| SSL_PARA_4
					| SSL_PARA_5
					| SSL_PARA_6

SSL_PARA_1 			->tPara ( SSL_DECLARAR; VALOR ;SSL_ASIGNAR){LST_CUERPO}
SSL_PARA_2			->tPara ( SSL_DECLARAR; VALOR ; --){LST_CUERPO}
SSL_PARA_3			->tPara ( SSL_DECLARAR; VALOR ; ++){LST_CUERPO}
SSL_PARA_4			->tPara ( SSL_ASIGNAR ; VALOR ;SSL_ASIGNAR){LST_CUERPO}
SSL_PARA_5			->tPara ( SSL_ASIGNAR ; VALOR ;--){LST_CUERPO}
SSL_PARA_6			->tPara ( SSL_ASIGNAR ; VALOR ;++){LST_CUERPO}
	
					
  ''' MIENTRAS '''
SSL_MIENTRAS		->tMientras ( VALOR ) {LST_CUERPO}
  
  ''' IMPRIMIR  '''
  
SSL_IMPRIMIR		->tImprimir(VALOR)

  
  ''' OPE_TIPO  '''
SSL_OPE_TIPO 		->SSL_FECHA
					| SSL_FECHA_HORA
					
					
SSL_FECHA 			->tFecha()		
SSL_FECHA_HORA		->tFecha_hora()		


  ''' CONTAR  '''
SSL_CONTAR 			->(<<	DML_SELECCIONAR >>)

  ''' BACKUP  '''
SSL_BACKUP			->SSL_DUMP
					| SSL_COMPLETO 
					| SSL_RESTAURAR_DUMP
					| SSL_RESTAURAR_COMPETO



SSL_DUMP 			->tBAckup tUsqldump vaId valId 

SSL_COMPLETO		->tBAckup uCompleto valId vaId


SSL_RESTAURAR_DUMP	->tRestaurar tUsqldump valCadena

SSL_RESTAURAR_COMPLETO	->tRestaurar uCompleto valCadena


    ''' LISTAS '''
LST_PARAMETRO 			-> makeStarRule(LST_PARAMETRO, sComa, PARAMETRO)
PARAMETRO				-> TIPO sArroba valId 


LST_VALOR 			-> makePlusRule(LST_VALOR, sComa, VALOR)

LST_VAL_ID			-> makePlusRule(LST_VAL_ID, sComa, valId) 

LST_VARS			->makePlusRule(LST_VARS, sComa, VARS)
VARS				->sArroba valId


LST_ATRIBUTO 			-> makeStarRule(LST_ATRIBUTO, sComa, ATRIBUTO)

ATRIBUTO				-> TIPO valId 
						|  TIPO valId DDL_COMPLEMENTO
						
						
		
/*
+-----------------------------
| TIPOS
+-----------------------------
*/ 				
						
    ''' TIPOS '''

TIPO 		->text 
			| integer
			| double
			| bool
			| date
			| datetime
			| valId #para los objetos


			
			
			'''Dudas '''
			
/*
+-----------------------------
| ID VAR 
+-----------------------------
*/ 

 
ID_VAR_FUNC		->ID_VAR_FUNC_1
				| ID_VAR_FUNC_2
				| ID_VAR_FUNC_3
				| ID_VAR_FUNC_4
				
				
ID_VAR_FUNC_1	->ID_VAR_FUNC LST_PUNTOS 
ID_VAR_FUNC_2	->@ valId
ID_VAR_FUNC_3	->valId
ID_VAR_FUNC_4	->valId()


LST_PUNTOS		->sPunto vaId 

/*
+-----------------------------
| VALOR
+-----------------------------
*/ 

VALOR 		-> E 


E 			->E_NEGATIVO
			
			//Aritemeticas
			|E_POT
			|E_DIV
			|E_POR
			|E_MAS
			|E_MENOS 

			//Relacional

			| E_IGUALACION
			| E_DIFEREN
			| E_MENOR_QUE
			| E_MENOR_IGUAL
			| E_MAYOR_QUE
			| E_MAYOR_IGUAL

			//logicos

			| E_AND
			| E_OR
			| E_NOT
 
			| E_PARENT

			| E_ID
			| E_BOOL
			| E_CAD
			| E_CAD1
			| E_CAD2
			| E_DEC
			| E_NUM
			 
			| E_SSL 
			| E_CONT
			
			
E_NEGATIVO  	->sMenos + E
E_POT			->E + sPot + E
E_DIV			->E + sDiv + E
E_POR			-> E + sPor + E
E_MAS 			->E + sMas + E
E_MENOS			->E + sMenos + E 

E_IGUALACION 	->E + sIgualacion + E
E_DIFEREN		->E + sDiferenciacion + E
E_MENOR_QUE		->E + sMenorQue + E
E_MENOR_IGUAL	->E + sMenorIgualQue + E
E_MAYOR_QUE		->E + sMayorQue + E
E_MAYOR_IGUAL 	->E + sMayorIgualQue + E

E_AND 			->E + sAnd + E
E_OR			->E + sOr + E
E_NOT			->sNot + E

E_PARENT		->sAbreParent + E + sCierraParent
E_ID			->ID_VAR_FUNC

E_BOOL			->valBoolean
E_CAD			->valCadena
E_CAD1			->valCadena2
E_CAD2 			->valCaracter
E_DEC			->valDecimal
E_NUM			->valNumero

E_SSL			->SSL_OPE_TIPO

E_CONT 			->SSL_CONTAR

 
