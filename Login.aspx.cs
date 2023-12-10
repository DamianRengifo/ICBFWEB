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

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            modelo.UsuarioDAO usuarioDAO = new modelo.UsuarioDAO();
            string docUser = Username.Text;
            string password = Password.Text;
            modelo.usuarios usuario = usuarioDAO.login(docUser, password);
            if (!string.IsNullOrWhiteSpace(Username.Text) && !string.IsNullOrWhiteSpace(Password.Text))
            {
                if (usuario != null)
                {
                    var sesionNom = Session["nombre"] = usuario.nombre;
                    Session["idUsuario"] = usuario.idUsuario;
                    Session["nombre"] = usuario.nombre;
                    Session["fk_idRol"] = usuario.fk_idRol;
                    this.mensaje.Visible = true;
                    lblMensaje.Text = "Bienvenido " + sesionNom;

                    redirigirUsuario(usuario.fk_idRol);
                }
                else
                {
                    mensaje.Visible = true;
                    lblMensaje.Text = "Usuario o la contraseña son incorrectas";
                    string script = @"
                        <script type='text/javascript'>
                            setTimeout(function() {
                                var mensaje = document.getElementById('" + mensaje.ClientID + @"');
                                mensaje.style.display = 'none';
                            }, 3000);
                        </script>";

                    ClientScript.RegisterStartupScript(this.GetType(), "hideMessage", script);
                }
            }
            else
            {
                lblError.Text = "Alguno de los campos estan vacios";
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            mensaje.Visible = false;
        }

        public void redirigirUsuario(int fk_idRol) {
            switch (fk_idRol) {
                case 1:
                    string scriptAcudiente = "setTimeout(function() { window.location.href = 'PanelAcudiente.aspx'; }, 3000);";
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", scriptAcudiente, true);
                    break;

                case 2:
                    string script = "setTimeout(function() { window.location.href = 'PanelMadre.aspx'; }, 3000);";
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", script, true);
                break;

                case 3:
                    string scriptAdmin = "setTimeout(function() { window.location.href = 'PanelAdmin.aspx'; }, 3000);";
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", scriptAdmin, true);
                break;
            }
        }
    }
}