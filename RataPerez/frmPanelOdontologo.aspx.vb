Public Class frmPanelOdontologo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim DU As New DatosOdontologo
            DU.Cedula.Valor = Request.Params("usr")
            Dim T As DataTable = (New TablaOdontologo).UsuarioCedula(DU)
            lblBienvenido.Text = "Bienvenid@ doc " & T.Rows(0).Item("nombre") & " (" & T.Rows(0).Item("cedula") & ")"
            Call ActualizarVistaCitas()
        End If
    End Sub
    Private Sub ActualizarVistaCitas()
        Dim DU As New DatosOdontologo
        DU.Cedula.Valor = Request.Params("usr")
        gridCitas.DataSource = (New TablaOdontologo).MostrarCitasPendientes(DU)
        gridCitas.DataBind()
    End Sub

    Protected Sub cmdEliminarCita_Click(sender As Object, e As EventArgs) Handles cmdEliminarCita.Click
        If gridCitas.SelectedRow Is Nothing Then Exit Sub
        If MsgBox("¿Está seguro de eliminar esta cita? Este proceso es irreversible.", MsgBoxStyle.YesNo, "RataPerez - Eliminar cita") = MsgBoxResult.No Then Exit Sub
        Dim DC As New DatosCita
        DC.IdCita.Valor = gridCitas.SelectedRow.Cells(1).Text
        Select Case (New TablaCita).Eliminar(DC)
            Case True
                lblEstado.Text = "Cita eliminada."
                Call ActualizarVistaCitas()
            Case False
                lblEstado.Text = "Error. Cita no eliminada."
        End Select
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("frmReservaCita.aspx?doc=" & Request.Params("usr") & "&c=-1")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If gridCitas.SelectedRow Is Nothing Then Exit Sub
        Response.Redirect("frmReservaCita.aspx?doc=" & Request.Params("usr") & "&c=" & gridCitas.SelectedRow.Cells(1).Text)
    End Sub
End Class