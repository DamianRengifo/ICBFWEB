using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICBFWEB2
{
    public partial class Acudiente : System.Web.UI.Page
    {
        public static int idAcudiente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] != null && Session["fk_idRol"].Equals(3))
            {

                if (!IsPostBack)
                {
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

        public void cargarTabla() {
            modelo.UsuarioDAO usuarioDAO = new modelo.UsuarioDAO();
            gdvAcudiente.DataSource = usuarioDAO.consultarAcudiente();
            gdvAcudiente.DataBind();
        }

        public void limpiarCampos() {
            txtNombre.Text = "";
            txtIdentificacion.Text = "";
            txtCelular.Text = "";
            txtContraseña.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtFecNacimiento.Text = "";
            txtTelefono.Text = "";
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Utilidades.Logout();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            PanelConsulta.Visible = false;
            PanelFormulario.Visible = true;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PanelConsulta.Visible = true;
            PanelFormulario.Visible = false;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.usuarios usuarios = new modelo.usuarios();
                modelo.UsuarioDAO usuariosDAO = new modelo.UsuarioDAO();

                usuarios.nombre = txtNombre.Text;
                usuarios.numIdentificacion = txtIdentificacion.Text;
                usuarios.telefono = txtTelefono.Text;
                usuarios.celular = txtCelular.Text;
                usuarios.direccion = txtDireccion.Text;
                usuarios.email = txtCorreo.Text;
                usuarios.fechaNacimiento = DateTime.Parse(txtFecNacimiento.Text);
                usuarios.clave = txtContraseña.Text;

                usuariosDAO.registrarAcudiente(usuarios);
                limpiarCampos();
                PanelFormulario.Visible = false;
                PanelConsulta.Visible = true;
                cargarTabla();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Ha ocurrido un error " +  ex);
                limpiarCampos();
            }
         
        }

        protected void gdvAcudiente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow fila = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int index = fila.RowIndex;
            modelo.UsuarioDAO usuarioDAO = new modelo.UsuarioDAO();
            if (e.CommandName == "eliminar") {             
                usuarioDAO.eliminarUsuario(int.Parse(gdvAcudiente.Rows[index].Cells[0].Text));
                cargarTabla();
            }

            if (e.CommandName == "editar") {

                PanelFormulario.Visible = true;
                idAcudiente = int.Parse(gdvAcudiente.Rows[index].Cells[0].Text);
                txtNombre.Text = gdvAcudiente.Rows[index].Cells[1].Text;
                txtIdentificacion.Text = gdvAcudiente.Rows[index].Cells[2].Text;
                txtTelefono.Text = gdvAcudiente.Rows[index].Cells[3].Text;
                txtCelular.Text = gdvAcudiente.Rows[index].Cells[4].Text;
                txtDireccion.Text = gdvAcudiente.Rows[index].Cells[5].Text;
                txtCorreo.Text = gdvAcudiente.Rows[index].Cells[6].Text;
                PanelConsulta.Visible = false;
            }

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            modelo.UsuarioDAO usuarioDAO = new modelo.UsuarioDAO();
            modelo.usuarios acudiente = new modelo.usuarios();
            acudiente.idUsuario = idAcudiente;
            acudiente.nombre = txtNombre.Text;
            acudiente.numIdentificacion = txtIdentificacion.Text;
            acudiente.telefono = txtTelefono.Text;
            acudiente.celular = txtCelular.Text;
            acudiente.direccion = txtDireccion.Text;
            acudiente.email = txtCorreo.Text;
            if (!String.IsNullOrWhiteSpace(txtContraseña.Text)) {
                acudiente.clave = txtContraseña.Text;
            }
            else
            {

                acudiente.clave = "";
            }
            usuarioDAO.actualizarAcudiente(acudiente);
            cargarTabla();
            limpiarCampos();
            PanelFormulario.Visible = false;
            PanelConsulta.Visible = true;
        }
    }
}