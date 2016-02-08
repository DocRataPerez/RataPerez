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
        cmbFecha.Items.Clear()
        For Each DiaTrabajo() As Object In ConsultarDisponibilidad()
            cmbFecha.Items.Add(CDate(DiaTrabajo(0)).ToLongDateString)
        Next
    End Sub
    Private Function ConsultarDisponibilidad() As ArrayList
        Dim DH As New DatosHorario
        DH.IdOdontologo.Valor = cmbIdOdontologo.Items.Item(cmbOdontologo.SelectedIndex).ToString
        Dim HorarioTrabajo As DataTable = (New TablaHorario).ConsultarHorario(DH)
        Dim DC As New DatosCita
        DC.IdOdontologo.Valor = cmbIdOdontologo.Items.Item(cmbOdontologo.SelectedIndex).ToString
        Dim Citas As DataTable = (New TablaCita).CitasEnPeriodoDeFecha(DC, Date.Today, Date.Today.AddDays(30))
        Dim DiasTrabajo As New ArrayList
        ' obtener días de mes en los que el doc trabaja
        For I As Integer = 0 To 29
            Select Case Date.Today.AddDays(I).DayOfWeek
                Case DayOfWeek.Monday
                    If HorarioTrabajo.Rows(0).Item("lunes").ToString.Trim <> "-|-" Then
                        DiasTrabajo.Add({Date.Today.AddDays(I), HorarioTrabajo.Rows(0).Item("lunes").ToString.Trim})
                    End If
                Case DayOfWeek.Tuesday
                    If HorarioTrabajo.Rows(0).Item("martes").ToString.Trim <> "-|-" Then
                        DiasTrabajo.Add({Date.Today.AddDays(I), HorarioTrabajo.Rows(0).Item("martes").ToString.Trim})
                    End If
                Case DayOfWeek.Wednesday
                    If HorarioTrabajo.Rows(0).Item("miercoles").ToString.Trim <> "-|-" Then
                        DiasTrabajo.Add({Date.Today.AddDays(I), HorarioTrabajo.Rows(0).Item("miercoles").ToString.Trim})
                    End If
                Case DayOfWeek.Thursday
                    If HorarioTrabajo.Rows(0).Item("jueves").ToString.Trim <> "-|-" Then
                        DiasTrabajo.Add({Date.Today.AddDays(I), HorarioTrabajo.Rows(0).Item("jueves").ToString.Trim})
                    End If
                Case DayOfWeek.Friday
                    If HorarioTrabajo.Rows(0).Item("viernes").ToString.Trim <> "-|-" Then
                        DiasTrabajo.Add({Date.Today.AddDays(I), HorarioTrabajo.Rows(0).Item("viernes").ToString.Trim})
                    End If
                Case DayOfWeek.Saturday
                    If HorarioTrabajo.Rows(0).Item("sabado").ToString.Trim <> "-|-" Then
                        DiasTrabajo.Add({Date.Today.AddDays(I), HorarioTrabajo.Rows(0).Item("sabado").ToString.Trim})
                    End If
                Case DayOfWeek.Sunday
                    If HorarioTrabajo.Rows(0).Item("domingo").ToString.Trim <> "-|-" Then
                        DiasTrabajo.Add({Date.Today.AddDays(I), HorarioTrabajo.Rows(0).Item("domingo").ToString.Trim})
                    End If
            End Select
        Next
        'quitar horarios ocupados
        For Each F As DataRow In Citas.Rows
            Dim DiaCita As Date = F.Item("Fecha")
            Dim HoraCita As Integer = CType(F.Item("Hora"), TimeSpan).Hours
            Dim Horarioquitado As Boolean = False, DiaNoDisponible As Boolean = False
            For I As Integer = 0 To DiasTrabajo.Count - 1
                Dim DiaTrabajo() As Object = DiasTrabajo(I)
                If DiaTrabajo(0).Equals(DiaCita) Then
                    Dim Periodos() As String = Split(DiaTrabajo(1), "|")
                    For J As Integer = 0 To Periodos.Count - 1
                        If Periodos(J) <> "" And Periodos(J) <> "-" Then
                            Dim Horas() As String = Split(Periodos(J), "-")
                            If HoraCita >= Horas(0) And HoraCita <= Horas(1) Then
                                Dim IntervalosDisponibles As String = CosasFecha.QuitarCadenaIntervalos(HoraCita & "-" & HoraCita + 1, DiaTrabajo(1))
                                If IntervalosDisponibles = "" Then DiaNoDisponible = True
                                DiaTrabajo(1) = IntervalosDisponibles
                                Horarioquitado = True
                            End If
                        End If
                        If Horarioquitado Then Exit For
                    Next
                End If
                If DiaNoDisponible Then DiasTrabajo.Remove(DiaTrabajo)
                If Horarioquitado Then Exit For
            Next
        Next
        Return DiasTrabajo
    End Function

    Protected Sub cmdReservar_Click(sender As Object, e As EventArgs) Handles cmdReservar.Click
        Exit Sub
        Dim DC As New DatosCita
        With DC
            DC.IdOdontologo.Valor = cmbIdOdontologo.Items.Item(cmbOdontologo.SelectedIndex).ToString
            DC.IdUsuario.Valor = lblIdUsuario.Text
            ' DC.Fecha.Valor = Calendar1.SelectedDate
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