<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmReservaCita.aspx.vb" Inherits="RataPerez.frmReservaCita" %>

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
            width: 149px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="lblBienvenido" runat="server" Text="Reserva de citas:"></asp:Label>
            <asp:Label ID="lblIdOdontologo" runat="server" EnableTheming="True" Text="[id]" Visible="False"></asp:Label>
            <asp:Label ID="lblIdEspecialidad" runat="server" EnableTheming="True" Text="[id]" Visible="False"></asp:Label>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblEqPaciente" runat="server" EnableTheming="True" Text="Paciente:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCedulaPaciente" runat="server" Width="286px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblCita" runat="server" Text="Fecha:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbFecha" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="cmdConsultarHorarios" runat="server" Text="Consultar horarios" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblHorario" runat="server" Text="Horarios disponibles:"></asp:Label>
                    </td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="Gray" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="cmdReservar" runat="server" Text="Reservar" />
                        <asp:Label ID="lblEstado" runat="server" Text="Cita no reservada."></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
