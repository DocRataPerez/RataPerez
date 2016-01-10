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
        Dim DC As New DatosCita
        DC.IdOdontologo.Valor = cmbIdOdontologo.Items.Item(cmbOdontologo.SelectedIndex).ToString
        DC.Fecha.Valor = Calendar1.SelectedDate
        Dim IntervalosDisponibles As New ArrayList
        IntervalosDisponibles.AddRange({"8-12", "13-16"})
        For Each F As DataRow In (New TablaCita).HorarioOcupado(DC).Rows
            For P As Integer = 0 To IntervalosDisponibles.Count - 1
                Dim Horas() As String = Split(IntervalosDisponibles(P), "-")
                If Horas(0) = CType(F.Item("hora"), TimeSpan).Hours Then
                    IntervalosDisponibles(P) = Horas(0) + 1 & "-" & Horas(1)
                    Exit For
                ElseIf Horas(0) < CType(F.Item("hora"), TimeSpan).Hours And Horas(1) > CType(F.Item("hora"), TimeSpan).Hours Then
                    With IntervalosDisponibles
                        .RemoveAt(P)
                        .Insert(P, Horas(0) & "-" & CType(F.Item("hora"), TimeSpan).Hours)
                        .Insert(P + 1, CType(F.Item("hora"), TimeSpan).Hours + 1 & "-" & Horas(1))
                    End With
                End If
            Next
        Next

        Dim T As New DataTable
        With T
            .Columns.Add("i")
            .Columns.Add("o")
            For Each I As String In IntervalosDisponibles
                Dim Horas() As String = Split(I, "-")
                .Rows.Add(Horas)
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
            DC.Hora.Valor = txtHorarioDeseado.Text & ":0:0"
        End With
        Select Case (New TablaCita).Insertar(DC)
            Case True : lblEstado.Text = "Cita reservada."
            Case False : lblEstado.Text = "Error. Cita no reservada."
        End Select
    End Sub
End Class