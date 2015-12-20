Imports System.Data.SqlClient
Public Class ConexionSQL
    Private _Conexion As SqlConnection
    Private Transaccion As SqlTransaction
    Public RutaBdD As String
    Public Sub New()
        '"Data Source = (Localdb)\mssqllocaldb; AttachDbFilename = '" & RutaBdD & "'; Integrated Security = True"
        '"Data Source = (Localdb)\mssqllocaldb; Initial Catalog = Amanda2; Integrated Security = True"
        _Conexion = New SqlConnection("workstation id=rataperez.mssql.somee.com;packet size=4096;user id=SantiagoYepez_SQLLogin_1;pwd=r54erjbp33;data source=rataperez.mssql.somee.com;persist security info=False;initial catalog=rataperez") '("Data Source = (Localdb)\mssqllocaldb; Initial Catalog = rataperez; Integrated Security = True")
    End Sub
    Public ReadOnly Property Enlace As SqlConnection
        Get
            Return _Conexion
        End Get
    End Property
    Public ReadOnly Property ObtenerTransaccion As SqlTransaction
        Get
            Return Transaccion
        End Get
    End Property
    Public Function IniciarTransaccion() As Boolean
        Dim Ret As Boolean = True
        Try
            Transaccion = _Conexion.BeginTransaction
        Catch ex As Exception
            Ret = False
        End Try
        Return Ret
    End Function
    Public Function Abrir() As Boolean
        Dim Ret As Boolean = True
        Try : If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
        Catch ex As Exception : Ret = False
        End Try
        Return Ret
    End Function
    Public Function Cerrar() As Boolean
        Dim Ret As Boolean = True
        Try : If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
        Catch ex As Exception : Ret = False
        End Try
        Return Ret
    End Function
    Public Function ConexionCorrecta() As Boolean
        Dim Ret As Boolean = True
        Select Case Abrir()
            Case True : Cerrar()
            Case False : Ret = False
        End Select
        Return Ret
    End Function
End Class
