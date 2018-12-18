
using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Objetos;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Items
{
    class itemValor
    {

        /*
        |--------------------------------------------------------------------------
        | Tipos que soporta el lenguaje
        |--------------------------------------------------------------------------
        |
        |
        |
        |
        */
        public token nombreCartTabla;
        public token nombreCartColumna;
        public usqlTablaCartesiana tablaCartesiana;

        public void setCartColumna(token nombre)
        {
            nombreCartColumna = nombre;
            this.tipo = "nombreCartColumna";
        }


        public void setCartTablaColumna(token tabla, token columna)
        {

            nombreCartTabla = tabla;
            nombreCartColumna = columna;
            this.tipo = "nombreCartTablaColumna";
        }
        /*
         * Booleanos
         */

        public Boolean isTypeCartTablaColumna()
        {
            if (tipo.Equals("nombreCartTablaColumna"))
            {
                return true;
            }
            return false;
        }
        public Boolean isTypeCartColumna()
        {
            if (tipo.Equals("nombreCartColumna"))
            {
                return true;
            }
            return false;
        }

        /*
        |--------------------------------------------------------------------------
        | Tipos que soporta el lenguaje
        |--------------------------------------------------------------------------
        | text
        | bool
        | integer
        | double
        | date
        | datetime 
        | nulo
        | objeto  
        */


        string tipo;
        // public string tipo2 = "";
        public Object valor;
        public List<int> dimensiones;
        public String nombreObjeto = "";
        public Dictionary<int, itemValor> arrayValores = new Dictionary<int, itemValor>();


        //esto sirve para el tipo del metodo/funcion
        public token tipoFuncionMetodo = new token();

        //esto sirve para el nombre de la pregunta
        public token nombrePregunta = new token();




        public itemValor()
        {
            tipoFuncionMetodo = new token("vacio");
            this.tipo = "nulo";
            setTypeNulo();
            dimensiones = new List<int>();
            this.valor = new object();
        }



        /**
         * <br>|--------------------------------------------------------------------------
         * <br>| Set Value
         * <br>|--------------------------------------------------------------------------
         * <br>| Se usa cuando se envian los valores, y luego estos son parseados
         */
        /**
         * @param cadena Se esta recibiendo un tipo cadena
         */
        public void setValor(String cadena)
        {
            setTypeCadena();
            this.valor = cadena;
        }


        /**
         * @param entero
         */
        public void setValor(int valor)
        {
            setTypeEntero();
            this.valor = valor;
        }

        /**
         * @param valor Valor booleano
         */
        public void setValor(Boolean valor)
        {
            setTypeBooleano();
            this.valor = valor;
        }

        /**
         * @param entrada Valor entero 
         */
        public void setValor(double entrada)
        {
            setTypeDecimal();
            this.valor = entrada;
        }


        /**
         * @param entrada Valor date 
         */
        public void setValorDate(DateTime entrada)
        {
            setTypeFecha();
            this.valor = entrada;
        }


        /**
         * @param entrada Valor date 
         */
        public void setValorDateTime(DateTime entrada)
        {
            setTypeFechaHora();
            this.valor = entrada;

        }
        /** 
         * Convierte el valor en nulo
         */
        public void setValor()
        {
            this.tipo = "nulo";
            this.valor = null;
        }


        CultureInfo enUS = new CultureInfo("en-US");
        public void convertirCadena(String cadena)
        {

            //parseando a fecha/hora
            //parseando a fecha
            //paresando a hora
            try
            {
                this.tipo = "datetime";
                //DateTime oDate = DateTime.ParseExact(cadena, "dd/MM/yyyy hh:mm:ss ", System.Globalization.CultureInfo.InvariantCulture);

                DateTime oDate = DateTime.ParseExact(cadena, "dd-MM-yyyy HH:mm:ss", enUS, DateTimeStyles.None);

                this.valor = oDate;
            }
            catch (Exception e)
            {
                //  Console.WriteLine("[itemValor]No es fechaHora"+e);
                try
                {
                    this.tipo = "date";
                    DateTime oDate = DateTime.ParseExact(cadena, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    this.valor = oDate;
                }
                catch (Exception e2)
                {

                    // Console.WriteLine("[itemValor]No es hora" + e3);
                    this.tipo = "text";
                    this.valor = cadena;

                }
            }
        }



        public void convertirCadena2(String cadena)
        {
            cadena = cadena.Replace("‘", "");
            cadena = cadena.Replace("‘", "’");
            convertirCadena(cadena);
            //parseando a fecha/hora
            //parseando a fecha
        }

        /*
        |--------------------------------------------------------------------------
        | Obteniendo los tipos
        |--------------------------------------------------------------------------
        | text
        | bool
        | integer
        | double
        | date
        | datetime 
        | nulo
        | objeto 
        */


        public Boolean getBooleano()
        {


            //usando los metodos de parseo

            object val = getValorParseado("bool");
            if (val != null)
            {
                return (Boolean)val;
            }

            Console.WriteLine("[itemValor]getBooleano_No se puede parser el booleano");
            return false;


        }


        public int getEntero()
        {


            //usando los metodos de parseo

            object val = getValorParseado("integer");
            if (val != null)
            {
                return (int)val;
            }


            Console.WriteLine("[itemValor]getEntero_No se puede parser el getEntero");
            return 0;

        }

        public double getDecimal()
        {

            //usando los metodos de parseo

            object val = getValorParseado("double");
            if (val != null)
            {
                return (Double)val;
            }

            Console.WriteLine("[itemValor]getDecimal_No se puede parser el getDecimal _final");
            return 0.0;
        }



        public DateTime getFechaHora()
        {

            //usando los metodos de parseo

            object val = getValorParseado("datetime");
            if (val != null)
            {
                return (DateTime)val;
            }


            Console.WriteLine("[itemValor]getFechaHora_No se puede parser el DateTime");
            return new DateTime();

        }

        public String getCadena()
        {

            object val = getValorParseado("text");
            if (val != null)
            {
                return (String)val;
            }


            Console.WriteLine("[itemValor]getString_No se puede parser el getCadena");
            return "";

        }


        public objetoClase getObjeto()
        {

            try
            {
                return (objetoClase)valor;
            }
            catch (Exception e)
            {
                Console.WriteLine("[itemValor]getObjeto_No se puede parser a objetoClase");
                return null;
            }
        }



        /*
        |--------------------------------------------------------------------------
        | Para usar en el parseo
        |--------------------------------------------------------------------------
        | text
        | bool
        | integer
        | double
        | date
        | datetime 
        | nulo
        | objeto 
        */


        public Boolean getBooleano1()
        {


            try
            {
                return (Boolean)valor;
            }
            catch (Exception e)
            {
                Console.WriteLine("[itemValor]getBooleano_No se puede parser el booleano");
                return false;
            }

        }


        public int getEntero1()
        {


            try
            {
                return (int)valor;
            }
            catch (Exception e)
            {
                Console.WriteLine("[itemValor]getEntero_No se puede parser el getEntero");
                return 0;
            }

        }

        public double getDecimal1()
        {

            try
            {
                return (Double)valor;
            }
            catch (Exception e)
            {
                Console.WriteLine("[itemValor]getDecimal_No se puede parser el getDecimal");
                Console.WriteLine(e.Message.ToString());
                return 0.0;
            }
        }



        public DateTime getFechaHora1()
        {

            try
            {
                return (DateTime)valor;
            }
            catch (Exception e)
            {
                Console.WriteLine("[itemValor]getFechaHora_No se puede parser el DateTime");
                return new DateTime();
            }

        }

        public String getCadena1()
        {

            try
            {
                return valor.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("[itemValor]getString_No se puede parser el getCadena");
                return "";
            }

        }



        /*
        |--------------------------------------------------------------------------
        | Imprimiendo la variable
        |--------------------------------------------------------------------------
        */


        public void imprimirVariable()
        {

            imprimirVariable2();
            int i = 0;
            foreach (int inte in dimensiones)
            {
                println("dimen" + i + ": " + inte);
                i++;
            }


        }

        public void imprimirVariable2()
        {



            if (arrayValores.Count > 0)
            {
                /* foreach(int dim in dimensiones)
                 {
                     println("dimension: " + dim);
                 }*/


                foreach (var tem in arrayValores)
                {
                    println("[" + tem.Key + "] :");
                    tem.Value.imprimirVariable();
                }
            }
            else
            {
                if (isTypeCadena())
                {

                    println(getCadena1());
                }
                else if (isTypeBooleano())
                {
                    println(getBooleano1());
                }
                else if (isTypeEntero())
                {
                    println(getEntero1());
                }
                else if (isTypeDecimal())
                {
                    println(getDecimal1());
                }
                else if (isTypeFecha())
                {
                    println(getFechaHora1());
                }
                else if (isTypeFechaHora())
                {
                    println(getFechaHora1());
                }
                else if (isTypeHora())
                {
                    println(getFechaHora1());
                }
                else if (isTypeNulo())
                {
                    println("nulo");
                }
                else if (isTypeObjeto())
                {
                    println("objeto." + nombreObjeto);

                }
                else if (isTypeVacio())
                {
                    println("vacio");
                }
                else
                {
                    println("no se reconoce el tipo:" + tipo);
                }
            }
        }




        /*
        |--------------------------------------------------------------------------
        | Obtiene un tipo de valor en especifico
        |--------------------------------------------------------------------------
        */



        public object getValorParseado(String tipo)
        {

            switch (tipo)
            {
                case "text":

                    if (valor is DateTime)
                    {

                    }
                    if (isTypeFecha())
                    {
                        return getFechaHora1().ToString("dd/MM/yyy");
                    }
                    else
                    {

                        return getCadena1();
                    }



                case "bool":
                    if (isTypeBooleano())
                    {
                        return getBooleano1();
                    }
                    else if (isTypeEntero())
                    {
                        int entero = getEntero1();
                        if (entero == 0)
                        {
                            return false;
                        }
                        else if (entero == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return null;
                        }

                    }
                    else if (isTypeCadena())
                    {
                        if (getCadena1().ToLower().Equals("vardadero") || getCadena1().ToLower().Equals("true"))
                        {
                            return true;
                        }
                        else if (getCadena1().ToLower().Equals("falso") || getCadena1().ToLower().Equals("false"))
                        {
                            return false;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                case "integer":


                    if (isTypeEntero())
                    {
                        return getEntero1();
                    }
                    else if (isTypeBooleano())
                    {
                        if (getBooleano1())
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else if (isTypeDecimal())
                    {
                        return Convert.ToInt32(getDecimal1());
                    }
                    else if (isTypeFechaHora() || isTypeFecha() || isTypeHora())
                    {

                        DateTime starDate = DateTime.ParseExact("01/01/2000 00:00:00", "dd/MM/yyyy hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime endDate = getFechaHora1();

                        Double numDays = (endDate - starDate).Days;
                        return Convert.ToInt32(numDays);
                    }
                    else
                    {
                        try
                        {
                            int el = Convert.ToInt32(valor);
                            return el;
                        }
                        catch (Exception e)
                        {
                            println("error al parsear a entrero");
                            return null;
                        }
                    }

                case "double":
                    if (isTypeDecimal())
                    {
                        return getDecimal1();
                    }
                    else if (isTypeEntero())
                    {
                        return Convert.ToDouble(getEntero1());
                    }
                    else if (isTypeBooleano())
                    {
                        if (getBooleano1())
                        {
                            return 1.0;
                        }
                        else
                        {
                            return 0.0;
                        }
                    }
                    else if (isTypeFechaHora() || isTypeFecha() || isTypeHora())
                    {





                        DateTime starDate = DateTime.ParseExact("01/01/2000 00:00:00", "dd/MM/yyyy hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime endDate = getFechaHora1();

                        Double numDays = (endDate - starDate).Days;

                        return numDays;
                    }
                    else
                    {
                        return null;
                    }

                case "date":
                    if (isTypeFecha())
                    {
                        return getFechaHora1();
                    }
                    else
                    {
                        return null;
                    }

                case "datetime":
                    if (isTypeFechaHora())
                    {
                        return getFechaHora1();
                    }
                    else
                    {
                        return null;
                    }


                case "nulo":
                    //tengo que validar el tipo antes prro
                    return null;
                /*case "objeto":


                    setTypeObjeto();
                    break;*/
                default:
                    if (this.nombreObjeto == tipo)
                    {
                        return valor;
                    }
                    else
                    {
                        return null;
                    }
            }

        }


        /*
        |--------------------------------------------------------------------------
        | Enviando el tipo
        |--------------------------------------------------------------------------
        */
        public void setTypeCadena()
        {
            this.tipo = "text";
        }
        public void setTypeBooleano()
        {
            this.tipo = "bool";
        }
        public void setTypeEntero()
        {
            this.tipo = "integer";
        }
        public void setTypeDecimal()
        {
            this.tipo = "double";
        }
        public void setTypeFecha()
        {
            this.tipo = "date";
        }
        public void setTypeFechaHora()
        {
            this.tipo = "datetime";
        }
        public void setTypeNulo()
        {
            this.tipo = "nulo";
        }
        public void setTypeOb(String nombreObjeto)
        {
            this.tipo = "objeto";
            this.nombreObjeto = nombreObjeto;
        }

        public void setTypeVacio()
        {
            this.tipo = "vacio";
        }


        public void setArrayTipo(List<int> dimensiones, Dictionary<int, itemValor> arrayItems, String tipo)
        {
            this.dimensiones = dimensiones;
            this.arrayValores = arrayItems;
            this.setType(tipo);
        }
        /*
      |--------------------------------------------------------------------------
      | Set Value
      |--------------------------------------------------------------------------
      */
        public void setValue(String cadena)
        {
            this.tipo = "text";
            this.valor = cadena;
        }
        public void setValue(Boolean valor)
        {
            this.tipo = "bool";
            this.valor = valor;
        }
        public void setValue(int entrada)
        {
            this.tipo = "integer";
            this.valor = entrada;
        }
        public void setValue(double entrada)
        {
            this.tipo = "double";
            this.valor = entrada;
        }
        public void setValueFecha(DateTime fecha)
        {
            this.tipo = "date";
            this.valor = fecha;
        }
        public void setValueFechaHora(DateTime fecha)
        {
            this.tipo = "datetime";
            this.valor = fecha;
        }
        public void setValueHora(DateTime hora)
        {
            this.tipo = "hora";
            this.valor = hora;
        }
        public void setValueNulo()
        {
            this.tipo = "nulo";
        }
        public void setValue(Object o, String nombreObjeto)
        {
            this.tipo = "objeto";
            this.nombreObjeto = nombreObjeto;
            this.valor = o;
        }


        /*
      |--------------------------------------------------------------------------
      | getTipoApartirDeString
      |--------------------------------------------------------------------------
      */

        public static String getTipoApartirDeString(String tipo)
        {


            if (tipo.Equals("integer"))
            {
                return tipo;
            }
            else if (tipo.Equals("text"))
            {
                return tipo;
            }
            else if (tipo.Equals("double"))
            {
                return tipo;
            }
            else if (tipo.Equals("bool"))
            {
                return tipo;
            }
            else if (tipo.Equals("date"))
            {
                return tipo;
            }
            else if (tipo.Equals("datetime"))
            {
                return tipo;
            }
            else if (tipo.Equals("nulo"))
            {
                return tipo;
            }
            else if (tipo.Equals("vacio"))
            {
                return tipo;
            }
            else
            {
                return "objeto";
            }

        }


        /*
      |--------------------------------------------------------------------------
      | Set Value
      |--------------------------------------------------------------------------
      */
        public void setType(String cadena)
        {
            switch (cadena)
            {
                case "text":
                    setTypeCadena();
                    break;
                case "bool":
                    setTypeBooleano();
                    break;
                case "integer":
                    setTypeEntero();
                    break;
                case "double":
                    setTypeDecimal();
                    break;
                case "date":
                    setTypeFecha();
                    break;
                case "datetime":
                    setTypeFechaHora();
                    break;
                case "nulo":
                    setTypeNulo();
                    break;
                case "vacio":
                    setTypeVacio();
                    break;
                //tipo objeto
                default:
                    setTypeOb(tipo);
                    break;

            }

        }




        /*
        |--------------------------------------------------------------------------
        | Validando el tipo
        |--------------------------------------------------------------------------
        */
        public Boolean isTypeCadena()
        {

            if (valor is String)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public Boolean isTypeBooleano()
        {
            if (valor is Boolean)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public Boolean isTypeEntero()
        {

            if (valor is int)
            {
                return true;
            }
            return false;

        }
        public Boolean isTypeDecimal()
        {
            if (valor is Double)
            {
                return true;
            }
            return false;

        }
        public Boolean isTypeFecha()
        {

            if (this.tipo.Equals("date"))
                return true;
            else
                return false;
        }
        public Boolean isTypeFechaHora()
        {
            if (this.tipo.Equals("datetime"))
                return true;
            else
                return false;
        }
        public Boolean isTypeHora()
        {
            if (this.tipo.Equals("hora"))
                return true;
            else
                return false;
        }
        public Boolean isTypeNulo()
        {
            if (this.tipo.Equals("nulo"))
                return true;
            else
                return false;
        }
        public Boolean isTypeObjeto()
        {
            if (this.tipo.Equals("objeto"))
                return true;
            else
                return false;
        }
        public Boolean isTypeVacio()
        {
            if (this.tipo.Equals("vacio"))
                return true;
            else
                return false;
        }


        /*
        |--------------------------------------------------------------------------
        | Get Type
        |--------------------------------------------------------------------------
        */


        public void setValueDefault(String tipo)
        {

            switch (tipo)
            {
                case "text":
                    setValor("");
                    break;
                case "bool":
                    setValor(false);
                    break;



                case "integer":
                    setValor(0);
                    break;


                case "double":
                    setValor(1.0);
                    break;



                case "date":
                    setValorDate(DateTime.Today);
                    break;
                case "datetime":
                    setValorDateTime(DateTime.Now);
                    break;
                case "nulo":
                    setValor();
                    break;

                default:
                    setValor();
                    break;
            }

        }


        /*
        |--------------------------------------------------------------------------
        | Get Type
        |--------------------------------------------------------------------------
        */

        public String getTipo()
        {
            return tipo;
        }


        public void println(Object ob)
        {
            Console.WriteLine("\t\t[itemValor]" + tipo + "->" + ob.ToString());

        }
    }
}
