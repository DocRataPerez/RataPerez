Imports System.Net.Mail
Public Class Mensajero
    Private Servidor, Usuario, Contraseña As String
    Public Function enviarCorreo(Mensaje As String, Asunto As String, Destinatario As String)
        Call ObtenerCredenciales()
        Dim Ret As Boolean = True
        Try
            Dim Mail As New MailMessage
            Mail.From = New MailAddress("RataPerez@rataperez.somee.com")
            Mail.To.Add(Destinatario)
            Mail.Subject = Asunto
            Mail.Body = Mensaje
            Dim smtp As New SmtpClient(Servidor)
            smtp.Port = 25
            smtp.Credentials = New Net.NetworkCredential(Usuario, Contraseña)
            smtp.Send(Mail)
        Catch ex As Exception
            MsgBox(ex.Message)
            Ret = False
        End Try
        Return Ret
    End Function
    Private Sub ObtenerCredenciales()
        Dim sr As New IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory & "/cred.cr")
        Dim creds() As String = Split(sr.ReadToEnd(), "|")
        sr.Close()
        Servidor = creds(0).Trim
        Usuario = creds(1).Trim
        Contraseña = creds(2).Trim
    End Sub
End Class
