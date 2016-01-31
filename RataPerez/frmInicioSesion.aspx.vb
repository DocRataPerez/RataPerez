Public Class frmRegistro
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdRegistrarse_Click(sender As Object, e As EventArgs) Handles cmdRegistrarse.Click
        Response.Redirect("frmRegistro.aspx")
    End Sub

    Protected Sub cmdIniciarSesion_Click(sender As Object, e As EventArgs) Handles cmdIniciarSesion.Click
        If txtContraseña.Text.Trim = "" Or txtUsuario.Text.Trim = "" Then Exit Sub
        Select Case DropDownList1.Text.ToLower
            Case "usuario"
                Dim DU As New DatosUsuario
                Dim TU As New TablaUsuario
                DU.Cedula.Valor = txtUsuario.Text.Trim
                DU.Contraseña.Valor = txtContraseña.Text.Trim
                DU.Contraseña.TomarEnCuenta = False
                Select Case TU.IniciarSesion(DU)
                    Case 1
                        Select Case DU.PrimerInicio.Valor
                            Case True
                                Response.Redirect("frmCambioContraseña.aspx?usr=" & DU.Cedula.Valor & "&t=u")
                            Case False : Response.Redirect("frmPrincipal.aspx?usr=" & DU.Cedula.Valor)
                        End Select
                    Case 0 : MsgBox("Credenciales incorrectas.")
                    Case Else : MsgBox("Error interno, operación no completada.")
                End Select
            Case "administración"
                Dim DA As New DatosAdministracion
                Dim TA As New TablaAdmin
                DA.Usuario.Valor = txtUsuario.Text
                DA.Contraseña.Valor = txtContraseña.Text
                DA.Contraseña.TomarEnCuenta = False
                Select Case TA.IniciarSesion(DA)
                    Case 1 : Response.Redirect("frmAdmin.aspx")
                    Case 0 : MsgBox("Credenciales incorrectas.")
                    Case Else : MsgBox("Error interno, operación no completada.")
                End Select
            Case "odontólogo"
                Dim DTSO As New DatosOdontologo
                DTSO.Cedula.Valor = txtUsuario.Text.Trim
                DTSO.Contraseña.Valor = txtContraseña.Text
                DTSO.Contraseña.TomarEnCuenta = False
                Select Case (New TablaOdontologo).IniciarSesion(DTSO)
                    Case 1
                        Select Case DTSO.PrimerInicio.Valor
                            Case True
                                Response.Redirect("frmCambioContraseña.aspx?usr=" & DTSO.Cedula.Valor & "&t=d")
                            Case False
                                MsgBox("inicia sesion doc.")
                                'Response.Redirect("frmPrincipal.aspx?usr=" & DTSO.Cedula.Valor)
                        End Select
                    Case 0 : MsgBox("Credenciales incorrectas.")
                    Case Else : MsgBox("Error interno, operación no completada.")
                End Select
        End Select

    End Sub
End Class