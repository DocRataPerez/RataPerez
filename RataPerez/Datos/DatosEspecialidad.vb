Public Class DatosEspecialidad
    Inherits Datos
    Public IdEspecialidad, Especialidad As DatoBdD
    Public Overrides Sub Limpiar()
        IdEspecialidad.Limpiar()
        Especialidad.Limpiar()
    End Sub

    Public Overrides Sub TomarEnCuentaTodo(TomarEnCuenta As Boolean)
        IdEspecialidad.TomarEnCuenta = TomarEnCuenta
        Especialidad.TomarEnCuenta = TomarEnCuenta
    End Sub

    Public Overrides Function Clone() As Object
        Dim Yo As New DatosEspecialidad
        With Yo
            .IdEspecialidad = IdEspecialidad
            .Especialidad = Especialidad
        End With
        Return Yo
    End Function
End Class
