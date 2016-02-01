Public Class TablaUsuario
    Inherits Tabla
    Public Sub New()
        NombreTabla = "Usuario"
    End Sub
    Public Sub New(ByRef Con As ConexionSQL)
        MyBase.New(Con)
        NombreTabla = "Usuario"
    End Sub
    Protected Overrides Sub IgualarDatos(ByRef Dts As Datos)
        If Dts Is Nothing Then Exit Sub
        Dim D As DatosUsuario = Dts
        With SQLExe.Parameters
            .Clear()
            If D.IdUsuario.TomarEnCuenta Then .AddWithValue("@IdUsuario", D.IdUsuario.Valor)
            If D.Nombre.TomarEnCuenta Then .AddWithValue("@Nombre", D.Nombre.Valor)
            If D.Contraseña.TomarEnCuenta Then .AddWithValue("@Contraseña", D.Contraseña.Valor)
            If D.Cedula.TomarEnCuenta Then .AddWithValue("@Cedula", D.Cedula.Valor)
            If D.Celular.TomarEnCuenta Then .AddWithValue("@Celular", D.Celular.Valor)
            If D.Telefono.TomarEnCuenta Then .AddWithValue("@Telefono", D.Telefono.Valor)
            If D.Direccion.TomarEnCuenta Then .AddWithValue("@Direccion", D.Direccion.Valor)
            If D.Correo.TomarEnCuenta Then .AddWithValue("@Correo", D.Correo.Valor)
            If D.FechaNace.TomarEnCuenta Then .AddWithValue("@FechaNace", D.FechaNace.Valor)
            If D.PrimerInicio.TomarEnCuenta Then .AddWithValue("@primera_sesion", D.PrimerInicio.Valor)
        End With
    End Sub

    Public Overrides Function Editar(ByRef Dts As Datos) As Boolean
        SQLExe.CommandText = "ActualizarUsuario"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return EjecutarCadSQL()
    End Function

    Public Overrides Function Eliminar(ByRef Dts As Datos) As Boolean
        SQLExe.CommandText = "EliminarUsuario"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return EjecutarCadSQL()
    End Function

    Public Overrides Function Insertar(ByRef Dts As Datos) As Boolean
        SQLExe.CommandText = "InsertarUsuario"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return EjecutarCadSQL()
    End Function

    Public Overrides Function SeleccionarTodo(ByRef Optional Dts As Datos = Nothing) As DataTable
        SQLExe.CommandText = "MostrarUsuario"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return Mostrar()
    End Function
    Public Function ExisteUsuario(ByRef Dts As Datos) As Integer
        SQLExe.CommandText = "ExisteUsuario"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Dim T As DataTable = Mostrar()
        If T Is Nothing Then Return -1 'Error
        Return Val(T.Rows(0).Item(0))
    End Function
    Public Function IniciarSesion(ByRef Dts As DatosUsuario) As Integer
        SQLExe.CommandText = "IniciarSesion"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Dim T As DataTable = Mostrar()
        If T Is Nothing Then Return -1 'Error
        If T.Rows.Count = 0 Then Return -1
        If Dts.Contraseña.Valor <> T.Rows(0).Item("Contraseña") Then Return 0
        Dts.IdUsuario.Valor = T.Rows(0).Item("IdUsuario")
        Dts.Nombre.Valor = T.Rows(0).Item("Nombre")
        Dts.PrimerInicio.Valor = CBool(T.Rows(0).Item("primera_sesion"))
        Return 1
    End Function
    Public Function CorreoRegistrado(ByRef Dts As DatosUsuario) As Integer
        SQLExe.CommandText = "CorreoRegistrado"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Dim T As DataTable = Mostrar()
        If T Is Nothing Then Return -1 'Error
        Return Val(T.Rows(0).Item(0))
    End Function
    Public Function CambiarContraseña(ByRef Dts As DatosUsuario) As Boolean
        SQLExe.CommandText = "CambiarContraseña"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return EjecutarCadSQL()
    End Function
    Public Function CambiarPrimeraSesion(ByRef Dts As DatosUsuario) As Boolean
        SQLExe.CommandText = "CambiarPrimeraSesion"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return EjecutarCadSQL()
    End Function
    Public Function UsuarioCedula(ByRef Dts As DatosUsuario) As DataTable
        SQLExe.CommandText = "UsuarioCedula"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return Mostrar()
    End Function
    Public Function MostrarCitasPendientes(ByRef Dts As DatosUsuario) As DataTable
        SQLExe.CommandText = "MostrarCitasPendientes"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return Mostrar()
    End Function
End Class
