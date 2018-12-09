

#DDL  

DDL			-> crear base_datos VALOR 
			|  crear tabla ( DDL_LST_PARAMETROS )
			|  crear objeto ( LST_ATRIBUTO )
			|  crear procedimiento valId 
			|  crear funcion 

  '''TABLA'''
DDL_LST_PARAMETROS 		-> MakeStarRule(DD_LST_PARAMETROS, sComa, DDL_ PARAMETRO)

DDL_PARAMETRO			-> TIPO  valId DDL_COMPLEMENTO

DDL_COMPLEMENTO			-> 
						|  Nulo 
						|  No Nulo 
						|  Autoincrementable
						|  Llave_primaria
						|  Llave_foranea
						|  Unico 
			
  '''OBJETO'''			
						
LST_ATRIBUTO 			-> makeStarRule(LST_ATRIBUTO, sComa, ATRIBUTO)

ATRIBUTO				-> TIPO valId 
			 			
  '''PROCEDIMIENTO'''			

LST_PARAMETRO 			-> makeStarRule(LST_PARAMETRO, sCOma, PARAMETRO)

PARAMETRO				-> TIPO sArroba valId 

  
					
						
						
#DML


#DCL


#SSL


TIPO 		->text 
			| integer
			| double
			| bool
			| date
			| datetime

