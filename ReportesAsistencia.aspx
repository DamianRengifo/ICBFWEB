<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportesAsistencia.aspx.cs" Inherits="ICBFWEB2.ReportesAsistencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reportes de asistencia</title>
<link rel="stylesheet" href="bootstrap-5.2.3-dist/css/bootstrap.min.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container text-center">
            <div class="row mt-5">
                <h1 class="fw-bold"> Reportes</h1>
            </div>

            <div class="row mt-5 justify-content-center">
                <div class="col-12 col-md-6 text-center">
                    <asp:Button ID="btnSemanal" CssClass="btn btn-info btn-lg mx-auto" runat="server" Text="Asistencia Semanal" OnClick="btnSemanal_Click" />
                </div>
                <div class="col-12 col-md-6 text-center">
                    <asp:Button ID="btnEnfermedad" CssClass="btn btn-info btn-lg mx-auto" runat="server" Text="Inasistencia por enfermedad" OnClick="btnEnfermedad_Click" />
                </div>
            </div>

            <asp:Panel ID="PanelSemanal" runat="server" Visible="False">
                <div class="row mt-5">
                    <h1 class="fw-bold">Asistencia semanal</h1>
                </div>
                <div class="row mt-3 justify-content-center">
                    <div class="col-12 col-md-6 text-center">
                        <asp:Label ID="Label1" CssClass="fw-bold" runat="server" Text="Fecha desde:"></asp:Label>
                        <br /><br />
                        <asp:Calendar ID="cldDesde" runat="server" CssClass="form-control"></asp:Calendar>
                    </div> 
                </div>

                <div class="row mt-5 justify-content-center">
                    <div class="col-12 col-md-6 text-center">
                        <asp:Label ID="Label2" CssClass="fw-bold" runat="server" Text="Fecha hasta:"></asp:Label>
                        <br /><br />
                        <asp:Calendar ID="cldHasta" CssClass="form-control mx-auto" runat="server"></asp:Calendar>
                    </div>
                </div>

                <div class="row mt-5 mb-5 justify-content-center">
                    <div class="col-12 col-md-6 text-center">
                        <asp:Button ID="btnBuscar" CssClass="btn btn-success btn-lg mx-auto" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>
                    </div>

                    <div class="col-12 col-md-6 text-center">
                        <asp:Button ID="btnCancelar" CssClass="btn btn-danger btn-lg mx-auto" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"/>
                    </div>
                </div>

                <div class="row mt-5">
                    <asp:GridView ID="gdvTablaSemanal" CssClass="table table-success" runat="server"></asp:GridView>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server">
                <div class="row mt-5">
                    <asp:GridView ID="gdvTablaEnfermedad" CssClass="table table-success" runat="server"></asp:GridView>
                </div>
            </asp:Panel>
        </div>
    </form>

    <script src="bootstrap-5.2.3-dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
