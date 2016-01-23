Public Class DatosOdontologo
    Inherits Datos
    Public IdOdontologo, Nombre, Apellido, IdEspecialidad As DatoBdD
    Public Overrides Sub Limpiar()
        IdOdontologo.Limpiar()
        Nombre.Limpiar()
        Apellido.Limpiar()
        IdEspecialidad.Limpiar()
    End Sub

    Public Overrides Sub TomarEnCuentaTodo(TomarEnCuenta As Boolean)
        IdOdontologo.TomarEnCuenta = TomarEnCuenta
        Nombre.TomarEnCuenta = TomarEnCuenta
        Apellido.TomarEnCuenta = TomarEnCuenta
        IdOdontologo.TomarEnCuenta = TomarEnCuenta
    End Sub

    Public Overrides Function Clone() As Object
        Dim Yo As New DatosOdontologo
        With Yo
            .IdOdontologo = IdOdontologo
            .Nombre = Nombre
            .Apellido = Apellido
            .IdEspecialidad = IdEspecialidad
        End With
        Return Yo
    End Function
End Class
