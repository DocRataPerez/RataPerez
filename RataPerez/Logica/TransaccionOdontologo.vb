Imports System.Threading.Tasks

Public Class TransaccionOdontologo
    Inherits Transaccion
    Public Structure Gasto
        Public IdRubro As Integer
        Public Valor As Double
    End Structure
    Public Gastos As ArrayList
    Public Odontologo As DatosOdontologo
    Public Horario As DatosHorario
    Private IdFactura As Integer
    Public Sub New()
        Gastos = New ArrayList
    End Sub
    Protected Overrides Function Editar() As Boolean
        Throw New NotImplementedException()
    End Function

    Protected Overrides Function Eliminar() As Boolean
        Throw New NotImplementedException()
    End Function

    Protected Overrides Function Insertar() As Boolean
        Dim Ret As Boolean = InsertarOdontologo()
        If Ret Then Horario.IdOdontologo.Valor = (New TablaOdontologo).ObtenerIdentityInsertado
        If Ret Then Ret = InsertarHorario()
        Return Ret
    End Function
    Private Function InsertarOdontologo() As Boolean
        Dim T As New TablaOdontologo(Conexion)
        T.EncapsularEnTransaccion = True
        Return T.Insertar(Odontologo)
    End Function
    Private Function InsertarHorario() As Boolean
        Dim T As New TablaHorario(Conexion)
        T.EncapsularEnTransaccion = True
        Return T.Insertar(Horario)
    End Function
End Class
