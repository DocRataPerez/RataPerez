<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRegistroOdontologo.aspx.vb" Inherits="RataPerez.frmRegistroOdontologo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 69%;
        }
        .auto-style4 {
            width: 124px;
        }
        .auto-style6 {
            width: 252px;
        }
        .auto-style8 {
            width: 107px;
            height: 29px;
        }
        .auto-style12 {
            width: 107px;
        }
        .auto-style13 {
            width: 97px;
        }
        .auto-style14 {
            width: 97px;
            height: 29px;
        }
        .auto-style15 {
            width: 206px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Registro de odontólogo"></asp:Label>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" Width="275px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label3" runat="server" Text="Apellido:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtApellido" runat="server" Width="275px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label4" runat="server" Text="Especialidad:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbEspecialidad" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="cmbIdEspecialidad" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label5" runat="server" Text="Horario:"></asp:Label>
                    </td>
                    <td>
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style6">
                                    <asp:Label ID="Label6" runat="server" Text="Día"></asp:Label>
                                </td>
                                <td class="auto-style15">
                                    <asp:Label ID="Label7" runat="server" Text="Período 1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Período 2"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <asp:CheckBox ID="chkLunes" runat="server" Text="Lunes"/>
                                </td>
                                <td class="auto-style15">
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label9" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label10" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="l1i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="l1f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label11" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label12" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="l2i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="l2f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <asp:CheckBox ID="chkMartes" runat="server" Text="Martes" />
                                </td>
                                <td class="auto-style15">
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label13" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label14" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="m1i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="m1f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label35" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label36" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="m2i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="m2f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <asp:CheckBox ID="chkMiercoles" runat="server" Text="Miércoles" />
                                </td>
                                <td class="auto-style15">
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label15" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label16" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="mm1i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="mm1f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label33" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label34" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="mm2i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="mm2f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <asp:CheckBox ID="chkJueves" runat="server" Text="Jueves" />
                                </td>
                                <td class="auto-style15">
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label17" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label18" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="j1i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="j1f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label31" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label32" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="j2i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="j2f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <asp:CheckBox ID="chkViernes" runat="server" Text="Viernes" />
                                </td>
                                <td class="auto-style15">
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label19" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label20" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="v1i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="v1f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label29" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label30" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="v2i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="v2f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <asp:CheckBox ID="chkSabado" runat="server" Text="Sábado" />
                                </td>
                                <td class="auto-style15">
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label21" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label22" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="s1i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="s1f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label27" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label28" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="s2i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="s2f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <asp:CheckBox ID="chkDomingo" runat="server" Text="Domingo" />
                                </td>
                                <td class="auto-style15">
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label23" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label24" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="d1i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="d1f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:Label ID="Label25" runat="server" Text="Inicio"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:Label ID="Label26" runat="server" Text="Fin"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style8">
                                                <asp:TextBox ID="d2i" runat="server" Width="105px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style14">
                                                <asp:TextBox ID="d2f" runat="server" Width="104px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                        <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" />
                        <asp:Button ID="cmdCancelar" runat="server" Text="Canelar" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                        <asp:Label ID="lblEstado" runat="server" Text="Haga clic en 'Guardar' para registrar al odontólogo."></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    <div>
    
    </div>
    </form>
</body>
</html>
