<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCambioContraseña.aspx.vb" Inherits="RataPerez.frmCambioContraseña" %>

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
            width: 238px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblEqTitulo" runat="server" Text="Cambie su contraseña"></asp:Label>
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblActual" runat="server" Text="Contraseña actual:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContraseñaActual" runat="server" Width="206px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblNueva" runat="server" Text="Contraseña nueva:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNuevaContraseña" runat="server" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblConfirmacion" runat="server" Text="Confirmación:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmacion" runat="server" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="cmdAceptar" runat="server" Text="Aceptar" style="height: 29px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Label ID="lblEstado" runat="server" Text="Ingrese su contraseña actual y la nueva contraseña."></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
