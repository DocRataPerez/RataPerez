Public Class DatosAdministracion
    Inherits Datos
    Public IdAdmin, Usuario, Contraseña As DatoBdD
    Public Overrides Sub Limpiar()
        IdAdmin.Limpiar()
        Usuario.Limpiar()
        Contraseña.Limpiar()
    End Sub

    Public Overrides Sub TomarEnCuentaTodo(TomarEnCuenta As Boolean)
        IdAdmin.TomarEnCuenta = True
        Usuario.TomarEnCuenta = True
        Contraseña.TomarEnCuenta = TomarEnCuenta
    End Sub

    Public Overrides Function Clone() As Object
        Dim Yo As New DatosAdministracion
        With Yo
            .IdAdmin = IdAdmin
            .Usuario = Usuario
            .Contraseña = Contraseña
        End With
        Return Yo
    End Function
End Class
