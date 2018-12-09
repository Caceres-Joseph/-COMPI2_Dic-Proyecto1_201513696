


Public Class Usql

    Public cadenaEnvio As String


    'Constructor
    Public Sub New(usql As String)
        'voy hacer un replace
        usql = usql.Replace("""", "'")

        cadenaEnvio = "[" + Constants.vbCrLf + """paquete"":""usql""," + Constants.vbCrLf +
            """instruccion"":""" + usql + """" + Constants.vbCrLf + "]"
    End Sub

End Class
