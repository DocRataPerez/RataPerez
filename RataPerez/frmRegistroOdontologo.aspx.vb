Public Class frmRegistroOdontologo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            cmbIdEspecialidad.Items.Clear()
            cmbEspecialidad.Items.Clear()
            For Each Fila As DataRow In (New TablaEspecialidad).SeleccionarTodo().Rows
                cmbEspecialidad.Items.Add(Fila.Item("especialidad"))
                cmbIdEspecialidad.Items.Add(Fila.Item("IdEspecialidad"))
            Next
        End If
    End Sub

    Protected Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim 
    End Sub
End Class