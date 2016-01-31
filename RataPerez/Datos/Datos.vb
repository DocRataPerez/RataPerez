Public MustInherit Class Datos
    Implements ICloneable
    Public Structure DatoBdD
        Public TomarEnCuenta As Boolean
        Private _Valor As Object
        Public Property Valor As Object
            Get
                Dim Ret As Object = Nothing
                Select Case _Valor Is Nothing
                    Case False : Ret = _Valor
                    Case True : Ret = DBNull.Value
                End Select
                Return Ret
            End Get
            Set(value As Object)
                _Valor = value
                TomarEnCuenta = True
            End Set
        End Property
        Public Sub Limpiar()
            _Valor = Nothing
            TomarEnCuenta = False
        End Sub
    End Structure
    Public MustOverride Sub Limpiar()
    Public Shared Function CalcularMD5(ByVal Cadena As String) As String
        Dim Cif As New Security.Cryptography.MD5CryptoServiceProvider()
        Dim BytesAHash() As Byte = Text.Encoding.ASCII.GetBytes(Cadena)
        BytesAHash = Cif.ComputeHash(BytesAHash)
        Dim Ret As String = ""
        For Each B As Byte In BytesAHash
            Ret &= B.ToString("x2")
        Next
        Return Ret
    End Function

    Public MustOverride Function Clone() As Object Implements ICloneable.Clone
    Public MustOverride Sub TomarEnCuentaTodo(TomarEnCuenta As Boolean)
    Public Shared Function GenerarCadenaAleatoria(Tamaño As Integer) As String
        Dim Contraseña As String = ""
        Dim R As New Random(Date.Now.Ticks And Integer.MaxValue)
        For I As Integer = 1 To Tamaño
            Contraseña &= Chr(R.Next(64, 90))
        Next
        Contraseña = Regex.Replace(Contraseña, "\.|;\@\,\?", String.Empty)
        Return Contraseña
    End Function
End Class
