<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmInicioSesion.aspx.vb" Inherits="RataPerez.frmRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ingreso al sistema - Rata Pérez</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet" integrity="sha256-7s5uDGW3AHqw6xtJmNNtr+OBRJUlgkNJEo78P4b0yRw= sha512-nNo+yCHEyn0smMxSswnf/OnX6/KwJuZTlNZBjauKhTK0c+zT+q5JOCx0UFhXQ6rJR9jg6Es8gPuD2uZcYDLqSw==" crossorigin="anonymous">
</head>
<body>
    <div class="container">
        <form id="form1" runat="server" class="form-horizontal">
            <div class="form-group">
                <div class="col-md-8 col-md-offset-2">
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="row">
                            <h1>
                                <asp:Label ID="lblTitulo" runat="server" Text="Rata Perez - Iniciar sesión"></asp:Label>
                            </h1>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-1 col-md-8">
                              <asp:TextBox ID="txtUsuario" runat="server" Width="265px" class="form-control" placeholder="Usuario"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-1 col-md-8">
                              <asp:TextBox ID="txtContraseña" runat="server" Width="264px" class="form-control" type="password" placeholder="Contraseña"></asp:TextBox>
                            </div>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>Usuario</asp:ListItem>
                                <asp:ListItem>Odontólogo</asp:ListItem>
                                <asp:ListItem>Administración</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <asp:Button ID="cmdIniciarSesion" runat="server" Text="Iniciar sesión" class="btn btn-default"/>
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="cmdRegistrarse" runat="server" Text="Registrarme" class="btn btn-default"/>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
