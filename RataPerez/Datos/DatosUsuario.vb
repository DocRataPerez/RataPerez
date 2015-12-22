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
    Public Function CedulaBien() As Boolean
        If Cedula.Valor.lenght <> 10 Then Return False
        Dim UltimoDigito As Integer = 0
        Dim Suma As Integer = 0
        For I As Integer = 1 To 9
            Dim A As Integer = Val(Mid(Cedula.Valor, I, 1)) * ((I Mod 2) + 1)
            If A >= 10 Then A -= 9
            Suma += A
        Next
        If Suma Mod 10 <> 0 Then UltimoDigito = 10 - Suma Mod 10
        Return Val(Mid(Cedula.Valor, 10, 1)) = UltimoDigito
    End Function
End Class
