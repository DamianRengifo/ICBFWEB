<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acudiente.aspx.cs" Inherits="ICBFWEB2.Acudiente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="bootstrap-5.2.3-dist/css/bootstrap.min.css" type="text/css"/>
    <script src="https://kit.fontawesome.com/712575d4a5.js" crossorigin="anonymous"></script>
    <script src="https://kit.fontawesome.com/d6c2ac0aaf.js" crossorigin="anonymous"></script>
    <title>Gestion de Acudientes</title>
</head>
<body>
    <form id="form1" runat="server">
            <header class="w-100 bg-primary align-items-center">
                <h1 class="text-center fw-bold text-white">Gestion de Acudientes</h1>
                <asp:Button ID="BtnLogout" runat="server" Text="Cerrar Sesion" CssClass="btn btn-primary text-light btn-outline-success rounded-pill px-2 py-2 float-end me-2 mb-3" OnClick="BtnLogout_Click" />
            </header>

            <main class="mt-4">
                <asp:Panel ID="PanelFormulario" runat="server" Visible="False">
                    <section class="container-fluid mt-5">
                        <div class="form-floating mb-3 w-75 mx-auto">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control w-75" placeholder="Nombre" />
                            <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" Text="Nombre del Niño" CssClass="form-label" />
                        </div>

                        <div class="form-floating mb-3 w-75 mx-auto">
                            <asp:TextBox ID="txtIdentificacion" type="number" runat="server" CssClass="form-control w-75" placeholder="Identificacion" MaxLength="15" />
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="txtIdentificacion" Text="Identificacion" CssClass="form-label"/>
                        </div>

                        <div class="form-floating mb-3 w-75 mx-auto">
                            <asp:TextBox ID="txtTelefono" type="number" runat="server" CssClass="form-control w-75" placeholder="Telefono" MaxLength="20"  />
                            <asp:Label ID="Label2" runat="server" AssociatedControlID="txtTelefono" Text="Telefono" CssClass="form-label"/>
                        </div>

                        <div class="form-floating mb-3 w-75 mx-auto">
                            <asp:TextBox ID="txtCelular" type="number" runat="server" CssClass="form-control w-75" placeholder="Celular" MaxLength="20"  />
                            <asp:Label ID="Label4" runat="server" AssociatedControlID="txtTelefono" Text="Celular" CssClass="form-label"/>
                        </div>

                         <div class="form-floating mb-3 w-75 mx-auto">
                            <asp:TextBox ID="txtDireccion" type="text" runat="server" CssClass="form-control w-75" placeholder="Direccion" title="Minimo 20 numeros" />
                            <asp:Label ID="Label3" runat="server" AssociatedControlID="txtDireccion" Text="Direccion" CssClass="form-label"/>
                        </div>

                         <div class="form-floating mb-3 w-75 mx-auto">
                            <asp:TextBox ID="txtCorreo" type="text" runat="server" CssClass="form-control w-75" placeholder="Correo Electronico" title="Minimo 20 numeros" />
                            <asp:Label ID="Label5" runat="server" AssociatedControlID="txtDireccion" Text="Correo Electronico" CssClass="form-label"/>
                        </div>
                        
                        <label class="fw-bold fs-4 text-center mx-auto">Fecha de nacimiento:</label>
                        <asp:TextBox ID="txtFecNacimiento" type="date" runat="server" CssClass="form-control mx-auto w-75"></asp:TextBox>
                        
                         <div class="form-floating my-3 w-75 mx-auto">
                            <asp:TextBox ID="txtContraseña" type="text" runat="server" CssClass="form-control w-75" placeholder="Correo Electronico" />
                            <asp:Label ID="Label6" runat="server" AssociatedControlID="txtDireccion" Text="Contraseña" CssClass="form-label"/>
                        </div>

                        <div class="d-flex justify-content-center align-items-center w-75 my-3 gap-5">
                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary rounded-pill px-3" OnClick="btnRegistrar_Click"  />
                            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-warning rounded-pill px-3" OnClick="btnActualizar_Click"  />
                            <asp:Button ID="Button2" runat="server" Text="Cancelar" CssClass="btn btn-danger rounded-pill px-3" OnClick="Button2_Click" />
                        </div>
                    </section>
                </asp:Panel>

                <asp:Panel ID="PanelConsulta" runat="server" CssClass="my-5 d-flex justify-content-center align-items-center flex-column">
                    <asp:Button ID="btnNuevo" runat="server" Text="Agregar Acudientes" CssClass="btn btn-primary text-white rounded-pill my-5 mx-auto w-50" OnClick="btnNuevo_Click" />
                    <asp:GridView ID="gdvAcudiente" runat="server" CssClass="table w-100 mx-auto" AutoGenerateColumns="False" OnRowCommand="gdvAcudiente_RowCommand">

                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="identificacion" HeaderText="Identificacion" />
                            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                            <asp:BoundField DataField="celular" HeaderText="Celular" />
                            <asp:BoundField DataField="direccion" HeaderText="Direccion" />
                            <asp:BoundField DataField="Correo" HeaderText="Correo" />
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

            </main>
        
    </form>

    <script src="bootstrap-5.2.3-dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
