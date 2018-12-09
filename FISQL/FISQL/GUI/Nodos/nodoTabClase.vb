Public Class nodoTabClase



    Public nombre As String
    Public areaCodigo As New RichTextBox
    Public tab As New MetroFramework.Controls.MetroTabPage



    'Constructor
    Public Sub New(nombre As String)
        Me.nombre = nombre
        defRich()
        defTab()


    End Sub

    'Definiendo tab
    Public Function defTab()
        tab.Text = Me.nombre
        tab.Controls.Add(areaCodigo)
    End Function



    'Definiendo richText
    Public Function defRich()
        areaCodigo.Dock = DockStyle.Fill

    End Function


    'Metodo que ejecuta el nodod
    Public Function ejecutar()


        'enviando la infomarción al socket
        Dim socket As New cliente()
        Dim paquete As New Usql(areaCodigo.Text)


        socket.enviar(paquete.cadenaEnvio)


    End Function

End Class
