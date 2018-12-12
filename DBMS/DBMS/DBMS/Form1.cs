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

namespace DBMS
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
       public static  MetroFramework.Controls.MetroTextBox txtConsola = new MetroFramework.Controls.MetroTextBox();
       public static  MetroFramework.Controls.MetroTextBox txtPlyCs = new MetroFramework.Controls.MetroTextBox();
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
            CheckForIllegalCrossThreadCalls =  false;
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
            DateTime hoy = DateTime.Today;
            txtConsola.Text = txtConsola.Text + System.Environment.NewLine + ">>[" + hoy.ToString() + "]" + mensaje;
        }


        public static void mensajePly(String mensaje)
        {
            DateTime hoy = DateTime.Today;
            txtPlyCs.Text = txtPlyCs.Text + System.Environment.NewLine+">>[" + hoy.ToString() + "]" + mensaje;
        }


    }
}
