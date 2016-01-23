Imports System.Data.SqlClient
Imports System.Threading.Tasks

Public MustInherit Class Transaccion
    Public Enum TipoOperacion
        Insercion
        Edicion
        Eliminacion
    End Enum
    Protected Transaccion As SqlTransaction
    Protected Conexion As ConexionSQL
    Protected Sub New()
        Conexion = New ConexionSQL
    End Sub
    Protected MustOverride Function Insertar() As Boolean
    Protected MustOverride Function Editar() As Boolean
    Protected MustOverride Function Eliminar() As Boolean
    Public Function Operar(Op As TipoOperacion) As Boolean
        Dim Ret As Boolean = Conexion.Abrir
        If Ret Then Ret = Conexion.IniciarTransaccion
        If Ret Then
            Transaccion = Conexion.ObtenerTransaccion
            Select Case Op
                Case TipoOperacion.Insercion : Ret = Insertar()
                Case TipoOperacion.Eliminacion : Ret = Eliminar()
                Case TipoOperacion.Edicion : Ret = Editar()
            End Select
            Select Case Ret
                Case True : Transaccion.Commit()
                Case False : Transaccion.Rollback()
            End Select
            Call Conexion.Cerrar()
        End If
        Return Ret
    End Function
End Class
