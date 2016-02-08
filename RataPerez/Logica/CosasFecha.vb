Public Class CosasFecha
    Public Shared Function NumeroDia(Dia As String) As Integer
        Select Case Dia.ToLower
            Case "l", "lunes" : Return 1
            Case "m", "martes" : Return 2
            Case "mi", "miercoles" : Return 3
            Case "j", "jueves" : Return 4
            Case "v", "viernes" : Return 5
            Case "s", "sabado" : Return 6
            Case "d", "domingo" : Return 7
        End Select
        Return -1
    End Function
    Public Shared Function QuitarCadenaIntervalos(IntervaloNuevo As String, Cadena As String) As String
        Cadena = Replace(Cadena, "-|", String.Empty)
        Cadena = Replace(Cadena, "|-", String.Empty)
        Dim Numeros, InicioIntervalos, NuevosIntervalos As New ArrayList
        Dim InicioIntervaloDesechado As Integer = Val(Split(IntervaloNuevo, "-")(0))
        For Each N As String In Split(IntervaloNuevo, "-")
            Numeros.Add(Val(N))
        Next
        Dim Intervalos() As String = Split(Cadena, "|")
        For Each Int As String In Intervalos
            For Each N As String In Split(Int, "-")
                If Not Numeros.Contains(Val(N)) Then Numeros.Add(Val(N))
            Next
        Next
        Dim FinalIntervaloNuevoEsInicioDeOtroIntervalo As Boolean = True
        For Each Int As String In Intervalos
            If Not InicioIntervalos.Contains(Val(Split(Int, "-")(0))) Then InicioIntervalos.Add(Val(Split(Int, "-")(0)))
            If Val(Split(Int, "-")(1)) = Val(Split(IntervaloNuevo, "-")(1)) Then FinalIntervaloNuevoEsInicioDeOtroIntervalo = False
        Next
        If FinalIntervaloNuevoEsInicioDeOtroIntervalo Then InicioIntervalos.Add(Val(Split(IntervaloNuevo, "-")(1)))
        Call Numeros.Sort()
        Call InicioIntervalos.Sort()
        For Each NI As Integer In InicioIntervalos
            For I As Integer = 0 To Numeros.Count - 1
                Dim N As Integer = Numeros(I)
                If NI = N And NI <> InicioIntervaloDesechado Then
                    If Numeros(I) <> Numeros(I + 1) Then NuevosIntervalos.Add({Numeros(I), Numeros(I + 1)})
                    Exit For
                End If
            Next
        Next
        Dim Ret As String = ""
        For I As Integer = 0 To NuevosIntervalos.Count - 1
            Ret &= NuevosIntervalos(I)(0) & "-" & NuevosIntervalos(I)(1)
            If I < NuevosIntervalos.Count - 1 Then Ret &= "|"
        Next
        Return Ret
    End Function
End Class
