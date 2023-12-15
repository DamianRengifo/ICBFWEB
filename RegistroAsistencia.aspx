<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroAsistencia.aspx.cs" Inherits="ICBFWEB2.RegistroAsistencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de asistencia</title>
<link rel="stylesheet" href="bootstrap-5.2.3-dist/css/bootstrap.min.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container text-center">
            <div class="row mt-5 fw-bold">
                <h1>Registro de asistencia</h1>
            </div>

            <div class="row mt-5 fw-bold">
                <h3>Usuario <asp:Label ID="lblUser" runat="server" Text=""></asp:Label></h3>
            </div>
            <div  class="row mt-2">
                <div class="col-12">
                    <asp:Button ID="btnIrAReportes" CssClass="btn btn-info btn-lg mx-auto" runat="server" Text="Ir a reportes" OnClick="btnIrAReportes_Click"/>
                </div>
            </div>

            <div class="row mt-5">
                <asp:Label ID="Label1" runat="server" CssClass="fw-bold" Text="ID registro asistencia"></asp:Label>
                <br /><br />
                <asp:TextBox ID="tbIdRegAsis" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
            </div>

            <div class="row mt-5">
                <asp:Label ID="Label2" runat="server" CssClass="fw-bold" Text="Niño"></asp:Label>
                <br /><br />
                <asp:DropDownList ID="ddlNino" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="row mt-5">
                <asp:Label ID="Label3" runat="server" CssClass="fw-bold" Text="Estado del niño"></asp:Label>
                <br /><br />
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="row mt-5">
                <div class="col-12">
                    <asp:Button ID="btnRegistrarAsis" CssClass="btn btn-success btn-lg mx-auto" runat="server" Text="Registrar" OnClick="btnRegistrarAsis_Click" />
                </div>
            </div>

            <div class="row mt-5 mb-5">
                <asp:Label ID="lblMensaje" CssClass="text-danger" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
    <script src="bootstrap-5.2.3-dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
