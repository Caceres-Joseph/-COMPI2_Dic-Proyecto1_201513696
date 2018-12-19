using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DBMS.Usql.Arbol.Elementos.Tablas.Items;

namespace DBMS.Usql.Arbol.Nodos.Expresion.E.Oprelacional2
{
    class SelectMayorQue
    {


        public itemValor opMayorQue(itemValor val1, itemValor val2, String ambito)
        {

            itemValor retorno = new itemValor();



            if (val1 == null)
            {
                return retorno;
            }
            if (val2 == null)
            {
                return retorno;
            }


            try
            {
                /*
                |--------------------------------------------------------------------------
                | Booleano
                |--------------------------------------------------------------------------
                */
                /*
                 *Booleano > Booleano 
                 */
                if (val1.isTypeBooleano() && val2.isTypeBooleano())
                {

                    return retorno;
                }

                /*
                 *Booleano > Entero 
                 */

                else if (val1.isTypeBooleano() && val2.isTypeEntero())
                {


                    int entero1 = 0;
                    if (val1.getBooleano())
                    {
                        entero1 = 1;
                    }
                    else
                        entero1 = 0;


                    if (entero1 > val2.getEntero())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);

                    return retorno;
                }



                /*
                 *Booleano > Decimal 
                 */

                else if (val1.isTypeBooleano() && val2.isTypeDecimal())
                {


                    Double entero1 = 0.0;
                    if (val1.getBooleano())
                    {
                        entero1 = 1.0;
                    }
                    else
                        entero1 = 0.0;

                    if (entero1 > val2.getDecimal())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);

                    return retorno;
                }


                /*
                 *Booleano > Cadena  
                 */

                else if (val1.isTypeBooleano() && val2.isTypeCadena())
                {


                    int entero1 = 0;
                    if (val1.getBooleano())
                    {
                        entero1 = 1;
                    }
                    else
                        entero1 = 0;

                    if (entero1 > val2.getCadena().Length)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);

                    return retorno;
                }


                /*
                |--------------------------------------------------------------------------
                | Entero
                |--------------------------------------------------------------------------
                */
                /*
                 *Entero > Booleano  
                 */

                else if (val1.isTypeEntero() && val2.isTypeBooleano())
                {
                    int entero2 = 0;
                    if (val2.getBooleano())
                    {
                        entero2 = 1;
                    }
                    else
                        entero2 = 0;

                    if (val1.getEntero() > entero2)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);

                    return retorno;
                }

                /*
                 *Entero > Entero  
                 */

                else if (val1.isTypeEntero() && val2.isTypeEntero())
                {
                    if (val1.getEntero() > val2.getEntero())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }


                /*
                 *Entero > Decimal  
                 */

                else if (val1.isTypeEntero() && val2.isTypeDecimal())
                {


                    Double num2 = val2.getDecimal();


                    int valInt2 = (int)Math.Truncate(num2);

                    if (val1.getEntero() > valInt2)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Entero > Cadena 
                 * 
                 */

                else if (val1.isTypeEntero() && val2.isTypeCadena())
                {

                    if (val1.getEntero() > val2.getCadena().Length)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                |--------------------------------------------------------------------------
                | Cadena
                |--------------------------------------------------------------------------
                */

                /*
                 *Cadena * Booleano = Cadena
                 */

                else if (val1.isTypeCadena() && val2.isTypeBooleano())
                {
                    int entero2 = 0;
                    if (val2.getBooleano())
                    {
                        entero2 = 1;
                    }
                    else
                        entero2 = 0;

                    if (val1.getCadena().Length > entero2)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Cadena > Numerico 
                 */


                else if (val1.isTypeCadena() && val2.isTypeEntero())
                {


                    if (val1.getCadena().Length > val2.getEntero())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }
                /*
                 *Cadena > Decimal  
                 */

                else if (val1.isTypeCadena() && val2.isTypeDecimal())
                {

                    if (val1.getCadena().Length > val2.getDecimal())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Cadena > Cadena 
                 */
                else if (val1.isTypeCadena() && val2.isTypeCadena())
                {

                    if (val1.getCadena().Length > val2.getCadena().Length)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                |--------------------------------------------------------------------------
                | Decimal
                |--------------------------------------------------------------------------
                */
                /*
                 *Decimal > Booleano 
                 */

                else if (val1.isTypeDecimal() && val2.isTypeBooleano())
                {
                    Double entero2 = 0.0;
                    if (val2.getBooleano())
                    {
                        entero2 = 1.0;
                    }
                    else
                        entero2 = 0.0;

                    if (val1.getDecimal() > entero2)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;

                }

                /*
                 *Decimal > Numerico 
                 */

                else if (val1.isTypeDecimal() && val2.isTypeEntero())
                {
                    int valInt1 = (int)Math.Truncate(val1.getDecimal());

                    if (valInt1 > val2.getEntero())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Decimal > Cadena 
                 */

                else if (val1.isTypeDecimal() && val2.isTypeCadena())
                {
                    if (val1.getDecimal() > val2.getCadena().Length)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Decimal > Decimal 
                 */

                else if (val1.isTypeDecimal() && val2.isTypeDecimal())
                {
                    if (val1.getDecimal() > val2.getDecimal())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }


                /*
                |--------------------------------------------------------------------------
                | Comparando tipo date
                |--------------------------------------------------------------------------
                */
                /*
                 *FechaHora > Fecha 
                 */

                else if ((val1.isTypeFechaHora() || val1.isTypeFecha() || val1.isTypeHora()) && (val2.isTypeFechaHora() || val2.isTypeFecha() || val2.isTypeHora()))
                {
                    if (val1.getDecimal() > val2.getDecimal())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }
                else
                {
                    return retorno;
                }
            }
            catch (Exception)
            {
                return retorno;
            }
        }

    }
}
