using ICBFWEB2.modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICBFWEB2
{
    public partial class MadreComunitaria : System.Web.UI.Page
    {
        public static int idMadre;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] != null && Session["fk_idRol"].Equals(3)) {
                if (!IsPostBack) {
                    cargarTabla();
                }
            }
            else
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetNoStore();
                Response.Redirect("Login.aspx");
            }
        }

        public void cargarTabla()
        {
            modelo.UsuarioDAO usuarioDAO = new modelo.UsuarioDAO();
            gdMadre.DataSource = usuarioDAO.consultarMadreComunitaria();
            gdMadre.DataBind();
        }


        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Utilidades.Logout();
        }

        public void limpiarCampos()
        {
            txtNombre.Text = "";
            txtIdentificacion.Text = "";
            txtContraseña.Text = "";
            txtDireccion.Text = "";
            txtFecNacimiento.Text = "";
            txtTelefono.Text = "";
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.usuarios usuarios = new modelo.usuarios();
                modelo.UsuarioDAO usuariosDAO = new modelo.UsuarioDAO();

                usuarios.nombre = txtNombre.Text;
                usuarios.numIdentificacion = txtIdentificacion.Text;
                usuarios.celular = txtTelefono.Text;
                usuarios.direccion = txtDireccion.Text;
                usuarios.fechaNacimiento = DateTime.Parse(txtFecNacimiento.Text);
                usuarios.clave = txtContraseña.Text;

                if (usuariosDAO.validarNombreMadre(usuarios.nombre, usuarios.numIdentificacion)) {
                    usuariosDAO.registrarMadre(usuarios);
                    limpiarCampos();
                    PanelFormulario.Visible = false;
                    PanelTabla.Visible = true;
                    cargarTabla();
                }
                else
                {
                    string scriptError = @"
                        <script type='text/javascript'>
                            alert('La madre comunitaria ya esta registrada')
                        </script>";

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", scriptError, false);
                }
                
            }
            catch (Exception ex)
            {

                limpiarCampos();
                Console.WriteLine("Ha ocurrido el siguiente error a estas horas " + DateTime.Now + "\nA continuacion el error + " + ex.ToString());
                string script = @"
                        <script type='text/javascript'>
                            alert('Ha ocurrido un error con la aplicacion :(')
                        </script>";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, false);
                

            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            PanelTabla.Visible = false;
            PanelFormulario.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PanelTabla.Visible = true;
            PanelFormulario.Visible = false;
        }

        protected void gdMadre_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow fila = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int index = fila.RowIndex;
            modelo.UsuarioDAO usuarioDAO = new modelo.UsuarioDAO();
            if (e.CommandName == "eliminar")
            {
                
                usuarioDAO.eliminarUsuario(int.Parse(gdMadre.Rows[index].Cells[0].Text));
                cargarTabla();
            }

            if (e.CommandName == "editar") {
                string fechaGridView = gdMadre.Rows[index].Cells[5].Text;

                DateTime fechaConvertida = DateTime.ParseExact(fechaGridView, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                PanelFormulario.Visible = true;
                idMadre = int.Parse(gdMadre.Rows[index].Cells[0].Text);
                txtNombre.Text = gdMadre.Rows[index].Cells[1].Text;
                txtIdentificacion.Text = gdMadre.Rows[index].Cells[2].Text;
                txtTelefono.Text = gdMadre.Rows[index].Cells[3].Text;
                txtDireccion.Text = gdMadre.Rows[index].Cells[4].Text;
                txtFecNacimiento.Text = fechaConvertida.ToString("yyyy-MM-dd");
                PanelTabla.Visible = false;
               
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.usuarios usuarios = new modelo.usuarios();
                modelo.UsuarioDAO usuariosDAO = new modelo.UsuarioDAO();

                usuarios.idUsuario = idMadre;
                usuarios.nombre = txtNombre.Text;
                usuarios.numIdentificacion = txtIdentificacion.Text;
                usuarios.celular = txtTelefono.Text;
                usuarios.direccion = txtDireccion.Text;
                usuarios.fechaNacimiento = DateTime.Parse(txtFecNacimiento.Text);
                if (!String.IsNullOrWhiteSpace(txtContraseña.Text))
                {
                    usuarios.clave = txtContraseña.Text;
                }
                else
                {

                    usuarios.clave = "";
                }

                usuariosDAO.actualizarMadre(usuarios);
                limpiarCampos();
                PanelFormulario.Visible = false;
                PanelTabla.Visible = true;
                cargarTabla();
            }
            catch (Exception ex)
            {

                limpiarCampos();
                Console.WriteLine("Ha ocurrido el siguiente error a estas horas " + DateTime.Now + "\nA continuacion el error + " + ex.ToString());
                string script = @"
                        <script type='text/javascript'>
                            alert('Ha ocurrido un error con la aplicacion :(')
                        </script>";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, false);


            }
        }
    }
}