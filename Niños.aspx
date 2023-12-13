<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Niños.aspx.cs" Inherits="ICBFWEB2.Niños" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="bootstrap-5.2.3-dist/css/bootstrap.min.css" type="text/css"/>
    <script src="https://kit.fontawesome.com/712575d4a5.js" crossorigin="anonymous"></script>
    <script src="https://kit.fontawesome.com/d6c2ac0aaf.js" crossorigin="anonymous"></script>
</head>
<body>
    
    <form id="form1" runat="server">
        <header class="w-100 bg-success text-white">
            <h1 class="text-center fw-bold">Gestion de Niños</h1>
            <asp:Button ID="BtnLogout" runat="server" Text="Cerrar Sesion" CssClass="btn btn-success text-light btn-outline-primary rounded-pill px-2 py-2 float-end me-2" OnClick="BtnLogout_Click" />
        </header>

        

        <asp:Panel ID="PanelRegistro" runat="server" Visible="False">
            <div class="container-fluid mt-3">
                <div class="d-flex justify-content-center align-items-center flex-column gap-2">
                    <div class="form-floating mb-3 w-75 mx-auto">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control w-75" placeholder="Nombre del Niño" />
                        <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" Text="Nombre del Niño" CssClass="form-label" />
                    </div>

                    <div class="form-floating mb-3 w-75 mx-auto">
                        <asp:TextBox ID="txtIdentificacion" type="number" runat="server" CssClass="form-control w-75" placeholder="Identificacion" MaxLength="15" />
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtIdentificacion" Text="Identificacion" CssClass="form-label"/>
                    </div>

                    <div class="form-floating mb-3 w-75 mx-auto">
                        <asp:TextBox ID="txtTelefono" type="number" runat="server" CssClass="form-control w-75" placeholder="Identificacion" MaxLength="20"  />
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="txtTelefono" Text="Telefono" CssClass="form-label"/>
                    </div>

                     <div class="form-floating mb-3 w-75 mx-auto">
                        <asp:TextBox ID="txtDireccion" type="text" runat="server" CssClass="form-control w-75" placeholder="Identificacion" title="Minimo 20 numeros" />
                        <asp:Label ID="Label3" runat="server" AssociatedControlID="txtDireccion" Text="Direccion" CssClass="form-label"/>
                    </div>

                    <div class="form-floating mb-3 w-75 mx-auto">
                      <asp:DropDownList ID="ddlCiudad" runat="server" CssClass="form-select w-75">
                          <asp:ListItem>Seleccionar</asp:ListItem>
                        </asp:DropDownList>
                      <label for="ddlCiudad">Ciudad de nacimiento</label>
                    </div>

                     <div class="form-floating mb-3 w-75 mx-auto">
                       <asp:DropDownList ID="ddlEps" runat="server" CssClass="form-select w-75">
                           <asp:ListItem>Seleccionar</asp:ListItem>
                       </asp:DropDownList>
                       <label for="ddlEps">EPS</label>
                     </div>

                     <div class="form-floating mb-3 w-75 mx-auto">
                       <asp:DropDownList ID="ddlTipSangre" runat="server" CssClass="form-select w-75">
                           <asp:ListItem>Seleccionar</asp:ListItem>
                       </asp:DropDownList>
                       <label for="ddlTipSangre">Tipo de Sangre</label>
                     </div>

                     <div class="form-floating mb-3 w-75 mx-auto">
                       <asp:DropDownList ID="ddlAcudiente" runat="server" CssClass="form-select w-75">
                           <asp:ListItem>Seleccionar</asp:ListItem>
                       </asp:DropDownList>
                       <label for="ddlAcudiente">Acudiente</label>
                     </div>

                     <div class="form-floating mb-3 w-75 mx-auto">
                       <asp:DropDownList ID="ddlJardin" runat="server" CssClass="form-select w-75">
                           <asp:ListItem>Seleccionar</asp:ListItem>
                       </asp:DropDownList>
                       <label for="ddlCiudad">Jardin</label>
                     </div>

                    <label class="fw-bold fs-4 text-center">Fecha de nacimiento:</label>
                    <asp:Calendar ID="cldCalendar" runat="server" CssClass="form-control mx-auto w-75"></asp:Calendar>

                    <div class="d-flex justify-content-center align-items-center w-75 my-3 gap-5">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-success rounded-pill px-3" OnClick="btnRegistrar_Click" />
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary rounded-pill px-3" OnClick="btnActualizar_Click" />
                        <asp:Button ID="Button2" runat="server" Text="Cancelar" CssClass="btn btn-danger rounded-pill px-3" OnClick="Button2_Click" />
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelConsulta" runat="server">
            <div class="row mx-auto">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="mx-auto btn btn-primary mb-5" OnClick="btnNuevo_Click" />
            </div>
            <asp:GridView ID="gdvNiños" runat="server" AutoGenerateColumns="False" CssClass="table table-success fs-5"  OnRowCommand="gdvNiños_RowCommand">
                <Columns>
                    <asp:BoundField DataField="idNiño" HeaderText="Codigo" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="numIdentificacion" HeaderText="Identificacion" />
                    <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                    <asp:BoundField DataField="direccion" HeaderText="Direccion" />
                    <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                    <asp:BoundField DataField="Eps" HeaderText="Eps" />
                    <asp:BoundField DataField="TipoSangre" HeaderText="Tipo de Sangre" />
                    <asp:BoundField DataField="Acudiente" HeaderText="Acudiente" />
                    <asp:BoundField DataField="Jardin" HeaderText="Jardin" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnUpdate" CommandName="editar" CssClass="btn btn-primary rounded-circle" title="Search">
                               <i class="fa-solid fa-pencil"></i>
                            </asp:LinkButton>

                            <asp:LinkButton ID="btnEliminar" CommandName="eliminar" runat="server" CssClass="btn btn-danger rounded-circle">
                                <i class="fa-solid fa-trash"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </form>

        <script src="bootstrap-5.2.3-dist/js/bootstrap.bundle.min.js"></script>
        
</body>
</html>
