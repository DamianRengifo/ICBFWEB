<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelAdmin.aspx.cs" Inherits="ICBFWEB2.PanelAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="bootstrap-5.2.3-dist/css/bootstrap.min.css" type="text/css"/>
    <title>Panel de administración</title>
</head>
<body>
        <div class="container">
        <div class="row d-flex align-items-center justify-content-center">
            <h1 class="text-center">Bienvenido <asp:Label ID="lblUser" runat="server" Text=""></asp:Label></h1>
        </div>
    </div>
    <div class="container">
    <div class="row d-flex align-items-center justify-content-center mt-5">
        <h1 class="text-center">¿A dónde desea ir?</h1>
    </div>
    <form class="row d-flex align-items-center justify-content-around mt-5" runat="server">
        <div class="col-4 text-center">
            <asp:Button ID="btnIrAUsuarios" runat="server" Text="Usuarios" CssClass="btn btn-success btn-lg"/>
        </div>
        <div class="col-4 text-center">
            <asp:Button ID="btnIrAJardines" runat="server" Text="Jardines" CssClass="btn btn-success btn-lg" OnClick="btnIrAJardines_Click"/>
        </div>
        <div class="col-4 text-center">
            <asp:Button ID="btnIrANiños" runat="server" Text="Niños" CssClass="btn btn-success btn-lg" OnClick="btnIrANiños_Click"/>
        </div>
    </form>
</div>

    <script src="bootstrap-5.2.3-dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
