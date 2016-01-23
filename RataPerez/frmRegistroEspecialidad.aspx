<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRegistroEspecialidad.aspx.vb" Inherits="RataPerez.frmRegistroEspecialidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Nueva especialidad"></asp:Label>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Ttítulo"></asp:Label>
                        :</td>
                    <td>
                        <asp:TextBox ID="txtTitulo" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" />
                        <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lblEstado" runat="server" Text="Haga clic en 'Guardar' para registrar la especialidad."></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    <div>
    
    </div>
    </form>
</body>
</html>
