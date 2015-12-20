<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmInicioSesion.aspx.vb" Inherits="RataPerez.frmRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 190px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="lblTitulo" runat="server" Text="Rata Perez - Iniciar sesión"></asp:Label>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server" Width="265px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtContraseña" runat="server" Width="264px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="cmdIniciarSesion" runat="server" Text="Iniciar sesión" />
                        <asp:Button ID="cmdRegistrarse" runat="server" Text="Registrarme" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
