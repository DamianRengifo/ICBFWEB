<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ICBFWEB2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="bootstrap-5.2.3-dist/css/bootstrap.min.css" type="text/css"/>
</head>
<body>
    <div class="vh-100 vw-100 d-flex-column align-items-center justify-content-center">
        <div class="rounded-3 bg-success w-25 mx-auto my-5 shadow-lg">
            <form id="form1" runat="server" class="my-3">
                <div class="h-50 mx-auto gap-2 h-50 w-100 d-flex flex-column align-align-items-center justify-content-center">
                    <div class="bg-light rounded-3 text-center w-100">
                        <h1 class="text-success fw-bold">Iniciar Sesion</h1>
                    </div>
                    <asp:Label ID="Label1" runat="server" Text="Identificacion: " CssClass="text-center mx-auto fs-3 text-light"></asp:Label>
                    <asp:TextBox ID="Username" runat="server" CssClass="form-control w-75 mx-auto mb-3"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="Contraseña:"  CssClass="text-center mx-auto fs-3 text-light"></asp:Label>
                    <asp:TextBox ID="Password" runat="server" CssClass="form-control w-75 mx-auto mb-2" type="password"></asp:TextBox>
                    <br/>
                    <asp:Button ID="btnIniciar" runat="server" Text="Button" CssClass="btn btn-light btn-outline-primary mx-auto rounded-pill w-75 mb-3 fs-3" OnClick="btnIniciar_Click" />
                   
                </div>
            </form>
        </div>
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Text=""></asp:Label>
    </div>

    <script src="bootstrap-5.2.3-dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
