Imports RataPerez

Public Class TablaOdontologo
    Inherits Tabla
    Public Sub New()
        NombreTabla = "Odontologo"
    End Sub
    Public Sub New(ByRef Con As ConexionSQL)
        MyBase.New(Con)
        NombreTabla = "Odontologo"
    End Sub
    Protected Overrides Sub IgualarDatos(ByRef Dts As Datos)
        If Dts Is Nothing Then Exit Sub
        Dim D As DatosOdontologo = Dts
        With SQLExe.Parameters
            .Clear()
            If D.IdOdontologo.TomarEnCuenta Then .AddWithValue("@IdOdontologo", D.IdOdontologo.Valor)
            If D.Nombre.TomarEnCuenta Then .AddWithValue("@Nombre", D.Nombre.Valor)
            If D.Apelldo.TomarEnCuenta Then .AddWithValue("@Apelldo", D.Apelldo.Valor)
            If D.IdEspecialidad.TomarEnCuenta Then .AddWithValue("@IdEspecialidad", D.IdEspecialidad.Valor)
        End With
    End Sub

    Public Overrides Function Editar(ByRef Dts As Datos) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Eliminar(ByRef Dts As Datos) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Insertar(ByRef Dts As Datos) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function SeleccionarTodo(ByRef Optional Dts As Datos = Nothing) As DataTable
        Throw New NotImplementedException()
    End Function
    Public Function MostrarOdontologoEspecialidad(ByRef Dts As DatosOdontologo) As DataTable
        SQLExe.CommandText = "MostrarOdontologoEspecialidad"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return Mostrar()
    End Function
End Class
