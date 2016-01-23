Imports RataPerez

Public Class TablaHorario
    Inherits Tabla
    Public Sub New()
        NombreTabla = "Horario"
    End Sub
    Public Sub New(ByRef Con As ConexionSQL)
        MyBase.New(Con)
        NombreTabla = "Horario"
    End Sub
    Protected Overrides Sub IgualarDatos(ByRef Dts As Datos)
        If Dts Is Nothing Then Exit Sub
        Dim D As DatosHorario = Dts
        With SQLExe.Parameters
            .Clear()
            If D.IdHorario.TomarEnCuenta Then .AddWithValue("@IdHorario", D.IdHorario.Valor)
            If D.IdOdontologo.TomarEnCuenta Then .AddWithValue("@IdOdontologo", D.IdOdontologo.Valor)
            If D.Lunes.TomarEnCuenta Then .AddWithValue("@Lunes", D.Lunes.Valor)
            If D.Martes.TomarEnCuenta Then .AddWithValue("@Martes", D.Martes.Valor)
            If D.Miercoles.TomarEnCuenta Then .AddWithValue("@Miercoles", D.Miercoles.Valor)
            If D.Jueves.TomarEnCuenta Then .AddWithValue("@Jueves", D.Jueves.Valor)
            If D.Viernes.TomarEnCuenta Then .AddWithValue("@Viernes", D.Viernes.Valor)
            If D.Sabado.TomarEnCuenta Then .AddWithValue("@Sabado", D.Sabado.Valor)
            If D.Domingo.TomarEnCuenta Then .AddWithValue("@Domingo", D.Domingo.Valor)
        End With
    End Sub
    Public Overrides Function Editar(ByRef Dts As Datos) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Eliminar(ByRef Dts As Datos) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Insertar(ByRef Dts As Datos) As Boolean
        SQLExe.CommandText = "InsertarHorario"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return EjecutarCadSQL()
    End Function

    Public Overrides Function SeleccionarTodo(ByRef Optional Dts As Datos = Nothing) As DataTable
        Throw New NotImplementedException()
    End Function
End Class
