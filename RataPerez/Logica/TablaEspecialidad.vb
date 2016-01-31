Imports RataPerez

Public Class TablaEspecialidad
    Inherits Tabla
    Public Sub New()
        NombreTabla = "Especialidad"
    End Sub
    Public Sub New(ByRef Con As ConexionSQL)
        MyBase.New(Con)
        NombreTabla = "Especialidad"
    End Sub
    Protected Overrides Sub IgualarDatos(ByRef Dts As Datos)
        If Dts Is Nothing Then Exit Sub
        Dim D As DatosEspecialidad = Dts
        With SQLExe.Parameters
            .Clear()
            If D.IdEspecialidad.TomarEnCuenta Then .AddWithValue("@IdEspecialidad", D.IdEspecialidad.Valor)
            If D.Especialidad.TomarEnCuenta Then .AddWithValue("@Especialidad", D.Especialidad.Valor)
        End With
    End Sub

    Public Overrides Function Editar(ByRef Dts As Datos) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Eliminar(ByRef Dts As Datos) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Insertar(ByRef Dts As Datos) As Boolean
        SQLExe.CommandText = "InsertarEspecialidad"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return EjecutarCadSQL()
    End Function

    Public Overrides Function SeleccionarTodo(ByRef Optional Dts As Datos = Nothing) As DataTable
        SQLExe.CommandText = "MostrarEspecialidad"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return Mostrar()
    End Function
    Public Function ExisteOdontologo(ByRef Dts As DatosEspecialidad) As Integer
        SQLExe.CommandText = "ExisteEspecialidad"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Dim T As DataTable = Mostrar()
        If T Is Nothing Then Return -1
        Return T.Rows(0).Item(0)
    End Function
End Class
