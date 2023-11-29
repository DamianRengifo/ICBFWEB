<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ICBFWEB2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="bootstrap-5.2.3-dist/css/bootstrap.min.css" type="text/css"/>
</head>
<body>
    <div CssClass="h-100vh ">
        <form id="form1" runat="server">
        <div>
            <asp:Login ID="Login1" runat="server" CssClass="bg-success mx-auto" >
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <LoginButtonStyle CssClass="btn btn-light rounded-pill btn-outline-primary"/>
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            </asp:Login>
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Text="xd"></asp:Label>
        </div>
    </form>
    </div>

    <script src="bootstrap-5.2.3-dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
