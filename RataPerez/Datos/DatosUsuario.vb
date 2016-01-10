Public Class DatosUsuario
    Inherits Datos
    Public IdUsuario, Nombre, Contraseña, Cedula, Celular, Telefono, Direccion, Correo, FechaNace, PrimerInicio As DatoBdD
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
        PrimerInicio.Limpiar()
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
        PrimerInicio.TomarEnCuenta = TomarEnCuenta
    End Sub

    Public Overrides Function Clone() As Object
        Dim Yo As New DatosUsuario
        With Yo
            .Contraseña = Contraseña
            .Nombre = Nombre
            .IdUsuario = IdUsuario
            .Cedula = Cedula
            .Celular = Celular
            .Telefono = Telefono
            .Direccion = Direccion
            .Correo = Correo
            .FechaNace = FechaNace
            .PrimerInicio = PrimerInicio
        End With
        Return Yo
    End Function
    Public Function CedulaBien() As Boolean
        If Cedula.Valor = Nothing Then Return False
        If CStr(Cedula.Valor).Length <> 10 Then Return False
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
    Public Shared Function GenerarContraseñaAleatoria(Tamaño As Integer) As String
        Dim Contraseña As String = ""
        Dim R As New Random(Date.Now.Ticks And Integer.MaxValue)
        For I As Integer = 1 To Tamaño
            Contraseña &= Chr(R.Next(64, 90))
        Next
        Contraseña = Regex.Replace(Contraseña, "\.|;\@\,\?", String.Empty)
        Return Contraseña
    End Function
End Class
