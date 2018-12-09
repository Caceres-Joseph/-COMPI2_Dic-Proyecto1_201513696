Paquetes

#login
#finalizar
#error
#usql
#reporte

 S				->PARENT
 
 


PARENT.Rule = sAbreCorchete + LST_INSTR + sCierraCorchete;

LST_INSTR.Rule = MakePlusRule(LST_INSTR, sComa, INSTR);

INSTR.Rule = valCadena + sDosPuntos + valCadena
			| valCadena + sDosPuntos + valNumero
			| valCadena + sDosPuntos + PARENT ;