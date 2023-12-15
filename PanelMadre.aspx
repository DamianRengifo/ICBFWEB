<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelMadre.aspx.cs" Inherits="ICBFWEB2.PanelMadre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Panel Madre Comunitaria</title>
<link rel="stylesheet" href="bootstrap-5.2.3-dist/css/bootstrap.min.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container text-center">
            <div class="row mt-5">
                <h1 class="fw-bold">Bienvenido <asp:Label ID="lblUser" runat="server" Text=""></asp:Label> </h1>
            </div>
            <div class="row mt-5">
                <h1 class="fw-bold">
                    <asp:Label ID="Label1" runat="server" Text="¿Qué deseas hacer?"></asp:Label>
                </h1>
            </div>
            <div class="row mt-5 d-flex justify-content-center flex-row align-content-around">
                <div class="col-4">
                    <asp:Button ID="btnIrARegistroAsistencia" CssClass="btn btn-success btn-lg" runat="server" Text="Asistencia" OnClick="btnIrARegistroAsistencia_Click" />
                </div>
                <div class="col-4">
                    <asp:Button ID="btnIrAAvanceAcademico" CssClass="btn btn-success btn-lg" runat="server" Text="Avance académico" />
                </div>
            </div>
            
        </div>
    </form>
</body>
</html>
