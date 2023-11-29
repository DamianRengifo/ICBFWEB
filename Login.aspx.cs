using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICBFWEB2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            modelo.UsuarioDAO usuarioDAO = new modelo.UsuarioDAO();
            string docUser = (Login1.UserName).ToString();
            string password = (Login1.Password).ToString();
            modelo.usuarios usuario = usuarioDAO.login(docUser, password);

            if (usuario != null)
            {
                Session["idUsuario"] = usuario.idUsuario;
                Session["nombre"] = usuario.nombre;
                Session["fk_idRol"] = usuario.fk_idRol;
                lblMensaje.Text = "Bienvenido " + usuario.nombre;
            }
            else {
                lblMensaje.Text = "Usuario o la contraseña son incorrectas";
            }

        }
    }
}