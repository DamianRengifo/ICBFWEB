<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jardines.aspx.cs" Inherits="ICBFWEB2.Jardines" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Jardines ICBF</title>
<link rel="stylesheet" href="bootstrap-5.2.3-dist/css/bootstrap.min.css" type="text/css"/>
</head>
<body>
    <div class="container-md text-center">
        <br /><br />
        <div class="row">
            <h1>Formulario de jardines</h1>
        </div>
        <br /><br />
            <form runat="server">
                <asp:Panel ID="panelFormulario" runat="server" Visible="False">
                    <asp:Label ID="Label4" runat="server" Text="ID jardin"></asp:Label>
                    <br /><br />
                    <asp:TextBox ID="tbIdJardin" runat="server" ReadOnly="True" CssClass="form-control fs-5"></asp:TextBox>

                    <br /><br />

                    <asp:Label ID="Label1" runat="server" Text="Nombre de jardin"></asp:Label>
                    <br /><br />
                    <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control fs-5"></asp:TextBox>

                <br /><br />

                    <asp:Label ID="Label2" runat="server" Text="Direccion del jardin"></asp:Label>
                    <br /><br />
                    <asp:TextBox ID="tbDireccion" runat="server" CssClass="form-control fs-5"></asp:TextBox>

                <br /><br />

                    <asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label>
                    <br /><br />
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control fs-5"></asp:DropDownList>

                <br /><br />

                    <div class="row">
                        <div class="col-4 text-center">
                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-success btn-lg" OnClick="btnRegistrar_Click"/>
                        </div>
                        <div class="col-4 text-center">
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-primary btn-lg" OnClick="btnEditar_Click"/>
                        </div>
                        <div class="col-4 text-center">
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-lg" OnClick="btnCancelar_Click"/>
                        </div>


                        <div class="col-12 text-center my-2">
                             <asp:Button ID="btnFiltro" runat="server" Text="Filtrar Por Jardines" CssClass="btn btn-warning text-black rounded-pill px-3 mx-auto" OnClick="btnFiltro_Click" />
                        </div>
                    </div>
            </asp:Panel>
                <br /><br />
            <asp:Panel ID="PanelConsulta" runat="server">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-info btn-lg" OnClick="btnNuevo_Click"/>
                <br /><br />
                <asp:GridView ID="gdvJardines" CssClass="table table-success" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvJardines_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="idJardin" HeaderText="ID Jardin" />
                        <asp:BoundField DataField="nomJardin" HeaderText="Nombre del jardin" />
                        <asp:BoundField DataField="direccionJardin" HeaderText="Dirección del jardin" />
                        <asp:BoundField DataField="estado" HeaderText="Estado" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar2" runat="server" Text="Editar" CommandName="Editar" CssClass="btn btn-info"/>
                                <asp:Button ID="btnEliminar2" runat="server" Text="Eliminar" CommandName="Eliminar" CssClass="btn btn-danger"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>

             <asp:Panel ID="PanelFormFiltro" runat="server" Visible="False">
      <div class="form-floating mb-3 w-75 mx-auto">
        <asp:DropDownList ID="ddlFiltroJardin" runat="server" CssClass="form-select w-75">
            <asp:ListItem>Seleccionar</asp:ListItem>
          </asp:DropDownList>
        <label for="ddlCiudad">Jardin</label>
      </div>

     <div class="d-flex justify-content-center align-items-center">
         <asp:Button ID="btnFilrar" runat="server" Text="Filtrar" CssClass="btn btn-success rounded-pill px-3" OnClick="btnFilrar_Click" />
         <asp:Button ID="btnCancelarFiltro" runat="server" Text="Cancelar" CssClass="btn btn-danger rounded-pill px-3" OnClick="btnCancelarFiltro_Click" />
     </div>
 </asp:Panel>

 <asp:Panel ID="PanelFiltro" runat="server">
     <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" CssClass="mx-auto my-3 btn btn-primary rounded-pill px-3" OnClick="btnCerrar_Click"/>
     <asp:GridView ID="gdvFiltro" runat="server" CssClass="table">       
     </asp:GridView>
 </asp:Panel>

        </form>
      </div>
</body>
</html>
