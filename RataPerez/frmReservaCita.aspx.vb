Public Class frmReservaCita
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim DDoc As New DatosOdontologo
            DDoc.Cedula.Valor = Request.Params("doc")
            Dim T As DataTable = (New TablaOdontologo).UsuarioCedula(DDoc)
            lblIdOdontologo.Text = T.Rows(0).Item("IdOdontologo")
            lblIdEspecialidad.Text = T.Rows(0).Item("IdEspecialidad")
            Call ConsultarDiasDisponibles()
        End If
    End Sub

    Private Sub ConsultarDiasDisponibles()
        Call Limpiar(1)
        For Each DiaTrabajo() As Object In OpCita.ConsultarDisponibilidad(lblIdEspecialidad.Text)
            cmbFecha.Items.Add(CDate(DiaTrabajo(0)).ToLongDateString)
        Next
    End Sub

    Protected Sub cmdConsultarHorarios_Click(sender As Object, e As EventArgs) Handles cmdConsultarHorarios.Click
        Call ConsultarHorarios()
    End Sub
    Private Sub ConsultarHorarios()
        Call Limpiar(2)
        Dim Fecha As Date = cmbFecha.Items.Item(cmbFecha.SelectedIndex).ToString
        Dim Intervalos As String = ""
        For Each D() As Object In OpCita.ConsultarDisponibilidad(lblIdEspecialidad.Text)
            If D(0).Equals(Fecha) Then
                Intervalos = D(1)
                Exit For
            End If
        Next
        Dim IntervalosDisponibles() As String = Split(Intervalos, "|")
        Dim T As New DataTable
        With T
            .Columns.Add("Desde")
            .Columns.Add("Hasta")
            For I As Integer = 0 To IntervalosDisponibles.Count - 1
                If IntervalosDisponibles(I) <> "-" Then
                    Dim Horas() As String = Split(IntervalosDisponibles(I), "-")
                    For J As Integer = Horas(0) To Horas(1) - 1
                        .Rows.Add({J, J + 1})
                    Next
                End If
            Next
        End With
        GridView1.DataSource = T
        GridView1.DataBind()
    End Sub
    Private Sub Limpiar(Nivel As Integer)
        If Nivel <= 1 Then
            cmbFecha.Items.Clear()
        End If
        If Nivel <= 2 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub cmdReservar_Click(sender As Object, e As EventArgs) Handles cmdReservar.Click
        If Not DatosCorrectos() Then Exit Sub
        Dim DU As New DatosUsuario
        DU.Cedula.Valor = txtCedulaPaciente.Text
        Dim T As DataTable = (New TablaUsuario).UsuarioCedula(DU)
        If T.Rows.Count <> 0 Then
            Dim DC As New DatosCita
            With DC
                .IdOdontologo.Valor = lblIdOdontologo.Text
                .IdUsuario.Valor = T.Rows(0).Item("idusuario")
                .Fecha.Valor = CDate(cmbFecha.Items.Item(cmbFecha.SelectedIndex).ToString)
                .Hora.Valor = GridView1.SelectedRow.Cells(1).Text & ":00:00"
            End With
            Select Case (New TablaCita).Insertar(DC)
                Case True
                    Call ConsultarDiasDisponibles()
                    lblEstado.Text = "Cita reservada."
                Case False : lblEstado.Text = "Error. Cita no reservada."
            End Select
        Else
            lblEstado.Text = "Error. Paciente no registrado."
        End If
    End Sub
    Private Function DatosCorrectos()
        If txtCedulaPaciente.Text.Trim = "" Or cmbFecha.SelectedIndex = -1 Or GridView1.SelectedRow Is Nothing Then
            lblEstado.Text = "Error. Rellene toda la información requerida"
            Return False
        End If
        Return True
    End Function
End Class