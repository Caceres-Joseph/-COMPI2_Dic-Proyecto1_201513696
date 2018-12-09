



Public Class lstTabClase
    Dim listaTabs As New List(Of nodoTabClase)()



    'Constructor
    Public Sub New()

    End Sub




    'crearNodo
    Public Function crearTab(nombre As String) As nodoTabClase


        Dim nuevaTab As New nodoTabClase(nombre)
        listaTabs.Add(nuevaTab)


        Return nuevaTab
    End Function


    'Metodo que ejecuta
    Public Function ejecutar(index As Integer)

        Dim nodoTab = listaTabs(index)
        nodoTab.ejecutar()

    End Function



End Class
