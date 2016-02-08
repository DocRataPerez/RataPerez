Public Class OpCita
    Public Shared Function ConsultarDisponibilidad(IdOdontologo As Integer) As ArrayList
        Dim DH As New DatosHorario
        DH.IdOdontologo.Valor = IdOdontologo
        Dim HorarioTrabajo As DataTable = (New TablaHorario).ConsultarHorario(DH)
        Dim DC As New DatosCita
        DC.IdOdontologo.Valor = IdOdontologo
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
End Class
