Public Class DatosOdontologo
    Inherits Datos
    Public IdOdontologo, Nombre, Apelldo, IdEspecialidad As DatoBdD
    Public Overrides Sub Limpiar()
        IdOdontologo.Limpiar()
        Nombre.Limpiar()
        Apelldo.Limpiar()
        IdEspecialidad.Limpiar()
    End Sub

    Public Overrides Sub TomarEnCuentaTodo(TomarEnCuenta As Boolean)
        IdOdontologo.TomarEnCuenta = TomarEnCuenta
        Nombre.TomarEnCuenta = TomarEnCuenta
        Apelldo.TomarEnCuenta = TomarEnCuenta
        IdOdontologo.TomarEnCuenta = TomarEnCuenta
    End Sub

    Public Overrides Function Clone() As Object
        Dim Yo As New DatosOdontologo
        With Yo
            .IdOdontologo = IdOdontologo
            .Nombre = Nombre
            .Apelldo = Apelldo
            .IdEspecialidad = IdEspecialidad
        End With
        Return Yo
    End Function
End Class
