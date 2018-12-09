

Public Class Tabs
    Inherits IdeModel

    'Tengo que tener una lista de pestanias
    Public tabs As New lstTabClase()



    Public Function nuevaPestania(nombre As String)

        TabsEditor.Controls.Add(tabs.crearTab(nombre).tab)

    End Function

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Tabs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1320, 700)
        Me.Name = "Tabs"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub Tabs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Creando la pestaña por defecto
        nuevaPestania("SQL")

    End Sub
End Class
