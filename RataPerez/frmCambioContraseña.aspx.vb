Public Class frmCambioContraseña
    Inherits System.Web.UI.Page

    Protected Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        If DatosCorrectos() Then
            Select Case Request.Params("t")
                Case "u"
                    Dim DU As New DatosUsuario
                    DU.Cedula.Valor = Request.Params("usr")
                    DU.Contraseña.Valor = txtConfirmacion.Text.Trim
                    Select Case (New TablaUsuario).CambiarContraseña(DU)
                        Case True
                            DU.Limpiar()
                            DU.Cedula.Valor = Request.Params("usr")
                            DU.PrimerInicio.Valor = False
                            Call (New TablaUsuario).CambiarPrimeraSesion(DU)
                            Response.Redirect("frmPanelUsuario.aspx?usr=" & DU.Cedula.Valor)
                        Case False : lblEstado.Text = "Error interno."
                    End Select
                Case "d"
                    Dim DtsO As New DatosOdontologo
                    DtsO.Cedula.Valor = Request.Params("usr")
                    DtsO.Contraseña.Valor = txtConfirmacion.Text.Trim
                    Select Case (New TablaOdontologo).CambiarContraseña(DtsO)
                        Case True
                            DtsO.Limpiar()
                            DtsO.Cedula.Valor = Request.Params("usr")
                            DtsO.PrimerInicio.Valor = False
                            Call (New TablaOdontologo).CambiarPrimeraSesion(DtsO)
                            Response.Redirect("frmPanelOdontologo.aspx?usr=" & DtsO.Cedula.Valor)
                        Case False : lblEstado.Text = "Error interno."
                    End Select
            End Select
        End If
    End Sub
    Private Function DatosCorrectos() As Boolean
        Dim Ret As Boolean = txtConfirmacion.Text.Trim <> "" Or txtContraseñaActual.Text.Trim <> "" Or txtNuevaContraseña.Text.Trim <> ""
        If Ret Then Ret = (txtNuevaContraseña.Text.Trim = txtConfirmacion.Text.Trim)
        If Ret Then
            Select Case Request.Params("t")
                Case "u"
                    Dim DU As New DatosUsuario
                    DU.Cedula.Valor = Request.Params("usr")
                    DU.Contraseña.Valor = txtContraseñaActual.Text.Trim
                    DU.Contraseña.TomarEnCuenta = False
                    Ret = (New TablaUsuario).IniciarSesion(DU)
                Case "d"
                    Dim DtsO As New DatosOdontologo
                    DtsO.Cedula.Valor = Request.Params("usr")
                    DtsO.Contraseña.Valor = txtContraseñaActual.Text.Trim
                    DtsO.Contraseña.TomarEnCuenta = False
                    Ret = (New TablaOdontologo).IniciarSesion(DtsO)
            End Select
        End If
        If Not Ret Then
            lblEstado.Text = "Datos incorrectos."
        End If
        Return Ret
    End Function
End Class