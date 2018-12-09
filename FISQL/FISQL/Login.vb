Public Class Login


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Globales.user = txtUser.Text
        Globales.password = txtPassword.Text


        'aquí envio el paquete de login

        If (True) Then
            Dim Ide As New Menu

            Ide.Show()
            Me.Hide()



        End If





    End Sub
End Class