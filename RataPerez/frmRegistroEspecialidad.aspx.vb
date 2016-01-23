Public Class frmRegistroEspecialidad
    Inherits System.Web.UI.Page

    Protected Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmAdmin.aspx")
    End Sub

    Protected Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Dim DE As New DatosEspecialidad
        DE.Especialidad.Valor = txtTitulo.Text.Trim
        Select Case (New TablaEspecialidad).Insertar(DE)
            Case True : lblEstado.Text = "'" & txtTitulo.Text.Trim & "' registrada correctamente."
                txtTitulo.Text = ""
            Case False : lblEstado.Text = "Error interno."
        End Select
    End Sub
End Class