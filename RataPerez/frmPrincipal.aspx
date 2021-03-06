﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmPrincipal.aspx.vb" Inherits="RataPerez.frmPrincipal" %>

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
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblEqPaciente" runat="server" Text="Paciente:" EnableTheming="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPaciente" runat="server" EnableTheming="True" Text="[paciente]"></asp:Label>
                        <asp:Label ID="lblIdUsuario" runat="server" EnableTheming="True" Text="[id]" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblBienvenido0" runat="server" Text="Especialidad:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbEspecialidad" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="cmdConsultarOdontologo" runat="server" Text="Consultar" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblOdontologo" runat="server" Text="Odontologo:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbOdontologo" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="cmbIdOdontologo" runat="server" Visible="False">
                        </asp:DropDownList>
                        <asp:Button ID="cmdConsultarDisponibilidad" runat="server" Text="Consultar disponibilidad" />
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
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateSelectButton="True">
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
