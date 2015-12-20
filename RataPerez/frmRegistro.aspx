<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRegistro.aspx.vb" Inherits="RataPerez.frmRegistro1" %>

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
            width: 285px;
        }
        .auto-style3 {
            width: 285px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Registrarse"></asp:Label>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblNombreCompleto" runat="server" Text="*Nombre completo:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" Width="285px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblCedula" runat="server" Text="*Cédula"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCedula" runat="server" Width="285px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblTelfFijo" runat="server" Text="*Teléfono fijo:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtTelfFijo" runat="server" Width="285px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblTelfMovil" runat="server" Text="Teléfono móvil:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelfMovil" runat="server" Width="285px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblDireccion" runat="server" Text="*Dirección:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDireccion" runat="server" Width="285px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblCorreo" runat="server" Text="Correo electrónico:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCorreo" runat="server" Width="285px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblFechaNace" runat="server" Text="*Fecha de nacimiento:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDia" runat="server" Text="Día:"></asp:Label>
                        <asp:TextBox ID="txtDia" runat="server" Width="95px"></asp:TextBox>
                        <asp:Label ID="lblMes" runat="server" Text="Mes:"></asp:Label>
                        <asp:DropDownList ID="cmbMes" runat="server">
                            <asp:ListItem Value="1">enero</asp:ListItem>
                            <asp:ListItem Value="2">febrero</asp:ListItem>
                            <asp:ListItem Value="3">marzo</asp:ListItem>
                            <asp:ListItem Value="4">abril</asp:ListItem>
                            <asp:ListItem Value="5">mayo</asp:ListItem>
                            <asp:ListItem Value="6">junio</asp:ListItem>
                            <asp:ListItem Value="7">julio</asp:ListItem>
                            <asp:ListItem Value="8">agosto</asp:ListItem>
                            <asp:ListItem Value="9">septiembre</asp:ListItem>
                            <asp:ListItem Value="10">octubre</asp:ListItem>
                            <asp:ListItem Value="11">noviembre</asp:ListItem>
                            <asp:ListItem Value="12">diciembre</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblAño" runat="server" Text="Año:"></asp:Label>
                        <asp:TextBox ID="txtAño" runat="server" Width="95px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblContraseña" runat="server" Text="*Contraseña:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtContraseña" runat="server" Width="285px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="cmdRegistrar" runat="server" Text="Registrarme" />
                        <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Label ID="lblEstado" runat="server" Text="Los campos marcados con * son obligatorios."></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
