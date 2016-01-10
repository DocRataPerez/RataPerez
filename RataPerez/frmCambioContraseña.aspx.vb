Public Class frmCambioContraseña
    Inherits System.Web.UI.Page
    Public Usuario As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Usuario = Request.Params("usr")
    End Sub

    Protected Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        If DatosCorrectos() Then
            Dim DU As New DatosUsuario
            DU.Cedula.Valor = Usuario
            DU.Contraseña.Valor = txtConfirmacion.Text.Trim
            Select Case (New TablaUsuario).CambiarContraseña(DU)
                Case True
                    DU.Limpiar()
                    DU.Cedula.Valor = Usuario
                    DU.PrimerInicio.Valor = False
                    Call (New TablaUsuario).CambiarPrimeraSesion(DU)
                    Response.Redirect("frmPrincipal.aspx?usr=" & Usuario)
                Case False : lblEstado.Text = "Error interno."
            End Select
        End If
    End Sub
    Private Function DatosCorrectos() As Boolean
        Dim Ret As Boolean = txtConfirmacion.Text.Trim <> "" Or txtContraseñaActual.Text.Trim <> "" Or txtNuevaContraseña.Text.Trim <> ""
        If Ret Then Ret = (txtNuevaContraseña.Text.Trim = txtConfirmacion.Text.Trim)
        If Ret Then
            Dim DU As New DatosUsuario
            DU.Cedula.Valor = Usuario
            DU.Contraseña.Valor = txtContraseñaActual.Text.Trim
            DU.Contraseña.TomarEnCuenta = False
            Ret = (New TablaUsuario).IniciarSesion(DU)
        End If
        If Not Ret Then
            lblEstado.Text = "Datos incorrectos."
        End If
        Return Ret
    End Function
End Class