Public Class frmRegistro1
    Inherits System.Web.UI.Page

    Protected Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmInicioSesion.aspx")
    End Sub

    Protected Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click
        Panel1.Enabled = False
        If Not DatosCorrectos() Then
            Panel1.Enabled = True
            Exit Sub
        End If
        Try
            Dim DU As New DatosUsuario
            Dim TU As New TablaUsuario
            DU.Nombre.Valor = txtNombre.Text.Trim
            DU.Cedula.Valor = txtCedula.Text.Trim
            DU.Celular.Valor = txtTelfMovil.Text.Trim
            DU.Telefono.Valor = txtTelfFijo.Text.Trim
            DU.Direccion.Valor = txtDireccion.Text.Trim
            DU.Correo.Valor = txtCorreo.Text.Trim
            DU.FechaNace.Valor = Date.Parse(txtDia.Text.Trim & "/" & cmbMes.SelectedIndex + 1 & "/" & txtAño.Text.Trim)
            DU.Contraseña.Valor = DatosUsuario.GenerarContraseñaAleatoria(32)
            Select Case TU.Insertar(DU)
                Case True
                    Call (New Mensajero).enviarCorreo("Su contraseña para ingreso a RataPerez es: " & DU.Contraseña.Valor, "Contraseña RataPerez", DU.Correo.Valor)
                    lblEstado.Text = "Sus datos se han guardado satisfactoriamente. Se ha enviado un correo electrónico con su contraseña de inicio de sesión."
                    cmdRegistrar.Enabled = False
                    cmdCancelar.Text = "Atrás"
                Case False : lblEstado.Text = "Error interno, operación no completada."
            End Select
        Catch ex As Exception
            lblEstado.Text = "Error interno, operación no completada."
        End Try
        Panel1.Enabled = True
    End Sub
    Private Function DatosCorrectos() As Boolean
        If txtCedula.Text.Trim = "" Or txtNombre.Text.Trim = "" Or
            txtTelfFijo.Text.Trim = "" Or txtDireccion.Text.Trim = "" Or
            txtDia.Text.Trim = "" Or txtAño.Text.Trim = "" Then
            lblEstado.Text = "Error. Rellene los campos marcados con *."
            Return False
        End If
        'Comprobar existencia de usuario
        Dim DU As New DatosUsuario
        DU.Cedula.Valor = txtCedula.Text.Trim
        DU.Cedula.TomarEnCuenta = False
        'If Not DU.CedulaBien Then
        'lblEstado.Text = "Cédula incorrecta."
        'Return False
        'End If
        Dim TU As New TablaUsuario
        DU.Correo.Valor = txtCorreo.Text
        Select Case TU.CorreoRegistrado(DU)
            Case -1
                lblEstado.Text = "Error interno, operación no completada."
                Return False
            Case > 0
                lblEstado.Text = "Error. Correo electrónico ocupado."
                Return False
        End Select
        DU.Correo.TomarEnCuenta = False
        DU.Cedula.TomarEnCuenta = True
        Select Case TU.ExisteUsuario(DU)
            Case -1
                lblEstado.Text = "Error interno, operación no completada."
                Return False
            Case > 0
                lblEstado.Text = "Error. el usuario '" & txtCedula.Text & "' ya está registrado."
                Return False
        End Select
        Return True
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class