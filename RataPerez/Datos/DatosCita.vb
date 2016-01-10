Public Class DatosCita
    Inherits Datos
    Public IdCita, IdOdontologo, IdUsuario, Fecha, Hora As DatoBdD
    Public Overrides Sub Limpiar()
        IdCita.Limpiar()
        IdOdontologo.Limpiar()
        IdUsuario.Limpiar()
        Fecha.Limpiar()
        Hora.Limpiar()
    End Sub

    Public Overrides Sub TomarEnCuentaTodo(TomarEnCuenta As Boolean)
        IdCita.TomarEnCuenta = TomarEnCuenta
        IdOdontologo.TomarEnCuenta = TomarEnCuenta
        IdUsuario.TomarEnCuenta = TomarEnCuenta
        Fecha.TomarEnCuenta = TomarEnCuenta
        Hora.TomarEnCuenta = TomarEnCuenta
    End Sub

    Public Overrides Function Clone() As Object
        Dim Yo As New DatosCita
        With Yo
            .IdCita = IdCita
            .IdOdontologo = IdOdontologo
            .IdUsuario = IdUsuario
            .Fecha = Fecha
            .Hora = Hora
        End With
        Return Yo
    End Function
End Class
