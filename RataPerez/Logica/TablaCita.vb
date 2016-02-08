Imports RataPerez

Public Class TablaCita
    Inherits Tabla
    Public Sub New()
        NombreTabla = "Cita"
    End Sub
    Public Sub New(ByRef Con As ConexionSQL)
        MyBase.New(Con)
        NombreTabla = "Cita"
    End Sub
    Protected Overrides Sub IgualarDatos(ByRef Dts As Datos)
        If Dts Is Nothing Then Exit Sub
        Dim D As DatosCita = Dts
        With SQLExe.Parameters
            .Clear()
            If D.IdCita.TomarEnCuenta Then .AddWithValue("@IdCita", D.IdCita.Valor)
            If D.IdOdontologo.TomarEnCuenta Then .AddWithValue("@IdOdontologo", D.IdOdontologo.Valor)
            If D.IdUsuario.TomarEnCuenta Then .AddWithValue("@IdUsuario", D.IdUsuario.Valor)
            If D.Hora.TomarEnCuenta Then .AddWithValue("@Hora", D.Hora.Valor)
            If D.Fecha.TomarEnCuenta Then .AddWithValue("@Fecha", D.Fecha.Valor)
        End With
    End Sub

    Public Overrides Function Editar(ByRef Dts As Datos) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Eliminar(ByRef Dts As Datos) As Boolean
        SQLExe.CommandText = "EliminarCita"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return EjecutarCadSQL()
    End Function

    Public Overrides Function Insertar(ByRef Dts As Datos) As Boolean
        SQLExe.CommandText = "InsertarCita"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return EjecutarCadSQL()
    End Function

    Public Overrides Function SeleccionarTodo(ByRef Optional Dts As Datos = Nothing) As DataTable
        Throw New NotImplementedException()
    End Function
    Public Function HorarioOcupado(ByRef Dts As DatosCita) As DataTable
        SQLExe.CommandText = "HorarioOcupado"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return Mostrar()
    End Function
    Public Function CitasEnPeriodoDeFecha(ByRef Dts As DatosCita, FechaDesde As Date, FechaHasta As Date) As DataTable
        SQLExe.CommandText = "CitasEnPeriodoDeFecha"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        With SQLExe.Parameters
            .AddWithValue("@FechaDesde", FechaDesde)
            .AddWithValue("@FechaHasta", FechaHasta)
        End With
        Return Mostrar()
    End Function
End Class
