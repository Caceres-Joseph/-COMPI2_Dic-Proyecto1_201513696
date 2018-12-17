using DBMS.Globales;
using DBMS.Usql.Arbol.Elementos.Tablas.Elementos;
using DBMS.Usql.Arbol.Elementos.Tablas.Listas;
using DBMS.Usql.Arbol.Elementos.Tablas.Objetos;
using DBMS.Usql.Arbol.Elementos.Tablas.TablaUsql.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas
{
    class tablaSimbolos
    {

        public tablaErrores tablaErrores = new tablaErrores();
        public String rutaProyect = "";


        //la lista de objetos
        public List<elementoClase> lstClases;
         
        //los procedimientos y funciones
        public lstMetodo_funcion lstMetodo_funcion;
        public lstVariablesGlobales lstVariablesGlobales;

        //lista de objetos
        public lstObjetos listaObjetos;

        //lista de base de datos
        public lstBaseDeDatos listaBaseDeDatos;

        //tabla para mensajes usql
        public tablaMensajesUsql tablaMensajesUsql;


        public tablaSimbolos()
        { 


            lstClases = new List<elementoClase>();
            this.lstMetodo_funcion = new lstMetodo_funcion(this, "metodos_funciones"); 
            this.lstVariablesGlobales = new lstVariablesGlobales(this, "var_globales");
            this.listaObjetos = new lstObjetos(this);
            this.listaBaseDeDatos = new lstBaseDeDatos(this);
            this.tablaMensajesUsql = new tablaMensajesUsql();

        }
         

        public void setRutaProyecto(String ruta)
        {

            this.rutaProyect = ruta;
        }

        public String getRutaProyecto()
        {
            return rutaProyect;
        }

        public void inicializarTablas(String ruta)
        {
            Console.WriteLine("[tablaSImbolos]inicializando tabla");
            tablaErrores = new tablaErrores();
            rutaProyect = ruta;

        }
         


        public void imprimirClases()
        {
             
            foreach (elementoClase temp in lstClases)
            {
                temp.imprimir();
            }
             
        }

        public void iniciarEjecucion()
        {
            //antes carglo los extends



            //se cargan los atributos de los obejtos 

            foreach (elementoClase temp in lstClases)
            { 
                    ejecutandoClase(temp); 
            } 
        }

         
       

        public void ejecutandoClase(elementoClase clase)
        {
            ///hay que crear una instancia al objeto
            //println("Cargando las variables globales  de " + clase.nombreClase.valLower);
            objetoClase ObjClase = new objetoClase(clase, this);
            ObjClase.ejecutarGlobales();
            // ObjClase.ejecutarPrincipal();

            listaObjetos.insertar(ObjClase);

            ObjClase.imprimirTablaEntornos();
        }

        public void println(String mensaje)
        {
            tablaErrores.println("[tablaSimbolos]" + mensaje);
        }

        public elementoClase getClase(token nombre)
        {

            foreach (elementoClase temp in lstClases)
            {
                if (temp.nombreClase.valLower.Equals(nombre.valLower))
                {
                    return temp;

                }
            }

            //no encontro la clase 
            tablaErrores.insertErrorSemantic("No se puede crear una instancia al objeto: " + nombre.val + " debido a que no existe esa clase en este ambito", nombre);
            return null;

        }

         



        public Boolean hayErrores(String ambito)
        {


            Boolean retorno = true;

            if (tablaErrores.listaErrores.Count == 0)
            {
                retorno = false;

            }
            else
            {
                tablaErrores.println("No se puede ejecutar [" + ambito + "] porque hay errores en la tabla");
            }


            return retorno;


        }
    }
}
