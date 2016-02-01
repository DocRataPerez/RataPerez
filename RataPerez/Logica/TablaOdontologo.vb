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
            If D.Apellido.TomarEnCuenta Then .AddWithValue("@Apellido", D.Apellido.Valor)
            If D.IdEspecialidad.TomarEnCuenta Then .AddWithValue("@IdEspecialidad", D.IdEspecialidad.Valor)
            If D.Cedula.TomarEnCuenta Then .AddWithValue("@Cedula", D.Cedula.Valor)
            If D.Contraseña.TomarEnCuenta Then .AddWithValue("@Contraseña", D.Contraseña.Valor)
            If D.PrimerInicio.TomarEnCuenta Then .AddWithValue("@PrimerInicio", D.PrimerInicio.Valor)
            If D.Correo.TomarEnCuenta Then .AddWithValue("@Correo", D.Correo.Valor)
        End With
    End Sub

    Public Overrides Function Editar(ByRef Dts As Datos) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Eliminar(ByRef Dts As Datos) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Insertar(ByRef Dts As Datos) As Boolean
        SQLExe.CommandText = "InsertarOdontologo"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return EjecutarCadSQL()
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
    Public Function ExisteOdontologo(ByRef Dts As DatosOdontologo) As Integer
        SQLExe.CommandText = "ExisteOdontologo"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Dim T As DataTable = Mostrar()
        If T Is Nothing Then Return -1
        Return T.Rows(0).Item(0)
    End Function
    Public Function IniciarSesion(ByRef Dts As DatosOdontologo) As Integer
        SQLExe.CommandText = "IniciarSesionOdontologo"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Dim T As DataTable = Mostrar()
        If T Is Nothing Then Return -1 'Error
        If T.Rows.Count = 0 Then Return -1
        If Dts.Contraseña.Valor <> T.Rows(0).Item("Contraseña") Then Return 0
        Dts.IdOdontologo.Valor = T.Rows(0).Item("IdOdontologo")
        Dts.Nombre.Valor = T.Rows(0).Item("Nombre")
        Dts.Apellido.Valor = T.Rows(0).Item("Apellido")
        Dts.PrimerInicio.Valor = CBool(T.Rows(0).Item("PrimerInicio"))
        Return 1
    End Function
    Public Function CambiarContraseña(ByRef Dts As DatosOdontologo) As Boolean
        SQLExe.CommandText = "CambiarContraseñaOdontologo"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return EjecutarCadSQL()
    End Function
    Public Function CambiarPrimeraSesion(ByRef Dts As DatosOdontologo) As Boolean
        SQLExe.CommandText = "CambiarPrimeraSesionOdontologo"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return EjecutarCadSQL()
    End Function
    Public Function CorreoRegistrado(ByRef Dts As DatosOdontologo) As Integer
        SQLExe.CommandText = "CorreoRegistradoOdontologo"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Dim T As DataTable = Mostrar()
        If T Is Nothing Then Return -1 'Error
        Return Val(T.Rows(0).Item(0))
    End Function
    Public Function MostrarCitasPendientes(ByRef Dts As DatosOdontologo) As DataTable
        SQLExe.CommandText = "MostrarCitasPendientesOdontologo"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return Mostrar()
    End Function
    Public Function UsuarioCedula(ByRef Dts As DatosOdontologo) As DataTable
        SQLExe.CommandText = "OdontologoCedula"
        SQLExe.CommandType = CommandType.StoredProcedure
        Call IgualarDatos(Dts)
        Return Mostrar()
    End Function
End Class
