Public Class DatosUsuario
    Inherits Datos
    Public IdUsuario, Nombre, Contraseña, Cedula, Celular, Telefono, Direccion, Correo, FechaNace As DatoBdD
    Public Overrides Sub Limpiar()
        IdUsuario.Limpiar()
        Nombre.Limpiar()
        Contraseña.Limpiar()
        Cedula.Limpiar()
        Celular.Limpiar()
        Telefono.Limpiar()
        Direccion.Limpiar()
        Correo.Limpiar()
        FechaNace.Limpiar()
    End Sub

    Public Overrides Sub TomarEnCuentaTodo(TomarEnCuenta As Boolean)
        IdUsuario.TomarEnCuenta = TomarEnCuenta
        Nombre.TomarEnCuenta = TomarEnCuenta
        Contraseña.TomarEnCuenta = TomarEnCuenta
        Cedula.TomarEnCuenta = TomarEnCuenta
        Celular.TomarEnCuenta = TomarEnCuenta
        Telefono.TomarEnCuenta = TomarEnCuenta
        Direccion.TomarEnCuenta = TomarEnCuenta
        Correo.TomarEnCuenta = TomarEnCuenta
        FechaNace.TomarEnCuenta = TomarEnCuenta
    End Sub

    Public Overrides Function Clone() As Object
        Dim Yo As New DatosUsuario
        Yo.Contraseña = Contraseña
        Yo.Nombre = Nombre
        Yo.IdUsuario = IdUsuario
        Yo.Cedula = Cedula
        Yo.Celular = Celular
        Yo.Telefono = Telefono
        Yo.Direccion = Direccion
        Yo.Correo = Correo
        Yo.FechaNace = FechaNace
        Return Yo
    End Function
End Class
