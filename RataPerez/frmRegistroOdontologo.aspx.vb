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
        Dim Doc As New DatosOdontologo
        Doc.Nombre.Valor = txtNombre.Text
        Doc.Apellido.Valor = txtApellido.Text
        Doc.IdEspecialidad.Valor = cmbIdEspecialidad.Items.Item(cmbEspecialidad.SelectedIndex).ToString
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
            Case True : lblEstado.Text = "Odontólogo registrado correctamente."
            Case False : lblEstado.Text = "Error interno."
        End Select
    End Sub
End Class