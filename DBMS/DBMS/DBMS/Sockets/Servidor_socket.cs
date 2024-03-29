﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using MetroFramework.Controls;
using DBMS.PlyCs.Gramatica;
using DBMS.Usql.Arbol.Elementos.Tablas;

namespace DBMS.Sockets
{
    class Servidor_socket
    {

        // Incoming data from the client.  
        public static string data = null;

        public static void StartListening(tablaSimbolos tabl)
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the   
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11002);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (true)
                {
                    Console.WriteLine("Esperando para una conexión...");
                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();
                    data = null;

                    // An incoming connection needs to be processed.  
                    while (true)
                    {
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }



                    data = data.Replace("<EOF>", "");
                    // Show the data on the console.  
                    //Console.WriteLine("Text received : {0}", data);
                    Form1.txtPlyCs.Text = data;


                    //Iniciando el analisis de plyCs
                    String mensajeRetorno= analizarPly(data, tabl);



                    // Echo the data back to the client.  
                    //byte[] msg = Encoding.ASCII.GetBytes(data);
                    byte[] msg = Encoding.ASCII.GetBytes(mensajeRetorno+"<EOF>");

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            //Console.WriteLine("\nPress ENTER to continue...");
            //Console.Read();

        }


        public static String analizarPly(String data, Usql.Arbol.Elementos.Tablas.tablaSimbolos tabl)
        {

            anlzPly gramPly = new anlzPly();
            return gramPly.iniciarAnalisis(data, tabl);

        }
    }
}
