


Public Class Menu
    Inherits Tabs


    'Menu nuevo
    Private Overloads Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click

        Dim dialog = InputBox("Nombre del nuevo script?", "MEnsaje", "")

        If dialog <> "" Then
            Me.nuevaPestania(dialog)
        End If


        'MetroMessageBox.Show(Me, "Your message here.","Title Here",MessageBoxButtons.OKCancel,MessageBoxIcon.Hand)

    End Sub




    'Ejecutando la tab seleccionada
    Private Overloads Sub mEjecutar_Click(sender As Object, e As EventArgs) Handles mEjecutar.Click
        tabs.ejecutar(TabsEditor.SelectedIndex)
    End Sub

End Class
