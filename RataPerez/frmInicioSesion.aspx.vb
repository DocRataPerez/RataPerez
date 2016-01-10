Public Class frmRegistro
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

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
            Case 1
                Select Case DU.PrimerInicio.Valor
                    Case True
                        Response.Redirect("frmCambioContraseña.aspx?usr=" & DU.Cedula.Valor)
                    Case False : Response.Redirect("frmPrincipal.aspx?usr=" & DU.Cedula.Valor)
                End Select
            Case 0 : MsgBox("Credenciales incorrectas.")
            Case Else : MsgBox("Error interno, operación no completada.")
        End Select
    End Sub
End Class