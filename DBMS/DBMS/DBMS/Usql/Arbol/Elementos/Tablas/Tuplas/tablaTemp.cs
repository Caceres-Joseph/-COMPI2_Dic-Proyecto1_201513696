using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Usql.Arbol.Elementos.Tablas.Tuplas
{
    class tablaTemp
    {

        /*
         
        //nombre de la tabla
        String nombre;
        //sirve para el autoincrementable
        int numIndices = 0; 
        tuplaTitulo titulo;
        IList<tupla> filas;


        public tabla(String nombre, tuplaTitulo titulo)
        {
            this.titulo = titulo;
            this.nombre = nombre;
            this.filas = new List<tupla>();
        }


        //validando que venga la cantidad de parametros
        public void insertar(tupla nuevoItem)
        {
            filas.Add(nuevoItem);
            numIndices++;
        }

        public void selectAll()
        {
            Console.WriteLine("******* Haciendo la consulta ************");
            //haciendo un select




            //var salidaConsulta = from s in filas select new {Id= s.getItemValor(0), Nombre= s.getItemValor(1)};

            int indice = 0;

            var salidaConsulta = from s in filas where (int)s.getItemValor(indice).valor!=(int)s.getItemValor(2).valor select new { MyProperty = s} ;
            //var salidaConsulta = from s in filas  select new { MyProperty = s };




            foreach (var item in salidaConsulta )
            {

                itemValor val= item.MyProperty.getItemValor(1);
                String nombre = (String)val.getValorParseado("text");
                Console.WriteLine(nombre);

                /*
                itemValor id2 = item.Id;
                itemValor nombre2 = item.Nombre;

                String dato = (String)id2.getValorParseado("text");
                String nombre = (String)nombre2.getValorParseado("text");


                Console.Write("ID: "+dato);
                Console.WriteLine(" Nombre:" + nombre);
                 

    }


    /* foreach (var group in salidaConsulta)
     {
         Console.WriteLine("StandardID {0}:", group.Key);

         group.sg.ToList().ForEach(st => Console.WriteLine(st.StudentName));
     }
     

}



public void pruebaLinq()
{
    // Student collection
    IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

    var studentsGroupByStandard = from s in studentList
                                  group s by s.StandardID into sg
                                  orderby sg.Key
                                  select new { sg.Key, sg };


    foreach (var group in studentsGroupByStandard)
    {
        Console.WriteLine("StandardID {0}:", group.Key);

        group.sg.ToList().ForEach(st => Console.WriteLine(st.StudentName));
    }

}
         */
    }
}
