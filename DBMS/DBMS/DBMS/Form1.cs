using DBMS.PlyCs.Gramatica;
using DBMS.Sockets;
using DBMS.Usql.Gramatica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


//Linq

using System.Linq;
using System.Collections.Generic;
using DBMS.Usql.Arbol.Elementos.Tablas.Tuplas;
using DBMS.Usql.Arbol.Elementos.Tablas.Items;

namespace DBMS
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public static MetroFramework.Controls.MetroTextBox txtConsola = new MetroFramework.Controls.MetroTextBox();
        public static MetroFramework.Controls.MetroTextBox txtPlyCs = new MetroFramework.Controls.MetroTextBox();
        Thread thread;

        public Form1()
        {
            InitializeComponent();



            //inicializando los componentes
            txtConsola.Theme = MetroFramework.MetroThemeStyle.Dark;
            txtConsola.Dock = DockStyle.Fill;
            txtConsola.Multiline = true;
            txtConsola.Text = ">> Servidor DBMS";
            txtConsola.ScrollBars = ScrollBars.Both;

            txtPlyCs.Theme = MetroFramework.MetroThemeStyle.Dark;
            txtPlyCs.Dock = DockStyle.Fill;
            txtPlyCs.Multiline = true;
            txtPlyCs.ScrollBars = ScrollBars.Both;


            tabConsola.Controls.Add(txtConsola);
            tabPly.Controls.Add(txtPlyCs);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            mensajeConsola("Iniciando servidor..");

            thread = new Thread(() => Servidor_socket.StartListening());
            thread.IsBackground = true;
            thread.Start();
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        private void btnStop_Click(object sender, EventArgs e)
        {

            //anlzPly gramPly = new anlzPly();
            //gramPly.iniciarAnalisis(txtPlyCs.Text);



            anlzUsql analizador = new anlzUsql();
            analizador.iniciarAnalisis(txtPlyCs.Text);
        }



        public static void mensajeConsola(String mensaje)
        {
            DateTime hoy = DateTime.Now;
            txtConsola.Text = txtConsola.Text + System.Environment.NewLine + ">>[" + hoy.ToString() + "]  " + mensaje;
        }


        public static void mensajePly(String mensaje)
        {
            DateTime hoy = DateTime.Now;
            txtPlyCs.Text = txtPlyCs.Text + System.Environment.NewLine + ">>[" + hoy.ToString() + "]  " + mensaje;
        }

        private void btnGrafo_Click(object sender, EventArgs e)
        {

            anlzUsql analizador = new anlzUsql();
            analizador.dibujarGrafo(txtPlyCs.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            //primero hay que crear el titulo
            tuplaTitulo titulo = new tuplaTitulo();
            titulo.insertarNuevaColumna("id");
            titulo.insertarNuevaColumna("nombre");
            titulo.insertarNuevaColumna("edad");

            //creando la tabla
            tabla tablaPrueba = new tabla("prueba", titulo);


            //haciendo inserts
            tupla nuevaFila = new tupla();

            //datos
            itemValor id = new itemValor();
            id.setValor(3);

            itemValor nombre = new itemValor();
            nombre.setValor("Diego");

            itemValor edad = new itemValor();
            edad.setValor(11);

            //haciendo el insert
            nuevaFila.insertar(id);
            nuevaFila.insertar(nombre);
            nuevaFila.insertar(edad);



            //haciendo inserts
            tupla nuevaFila2 = new tupla();

            //datos
            itemValor id2 = new itemValor();
            id2.setValor(12);

            itemValor nombre2 = new itemValor();
            nombre2.setValor("Jhosef");

            itemValor edad2 = new itemValor();
            edad2.setValor(12);

            //haciendo el insert
            nuevaFila2.insertar(id2);
            nuevaFila2.insertar(nombre2);
            nuevaFila2.insertar(edad2);


            tablaPrueba.insertar(nuevaFila);
            tablaPrueba.insertar(nuevaFila2);

            tablaPrueba.selectAll();
            */
            funcionamientos_minimos((15 + 2 / 2) * 2 - 10, 5 + (28 / 4) * 2);

        }

        public void pruebaLinq2()
        {


        }

        public void funcionamientos_minimos(int var1, int var2)
        {
            int contador = 0;
            Boolean bandera = (((5 > 10) || (15 < 25)) && (contador == 0));
            Console.WriteLine("bandera");
            Console.WriteLine(bandera);
            while ((contador >= 0) && ((contador < 10) || (bandera == false)))
            {
                if (contador>5)
                {
                    Console.WriteLine("salida de minetras [6-9]:" + contador);
                }
                switch (contador)
                {
                    case 6:
                        Console.WriteLine("seis");
                        break;

                    case 7:
                        Console.WriteLine("siete");
                        break;

                    case 8:
                        Console.WriteLine("ocho");
                        break;

                    case 9:
                        Console.WriteLine("nueve");
                        break;
                    default:
                        Console.WriteLine("defecto");
                        break;

                }
                contador++;
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

    }

    public class Order
    {

    }

    public class Student
    {

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public int StandardID { get; set; }
    }


}
