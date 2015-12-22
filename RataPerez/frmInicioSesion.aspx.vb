Public Class frmRegistro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdRegistrarse_Click(sender As Object, e As EventArgs) Handles cmdRegistrarse.Click
        Response.Redirect("frmRegistro.aspx")
    End Sub

    Protected Sub cmdIniciarSesion_Click(sender As Object, e As EventArgs) Handles cmdIniciarSesion.Click
        If txtContraseña.Text.Trim = "" Or txtUsuario.Text.Trim = "" Then Exit Sub
        Dim DU As New DatosUsuario
        Dim TU As New TablaUsuario
        DU.Cedula.Valor = txtUsuario.Text.Trim
        DU.Contraseña.Valor = txtContraseña.Text.Trim
        DU.Contraseña.TomarEnCuenta = False
        Select Case TU.IniciarSesion(DU)
            Case 1 : Response.Redirect("frmPrincipal.aspx")
            Case 0 : MsgBox("Credenciales incorrectas.")
            Case Else : MsgBox("Error interno, operación no completada.")
        End Select
    End Sub
End Class