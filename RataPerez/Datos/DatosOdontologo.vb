Public Class DatosOdontologo
    Inherits Datos
    Public IdOdontologo, Cedula, Nombre, Apellido, IdEspecialidad, Contraseña, PrimerInicio As DatoBdD
    Public Overrides Sub Limpiar()
        IdOdontologo.Limpiar()
        Nombre.Limpiar()
        Apellido.Limpiar()
        IdEspecialidad.Limpiar()
        Cedula.Limpiar()
        Contraseña.Limpiar()
        PrimerInicio.Limpiar()
    End Sub

    Public Overrides Sub TomarEnCuentaTodo(TomarEnCuenta As Boolean)
        IdOdontologo.TomarEnCuenta = TomarEnCuenta
        Nombre.TomarEnCuenta = TomarEnCuenta
        Apellido.TomarEnCuenta = TomarEnCuenta
        IdOdontologo.TomarEnCuenta = TomarEnCuenta
        Cedula.TomarEnCuenta = TomarEnCuenta
        Contraseña.TomarEnCuenta = TomarEnCuenta
        PrimerInicio.TomarEnCuenta = TomarEnCuenta
    End Sub

    Public Overrides Function Clone() As Object
        Dim Yo As New DatosOdontologo
        With Yo
            .IdOdontologo = IdOdontologo
            .Nombre = Nombre
            .Apellido = Apellido
            .IdEspecialidad = IdEspecialidad
            .Cedula = Cedula
            .Contraseña = Contraseña
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
End Class
