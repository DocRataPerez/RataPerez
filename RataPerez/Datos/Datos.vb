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
End Class
