Imports RataPerez

Public Class TablaAdmin
    Inherits Tabla
    Public Sub New()
        NombreTabla = "Administracion"
    End Sub
    Public Sub New(ByRef Con As ConexionSQL)
        MyBase.New(Con)
        NombreTabla = "Administracion"
    End Sub
    Protected Overrides Sub IgualarDatos(ByRef Dts As Datos)
        If Dts Is Nothing Then Exit Sub
        Dim D As DatosAdministracion = Dts
        With SQLExe.Parameters
            .Clear()
            If D.IdAdmin.TomarEnCuenta Then .AddWithValue("@IdAdmin", D.IdAdmin.Valor)
            If D.Usuario.TomarEnCuenta Then .AddWithValue("@Usuario", D.Usuario.Valor)
            If D.Contraseña.TomarEnCuenta Then .AddWithValue("@Contraseña", D.Contraseña.Valor)
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
    Public Function IniciarSesion(ByRef Dts As DatosAdministracion) As Integer
        SQLExe.CommandText = "MostrarAdministracion"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Dim T As DataTable = Mostrar()
        If T Is Nothing Then Return -1 'Error
        If T.Rows.Count = 0 Then Return -1
        If Dts.Contraseña.Valor <> T.Rows(0).Item("Contraseña") Then Return 0
        Dts.IdAdmin.Valor = T.Rows(0).Item("IdAdmin")
        Dts.Usuario.Valor = T.Rows(0).Item("Usuario")
        Return 1
    End Function
End Class
