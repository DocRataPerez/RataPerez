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
        If Not DatosCorrectos() Then Exit Sub
        Dim Doc As New DatosOdontologo
        Doc.Nombre.Valor = txtNombre.Text.Trim
        Doc.Apellido.Valor = txtApellido.Text.Trim
        Doc.Cedula.Valor = txtCedula.Text.Trim
        Doc.Contraseña.Valor = Datos.GenerarCadenaAleatoria(8)
        Doc.IdEspecialidad.Valor = cmbIdEspecialidad.Items.Item(cmbEspecialidad.SelectedIndex).ToString
        Doc.Correo.Valor = txtCorreo.Text.Trim
        Dim DH As New DatosHorario
        With DH
            .Lunes.Valor = l1i.Text & "-" & l1f.Text & "|" & l2i.Text & "-" & l2f.Text
            .Martes.Valor = m1i.Text & "-" & m1f.Text & "|" & m2i.Text & "-" & m2f.Text
            .Miercoles.Valor = mm1i.Text & "-" & mm1f.Text & "|" & mm2i.Text & "-" & mm2f.Text
            .Jueves.Valor = j1i.Text & "-" & j1f.Text & "|" & j2i.Text & "-" & j2f.Text
            .Viernes.Valor = v1i.Text & "-" & v1f.Text & "|" & v2i.Text & "-" & v2f.Text
            .Sabado.Valor = s1i.Text & "-" & s1f.Text & "|" & s2i.Text & "-" & s2f.Text
            .Domingo.Valor = d1i.Text & "-" & d1f.Text & "|" & d2i.Text & "-" & d2f.Text
        End With
        Dim TDoc As New TransaccionOdontologo
        TDoc.Odontologo = Doc
        TDoc.Horario = DH
        Select Case TDoc.Operar(Transaccion.TipoOperacion.Insercion)
            Case True
                Call (New Mensajero).enviarCorreo("Su contraseña para ingreso a RataPerez es: " & Doc.Contraseña.Valor, "Contraseña RataPerez", Doc.Correo.Valor)
                lblEstado.Text = "Odontólogo registrado correctamente. Se ha enviado un correo electrónico con las credenciales de acceso."
            Case False : lblEstado.Text = "Error interno."
        End Select
    End Sub
    Private Function DatosCorrectos() As Boolean
        If txtApellido.Text.Trim = "" Or txtCedula.Text.Trim = "" Or txtNombre.Text.Trim = "" Or txtCorreo.Text.Trim = "" Then
            lblEstado.Text = "Rellene todos los campos."
            Return False
        End If
        If cmbIdEspecialidad.Items.Count = 0 Then
            lblEstado.Text = "No ha seleccionado una especialidad."
            Return False
        End If
        Dim DatosDocTemp As New DatosOdontologo
        DatosDocTemp.Cedula.Valor = txtCedula.Text.Trim
        If Not DatosDocTemp.CedulaBien Then
            lblEstado.Text = "Cédula incorrecta."
            Return False
        End If
        If (New TablaOdontologo).ExisteOdontologo(DatosDocTemp) Then
            lblEstado.Text = "Se ha registrado otro odontólogo con este número de cédula."
            Return False
        End If
        DatosDocTemp.Limpiar()
        DatosDocTemp.Correo.Valor = txtCorreo.Text.Trim
        If (New TablaOdontologo).CorreoRegistrado(DatosDocTemp) Then
            lblEstado.Text = "Se ha registrado otro odontólogo con este correo electrónico."
            Return False
        End If
        Return True
    End Function
End Class