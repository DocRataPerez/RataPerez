Public Class frmPrincipal
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim DU As New DatosUsuario
            DU.Cedula.Valor = Request.Params("usr")
            Dim T As DataTable = (New TablaUsuario).UsuarioCedula(DU)
            lblIdUsuario.Text = T.Rows(0).Item("idusuario")
            lblPaciente.Text = T.Rows(0).Item("nombre") & " (" & T.Rows(0).Item("cedula") & ")"
            For Each Fila As DataRow In (New TablaEspecialidad).SeleccionarTodo().Rows
                cmbEspecialidad.Items.Add(Fila.Item("especialidad"))
            Next
        End If
    End Sub

    Protected Sub cmdConsultarOdontologo_Click(sender As Object, e As EventArgs) Handles cmdConsultarOdontologo.Click
        cmbOdontologo.Items.Clear()
        cmbIdOdontologo.Items.Clear()
        Dim Fila() As DataRow = (New TablaEspecialidad).SeleccionarTodo().Select("especialidad = '" & cmbEspecialidad.SelectedItem.ToString & "'")
        Dim DT As New DatosOdontologo
        DT.IdEspecialidad.Valor = Fila(0).Item("idespecialidad").ToString
        For Each F As DataRow In (New TablaOdontologo).MostrarOdontologoEspecialidad(DT).Rows
            cmbOdontologo.Items.Add(F.Item("nombre") & " " & F.Item("apellido"))
            cmbIdOdontologo.Items.Add(F.Item("idodontologo"))
        Next
    End Sub

    Protected Sub cmdConsultarDisponibilidad_Click(sender As Object, e As EventArgs) Handles cmdConsultarDisponibilidad.Click
        lblEstado.Text = "Cita no reservada."
        GridView1.DataSource = Nothing
        GridView1.DataBind()
        Dim IntervalosDisponibles As New ArrayList
        Dim DH As New DatosHorario
        DH.IdOdontologo.Valor = cmbIdOdontologo.Items.Item(cmbOdontologo.SelectedIndex).ToString
        For Each F As DataRow In (New TablaHorario).ConsultarHorario(DH).Rows
            Dim Dia As String = ""
            Select Case Calendar1.SelectedDate.DayOfWeek
                Case DayOfWeek.Monday : Dia = "lunes"
                Case DayOfWeek.Tuesday : Dia = "martes"
                Case DayOfWeek.Wednesday : Dia = "miercoles"
                Case DayOfWeek.Thursday : Dia = "jueves"
                Case DayOfWeek.Friday : Dia = "viernes"
                Case DayOfWeek.Saturday : Dia = "sabado"
                Case DayOfWeek.Sunday : Dia = "domingo"
            End Select
            For Each P As String In Split(F.Item(Dia), "|")
                Dim Horas() As String = Split(P, "-")
                Dim Hi As Integer = Val(Horas(0))
                Dim Hf As Integer = Val(Horas(1))
                If Hi <> 0 And Hf <> 0 Then
                    For I As Integer = Hi To Hf - 1
                        IntervalosDisponibles.Add({I, I + 1})
                    Next
                End If
            Next
        Next
        If IntervalosDisponibles.Count = 0 Then
            lblEstado.Text = "No hay horarios disponibles para este día."
            Exit Sub
        End If
        Dim DC As New DatosCita
        DC.IdOdontologo.Valor = cmbIdOdontologo.Items.Item(cmbOdontologo.SelectedIndex).ToString
        DC.Fecha.Valor = Calendar1.SelectedDate
        For Each F As DataRow In (New TablaCita).HorarioOcupado(DC).Rows
            Dim HoraOcupada As Integer = CType(F.Item("hora"), TimeSpan).Hours
            For I As Integer = 0 To IntervalosDisponibles.Count - 1
                If IntervalosDisponibles(I)(0) = HoraOcupada Then
                    IntervalosDisponibles.RemoveAt(I)
                    Exit For
                End If
            Next
        Next
        If IntervalosDisponibles.Count = 0 Then
            lblEstado.Text = "No hay horarios disponibles para este día."
            Exit Sub
        End If
        Dim T As New DataTable
        With T
            .Columns.Add("Desde")
            .Columns.Add("Hasta")
            For I As Integer = 0 To IntervalosDisponibles.Count - 1
                .Rows.Add({IntervalosDisponibles(I)(0), IntervalosDisponibles(I)(1)})
            Next
        End With
        GridView1.DataSource = T
        GridView1.DataBind()
    End Sub

    Protected Sub cmdReservar_Click(sender As Object, e As EventArgs) Handles cmdReservar.Click
        Dim DC As New DatosCita
        With DC
            DC.IdOdontologo.Valor = cmbIdOdontologo.Items.Item(cmbOdontologo.SelectedIndex).ToString
            DC.IdUsuario.Valor = lblIdUsuario.Text
            DC.Fecha.Valor = Calendar1.SelectedDate
            DC.Hora.Valor = GridView1.SelectedRow.Cells(1).Text & ":00:00"
        End With
        Select Case (New TablaCita).Insertar(DC)
            Case True : lblEstado.Text = "Cita reservada."
            Case False : lblEstado.Text = "Error. Cita no reservada."
        End Select
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class