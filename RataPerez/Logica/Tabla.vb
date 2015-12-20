Imports System.Data.SqlClient
Public MustInherit Class Tabla
    Private Conexion As ConexionSQL
    Protected SQLExe As SqlCommand
    Private ResultadoEjecucion As Integer
    Private EnTransaccion As Boolean
    Protected NombreTabla As String

    Public Sub New()
        Conexion = New ConexionSQL()
        Call Inicializar()
    End Sub
    Public Sub New(ByRef Conexion As ConexionSQL)
        Me.Conexion = Conexion
        Call Inicializar()
    End Sub
    Private Sub Inicializar()
        SQLExe = New SqlCommand()
        SQLExe.Connection = Conexion.Enlace
        EnTransaccion = False
    End Sub
    Public Property EncapsularEnTransaccion As Boolean
        Set(value As Boolean)
            EnTransaccion = value
        End Set
        Get
            Return EnTransaccion
        End Get
    End Property
    Protected Function EjecutarCadSQL() As Boolean
        Dim Ret As Boolean = True
        Select Case EnTransaccion
            Case True
                Try
                    SQLExe.Transaction = Conexion.ObtenerTransaccion
                    Ret = SQLExe.ExecuteNonQuery
                Catch ex As Exception
                    Ret = False
                    MsgBox("(Tran) En 'Tabla': " & ex.Message & vbCrLf & ex.HResult)
                End Try
            Case False
                Try
                    Ret = Conexion.Abrir()
                    If Ret Then
                        Ret = SQLExe.ExecuteNonQuery
                        Call Conexion.Cerrar()
                    End If
                Catch ex As Exception
                    Ret = False
                    MsgBox("En 'Tabla': " & ex.Message & vbCrLf & ex.HResult)
                End Try
        End Select
        Return Ret
    End Function

    Protected Function Mostrar() As DataTable
        Dim Ret As DataTable = Nothing
        If EjecutarCadSQL() Then
            Dim DT As New DataTable
            Call (New SqlDataAdapter(SQLExe)).Fill(DT)
            Ret = DT
        End If
        Return Ret
    End Function
    Protected MustOverride Sub IgualarDatos(ByRef Dts As Datos)
    Public MustOverride Function Insertar(ByRef Dts As Datos) As Boolean
    Public MustOverride Function Editar(ByRef Dts As Datos) As Boolean
    Public MustOverride Function Eliminar(ByRef Dts As Datos) As Boolean
    Public MustOverride Function SeleccionarTodo(Optional ByRef Dts As Datos = Nothing) As DataTable
    Public Function ObtenerIdentityInsertado() As Integer
        Dim Ret As Integer = -1
        SQLExe.CommandText = "ObtenerIdentityInsertado"
        SQLExe.CommandType = CommandType.StoredProcedure
        SQLExe.Parameters.Clear()
        SQLExe.Parameters.AddWithValue("@NombreTabla", NombreTabla)
        Dim T As DataTable = Mostrar()
        If T IsNot Nothing Then If T.Rows(0).Item(0) IsNot DBNull.Value Then Ret = Val(T.Rows(0).Item(0))
        Return Ret '-1 = error
    End Function

End Class
