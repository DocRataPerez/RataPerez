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
            If Request.Params("c") <> "-1" Then Call InterfazEdicion()
        End If
    End Sub

    Protected Sub cmdConsultarOdontologo_Click(sender As Object, e As EventArgs) Handles cmdConsultarOdontologo.Click
        Call Limpiar(1)
        Dim Fila() As DataRow = (New TablaEspecialidad).SeleccionarTodo().Select("especialidad = '" & cmbEspecialidad.SelectedItem.ToString & "'")
        Dim DT As New DatosOdontologo
        DT.IdEspecialidad.Valor = Fila(0).Item("idespecialidad").ToString
        For Each F As DataRow In (New TablaOdontologo).MostrarOdontologoEspecialidad(DT).Rows
            cmbOdontologo.Items.Add(F.Item("nombre") & " " & F.Item("apellido"))
            cmbIdOdontologo.Items.Add(F.Item("idodontologo"))
        Next
    End Sub

    Protected Sub cmdConsultarDisponibilidad_Click(sender As Object, e As EventArgs) Handles cmdConsultarDisponibilidad.Click
        Call ConsultarDiasDisponibles()
    End Sub
    Private Sub ConsultarDiasDisponibles()
        Call Limpiar(2)
        For Each DiaTrabajo() As Object In OpCita.ConsultarDisponibilidad(cmbIdOdontologo.Items.Item(cmbOdontologo.SelectedIndex).ToString)
            cmbFecha.Items.Add(CDate(DiaTrabajo(0)).ToLongDateString)
        Next
    End Sub

    Protected Sub cmdReservar_Click(sender As Object, e As EventArgs) Handles cmdReservar.Click
        Dim DC As New DatosCita
        With DC
            .IdOdontologo.Valor = cmbIdOdontologo.Items.Item(cmbOdontologo.SelectedIndex).ToString
            .IdUsuario.Valor = lblIdUsuario.Text
            .Fecha.Valor = CDate(cmbFecha.Items.Item(cmbFecha.SelectedIndex).ToString)
            .Hora.Valor = GridView1.SelectedRow.Cells(1).Text & ":00:00"
            If Request.Params("c") <> "-1" Then .IdCita.Valor = Request.Params("c")
        End With
        Dim Respuesta As Boolean = False
        Select Case Request.Params("c") = "-1"
            Case True : Respuesta = (New TablaCita).Insertar(DC)
            Case False : Respuesta = (New TablaCita).Editar(DC)
        End Select
        Select Case Respuesta
            Case True
                Call ConsultarDiasDisponibles()
                lblEstado.Text = "Cita reservada."
            Case False : lblEstado.Text = "Error. Cita no reservada."
        End Select
    End Sub
    Protected Sub cmdConsultarHorarios_Click(sender As Object, e As EventArgs) Handles cmdConsultarHorarios.Click
        If cmbFecha.SelectedIndex = -1 Then Exit Sub
        Call ConsultarHorarios()
    End Sub
    Private Sub ConsultarHorarios()
        Call Limpiar(3)
        Dim Fecha As Date = cmbFecha.Items.Item(cmbFecha.SelectedIndex).ToString
        Dim Intervalos As String = ""
        For Each D() As Object In OpCita.ConsultarDisponibilidad(cmbIdOdontologo.Items.Item(cmbOdontologo.SelectedIndex).ToString)
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
        If Nivel = 1 Then
            cmbOdontologo.Items.Clear()
            cmbIdOdontologo.Items.Clear()
        End If
        If Nivel <= 2 Then
            cmbFecha.Items.Clear()
        End If
        If Nivel <= 3 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        End If
    End Sub
    Private Sub InterfazEdicion()
        Call DeshabilitarCosas()
        Dim DC As New DatosCita
        DC.IdCita.Valor = Request.Params("c")
        Dim Cita As DataTable = (New TablaCita).MostrarCitaIdCita(DC)
        cmbEspecialidad.Text = Cita.Rows(0).Item("Especialidad")
        cmbOdontologo.Items.Add(Cita.Rows(0).Item("Nombre"))
        cmbOdontologo.Text = Cita.Rows(0).Item("Nombre")
        cmbIdOdontologo.Items.Add(Cita.Rows(0).Item("IdOdontologo"))
        Call ConsultarDiasDisponibles()
        cmdReservar.Text = "Guardar"
    End Sub
    Private Sub DeshabilitarCosas()
        cmbEspecialidad.Enabled = False
        cmdConsultarOdontologo.Enabled = False
        cmbOdontologo.Enabled = False
        'cmdConsultarDisponibilidad.Enabled = False
    End Sub
End Class