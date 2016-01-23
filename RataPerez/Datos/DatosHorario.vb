Public Class DatosHorario
    Inherits Datos
    Public IdHorario, IdOdontologo, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo As DatoBdD
    Public Overrides Sub Limpiar()
        IdHorario.Limpiar()
        IdOdontologo.Limpiar()
        Lunes.Limpiar()
        Martes.Limpiar()
        Miercoles.Limpiar()
        Jueves.Limpiar()
        Viernes.Limpiar()
        Sabado.Limpiar()
        Domingo.Limpiar()
    End Sub

    Public Overrides Sub TomarEnCuentaTodo(TomarEnCuenta As Boolean)
        IdHorario.TomarEnCuenta = TomarEnCuenta
        IdOdontologo.TomarEnCuenta = TomarEnCuenta
        Lunes.TomarEnCuenta = TomarEnCuenta
        Martes.TomarEnCuenta = TomarEnCuenta
        Miercoles.TomarEnCuenta = TomarEnCuenta
        Jueves.TomarEnCuenta = TomarEnCuenta
        Viernes.TomarEnCuenta = TomarEnCuenta
        Sabado.TomarEnCuenta = TomarEnCuenta
        Domingo.TomarEnCuenta = TomarEnCuenta
    End Sub

    Public Overrides Function Clone() As Object
        Dim Yo As New DatosHorario
        With Yo
            .IdHorario = IdHorario
            .IdOdontologo = IdOdontologo
            .Lunes = Lunes
            .Martes = Martes
            .Miercoles = Miercoles
            .Jueves = Jueves
            .Viernes = Viernes
            .Sabado = Sabado
            .Domingo = Domingo
        End With
        Return Yo
    End Function
End Class
