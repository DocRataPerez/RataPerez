Public Class frmRegistroEspecialidad
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Call ActualizarVistaEspecialidades()
        End If
    End Sub
    Protected Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmAdmin.aspx")
    End Sub

    Protected Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        If Not DatosCorrectos() Then Exit Sub
        Dim DE As New DatosEspecialidad
        DE.Especialidad.Valor = txtTitulo.Text.Trim
        Select Case (New TablaEspecialidad).Insertar(DE)
            Case True : lblEstado.Text = "'" & txtTitulo.Text.Trim & "' registrada correctamente."
                txtTitulo.Text = ""
                Call ActualizarVistaEspecialidades()
            Case False : lblEstado.Text = "Error interno."
        End Select
    End Sub
    Private Sub ActualizarVistaEspecialidades()
        gridEspecialidades.DataSource = (New TablaEspecialidad).SeleccionarTodo
        gridEspecialidades.DataBind()
    End Sub
    Private Function DatosCorrectos() As Boolean
        If txtTitulo.Text.Trim = "" Then
            lblEstado.Text = "Rellene todos los campos."
            Return False
        End If
        Dim DE As New DatosEspecialidad
        DE.Especialidad.Valor = txtTitulo.Text.Trim
        If (New TablaEspecialidad).ExisteOdontologo(DE) Then
            lblEstado.Text = "Ya se ha registrado una especialidad con este nombre."
            Return False
        End If
        Return True
    End Function
End Class