Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading


Public Class cliente




    Public Function enviar(env As String)


        Console.WriteLine("--------Cliente-------")
        Try
            Console.WriteLine(cliente(env))
        Catch ex As Exception
            Console.WriteLine("Ocurrió un error al conectar al cliente")
        End Try

    End Function



    Private Function cliente(tel As String) As String


        ' Data buffer for incoming data.  
        Dim bytes(1024) As Byte

        ' Connect to a remote device.  

        ' Establish the remote endpoint for the socket.  
        ' This example uses port 11000 on the local computer.  
        Dim ipHostInfo As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim ipAddress As IPAddress = ipHostInfo.AddressList(0)
        Dim remoteEP As New IPEndPoint(ipAddress, 11002)

        ' Create a TCP/IP socket.  
        Dim sender As New Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp)

        ' Connect the socket to the remote endpoint.  
        sender.Connect(remoteEP)

        Console.WriteLine("Socket connected to {0}",
            sender.RemoteEndPoint.ToString())

        ' Encode the data string into a byte array.  
        Dim msg As Byte() =
        Encoding.ASCII.GetBytes(tel + "<EOF>")



        ' Send the data through the socket.  
        Dim bytesSent As Integer = sender.Send(msg)



        ' Receive the response from the remote device.   
        Dim valor As String
        valor = ""

        While True
            Dim bytesRec1 As Integer = sender.Receive(bytes)
            valor += Encoding.ASCII.GetString(bytes, 0, bytesRec1)

            If valor.IndexOf("<EOF>") > -1 Then
                Exit While
            End If
        End While


        ' Release the socket.  
        sender.Shutdown(SocketShutdown.Both)
        sender.Close()

        Return valor
    End Function

End Class
