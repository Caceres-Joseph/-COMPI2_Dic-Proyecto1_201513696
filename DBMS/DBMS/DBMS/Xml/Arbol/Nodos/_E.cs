
using DBMS.Usql.Arbol.Elementos.Tablas.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Xml.Arbol.Nodos
{
    class _E : nodoModeloXml
    {
        /*
         * E.Rule = sMenos + valNumero
                | sMenos + valDecimal
                | valBoolean
                | valCadena
                | valCadena2
                | valDecimal
                | valNumero
                | valDate + valTime
                | valDate
                | valId
                | valId + sPunto + valId
                ;
         */
        public _E(string nombre) : base(nombre)
        {
        }


        public itemValor getValor()
        {
            return parseandoDato(lstAtributos.listaAtributos[0]);

        }


        public itemValor parseandoDato(itemAtributo tok)
        {
            itemValor retorno = new itemValor();
            retorno.setTypeNulo();


            switch (tok.nombretoken)
            {
                case "valCaracter":
                    retorno = new itemValor();

                    retorno.convertirCadena(tok.tok.valLower);

                    return retorno;
                case "valCadena":


                    retorno = new itemValor();

                    retorno.convertirCadena(tok.tok.val);
                    return retorno;
                case "valCadena2":


                    retorno = new itemValor();

                    retorno.convertirCadena(tok.tok.val);
                    return retorno;
                case "valNumero":
                    try
                    {
                        retorno = new itemValor();

                        retorno.setValor(int.Parse(tok.tok.valLower));
                        return retorno;
                    }
                    catch (FormatException e)
                    {
                        println("no se pudo parsear Numero");
                        return retorno;
                    }
                case "valDecimal":
                    try
                    {
                        retorno = new itemValor();
                        retorno.setTypeDecimal();
                        retorno.setValor(double.Parse(tok.tok.valLower));
                        return retorno;
                    }
                    catch (FormatException e)
                    {

                        println("no se pudo parsear Decimal");

                        return retorno;
                    }
                case "nulo":
                    retorno = new itemValor();
                    retorno.setTypeNulo();
                    return retorno;

                case "valDate":

                    retorno = new itemValor();
                    retorno.setTypeNulo();
                    if (lstAtributos.listaAtributos.Count == 2)
                    //es de tipo date time
                    {


                        retorno.convertirFecha(tok.tok.val + " " + lstAtributos.getValItem(1));
                        return retorno;
                    }
                    else
                    {

                        retorno.convertirFecha(tok.tok.val);
                        return retorno;
                    }

                case "valId":

                    retorno = new itemValor();
                    retorno.setTypeNulo();

                    if (lstAtributos.listaAtributos.Count == 3)
                    //es de tipo date time
                    {

                        retorno.convertirCadena(tok.tok.val + "." + lstAtributos.getValItem(2));
                    }
                    else
                    {

                        retorno.convertirCadena(tok.tok.val);
                    }

                    return retorno;


                case "-":

                    retorno = new itemValor();
                    retorno.setTypeNulo();


                    String tok2 = lstAtributos.listaAtributos[1].nombretoken;
                    if (tok2.Equals("valNumero"))
                    {
                        try
                        {
                            retorno = new itemValor();

                            retorno.setValor(-1 * int.Parse(lstAtributos.getValItem(1)));
                            return retorno;
                        }
                        catch (FormatException e)
                        {
                            println("no se pudo parsear el numero negativo");
                            return retorno;
                        }
                    }
                    else
                    {
                        try
                        {
                            retorno = new itemValor();
                            retorno.setTypeDecimal();
                            retorno.setValor(-1 * double.Parse(lstAtributos.getValItem(1)));
                            return retorno;
                        }
                        catch (FormatException e)
                        {

                            println("no se pudo parsear el decimal negativo");

                            return retorno;
                        }

                    }


                default:

                    println("no se pudo parsear Default->"+tok.nombretoken);
                    return retorno;

            }

            //return retorno;
        }
    }
}
