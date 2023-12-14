<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelAdmin.aspx.cs" Inherits="ICBFWEB2.PanelAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="bootstrap-5.2.3-dist/css/bootstrap.min.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <header class="bg-success text-white mt-0">
            <h1 class="mb-3 text-center">Bienvenido <asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label></h1>
        </header>

        <h2 class="text-center my-4">¿Que deseas realizar?</h2>
        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" CssClass="btn btn-success position-fixed float-start ms-3" OnClick="btnCerrarSesion_Click" />
        <div class="container-fluid vh-100 min-vh-100">
            <div class="row gap-4 justify-content-center ms-3 me-3">


                <article class="col-lg-3 rounded-4 border border-1 border-success d-flex justify-content-center align-items-center flex-column shadow p-0">
                    <div class="bg-success w-100 h-50 rounded-4">
                        <h3 class="text-center my-2 fw-bold text-white ">Gestionar Niños</h3>                            
                    </div>

                    <asp:Image ID="Image3" runat="server" CssClass="h-50 w-50 mx-auto my-2 rounded-4" ImageUrl="~/Resources/descarga.jpg" />
                    <p class="fs-4 text-center my-2">Registra y gestiona la informacion de todos los niños en nuestra organizacion</p>
                    <asp:LinkButton ID="btnNiños" runat="server" CssClass="btn btn-success btn-outline-light mx-auto my-3" OnClick="btnNiños_Click">Gestionar Niños</asp:LinkButton>
                </article>


                <article class="col-lg-3 rounded-4 border border-1 border-warning d-flex justify-content-center align-items-center flex-column shadow p-0">
                    <div class="bg-warning w-100 h-50 rounded-4">
                        <h3 class="text-center my-2 fw-bold text-black ">Gestionar Jardines</h3>                            
                    </div>

                    <asp:Image ID="Image1" runat="server" CssClass="h-50 w-50 mx-auto my-2 rounded-4" ImageUrl="~/Resources/el-alcaparro-2.jpg" />
                    <p class="fs-4 text-center my-2">Registra y gestiona la informacion de todos los jardines asociados a nuestra organizacion</p>
                    <asp:LinkButton ID="btnJardines" runat="server" CssClass="btn btn-warning btn-outline-light mx-auto my-3" OnClick="btnJardines_Click">Gestionar Jardines</asp:LinkButton>
                </article>

                <article class="col-lg-3 rounded-4 border border-1 border-info d-flex justify-content-center align-items-center flex-column shadow p-0">
                    <div class="bg-info w-100 h-50 rounded-4">
                        <h3 class="text-center my-2 fw-bold text-white ">Gestionar Madres</h3>                            
                    </div>

                    <asp:Image ID="Image2" runat="server" CssClass="h-50 w-50 mx-auto my-2 rounded-4" ImageUrl="~/Resources/482c2986-1df5-4709-b4d9-ac30250d65c5.jpeg"/>
                    <p class="fs-4 text-center my-2">Registra y gestiona la informacion de todos los niños de nuestra organizacion</p>
                    <asp:LinkButton ID="btnMadres" runat="server" CssClass="btn btn-info btn-outline-light mx-auto my-3" OnClick="btnMadres_Click">Gestionar Madres Comunitarias</asp:LinkButton>
                </article>

                
                <article class=" align-self-center mb-5 col-lg-5 rounded-4 border border-1 border-info d-flex justify-content-center align-items-center flex-column shadow p-0">
                    <div class="bg-primary w-100 h-50 rounded-4">
                        <h3 class="text-center my-2 fw-bold text-white">Gestionar Acudientes</h3>                            
                    </div>

                    <asp:Image ID="Image4" runat="server" CssClass="h-50 w-50 mx-auto my-2 rounded-4" ImageUrl="~/Resources/acudientes.jpg"/>
                    <p class="fs-4 text-center my-2">Registra y gestiona la informacion de los acudientes de los niños que estan asociados con nuestra fundacion :)</p>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary btn-outline-light mx-auto my-3" OnClick="btnMadres_Click">Gestionar Acudientes</asp:LinkButton>
                </article>

            </div>
        </div>
    </form>

        <script src="bootstrap-5.2.3-dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>
