<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRegistro.aspx.vb" Inherits="RataPerez.frmRegistro1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro - Rata Pérez</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet" integrity="sha256-7s5uDGW3AHqw6xtJmNNtr+OBRJUlgkNJEo78P4b0yRw= sha512-nNo+yCHEyn0smMxSswnf/OnX6/KwJuZTlNZBjauKhTK0c+zT+q5JOCx0UFhXQ6rJR9jg6Es8gPuD2uZcYDLqSw==" crossorigin="anonymous">
</head>
<body>
    <div class="container">
        <form id="form1" runat="server" class="form-horizontal">
            <asp:Panel ID="Panel1" runat="server">
                <h1>
                    <asp:Label ID="Label1" runat="server" Text="Registrarse"></asp:Label>
                </h1>
                <div class="form-group">
                    <asp:Label ID="lblNombreCompleto" runat="server" Text="*Nombre completo:"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" Width="285px" class="form-control" placeholder="Nombre"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCedula" runat="server" Text="*Cédula"></asp:Label>
                    <asp:TextBox ID="txtCedula" runat="server" Width="285px"  class="form-control" placeholder="Cédula"></asp:TextBox>
                </div>
                <div class="form-group">        
                    <asp:Label ID="lblTelfFijo" runat="server" Text="*Teléfono fijo:"></asp:Label>
                    <asp:TextBox ID="txtTelfFijo" runat="server" Width="285px" class="form-control" placeholder="Teléfono fijo"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblTelfMovil" runat="server" Text="Teléfono móvil:"></asp:Label>
                    <asp:TextBox ID="txtTelfMovil" runat="server" Width="285px" class="form-control" placeholder="Teléfono móvil"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblDireccion" runat="server" Text="*Dirección:"></asp:Label>
                    <asp:TextBox ID="txtDireccion" runat="server" Width="285px" class="form-control" placeholder="Dirección"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCorreo" runat="server" Text="Correo electrónico:"></asp:Label>
                    <asp:TextBox ID="txtCorreo" runat="server" Width="285px" class="form-control" type="email"  placeholder="Email"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:Label ID="lblFechaNace" runat="server" Text="*Fecha de nacimiento:"></asp:Label>
                </div>
                <div class="form-group">
                    <div class="col-md-2">                        
                        <asp:Label ID="lblDia" runat="server" Text="Día:"></asp:Label>
                        <asp:TextBox ID="txtDia" runat="server" Width="95px" class="form-control" placeholder="Día"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <div class="row">
                            <asp:Label ID="lblMes" runat="server" Text="Mes:"></asp:Label>
                        </div>
                        <div class="row">
                            <asp:DropDownList ID="cmbMes" runat="server">
                                <asp:ListItem Value="1">Enero</asp:ListItem>
                                <asp:ListItem Value="2">Febrero</asp:ListItem>
                                <asp:ListItem Value="3">Marzo</asp:ListItem>
                                <asp:ListItem Value="4">Abril</asp:ListItem>
                                <asp:ListItem Value="5">Mayo</asp:ListItem>
                                <asp:ListItem Value="6">Junio</asp:ListItem>
                                <asp:ListItem Value="7">Julio</asp:ListItem>
                                <asp:ListItem Value="8">Agosto</asp:ListItem>
                                <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                <asp:ListItem Value="10">Octubre</asp:ListItem>
                                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lblAño" runat="server" Text="Año:"></asp:Label>
                        <asp:TextBox ID="txtAño" runat="server" Width="95px" class="form-control" placeholder="Año"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                      <asp:Label ID="lblContraseña" runat="server" Text="*Contraseña:"></asp:Label>
                      <asp:TextBox ID="txtContraseña" runat="server" Width="285px" type="password" class="form-control" placeholder="Contraseña"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="cmdRegistrar" runat="server" Text="Registrarme" class="btn btn-default"/>
                    <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" class="btn btn-default"/>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblEstado" runat="server" Text="Los campos marcados con * son obligatorios."></asp:Label>
                </div>
            </asp:Panel>
        </form>
    </div>
</body>
</html>
