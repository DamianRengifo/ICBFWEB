using ICBFWEB2.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICBFWEB2
{
    public partial class Niños : System.Web.UI.Page
    {
        private static int idNiño;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] != null && Session["fk_idRol"].Equals(3)) {

                if (!IsPostBack) {
                    cargarGrilla();
                    cargarEps();
                    cargarCiudad();
                    cargarTipoSangre();
                    cargarAcudiente();
                    cargarJardin();
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

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Utilidades.Logout();
        }

        public void cargarGrilla() {
            modelo.NiñosDAO niñosDAO = new modelo.NiñosDAO();
            gdvNiños.DataSource = niñosDAO.consultarDatos();
            gdvNiños.DataBind();
        }

        public void cargarEps()
        {
            modelo.EpsDAO epsDao = new modelo.EpsDAO();
            ddlEps.DataSource = epsDao.consultarTodos();
            ddlEps.DataValueField = "idEps";
            ddlEps.DataTextField = "nomEps";
            ddlEps.DataBind();
        }

        public void cargarCiudad() {
            modelo.CiudadDAO ciudadDAO = new modelo.CiudadDAO();
            ddlCiudad.DataSource = ciudadDAO.consultarTodos();
            ddlCiudad.DataValueField = "idCiudad";
            ddlCiudad.DataTextField = "nomCiudad";
            ddlCiudad.DataBind();
        }

        public void cargarTipoSangre() {
            modelo.TipoSangreDao tipSangreDao = new modelo.TipoSangreDao();
            ddlTipSangre.DataSource = tipSangreDao.consultarTodos();
            ddlTipSangre.DataValueField = "idTipoSangre";
            ddlTipSangre.DataTextField = "nomTipoSangre";
            ddlTipSangre.DataBind();
        }
        public void cargarAcudiente()
        {
            modelo.UsuarioDAO usuarioDao = new modelo.UsuarioDAO();
            ddlAcudiente.DataSource = usuarioDao.consultarAcudiente();
            ddlAcudiente.DataValueField = "Codigo";
            ddlAcudiente.DataTextField = "nombre";
            ddlAcudiente.DataBind();
        }

        public void cargarJardin()
        {
            modelo.RegistroJardinDAO jardinDao = new modelo.RegistroJardinDAO();
            ddlJardin.DataSource = jardinDao.consultarTodos();
            ddlJardin.DataValueField = "idJardin";
            ddlJardin.DataTextField = "nomJardin";
            ddlJardin.DataBind();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            modelo.niños niños = new modelo.niños();
            modelo.NiñosDAO niñosDao = new modelo.NiñosDAO();

            niños.nombre = txtNombre.Text;
            niños.numIdentificacion = txtIdentificacion.Text;
            niños.telefonoNiño = txtTelefono.Text;
            niños.direccionNiño = txtDireccion.Text;
            niños.fk_idCiudad = int.Parse(ddlCiudad.SelectedValue);
            niños.fk_idEps = int.Parse(ddlEps.SelectedValue);
            niños.fk_idTipSangre = int.Parse(ddlTipSangre.SelectedValue);
            niños.fk_idAcudiente = int.Parse(ddlAcudiente.SelectedValue);
            niños.fk_idJardin = int.Parse(ddlJardin.SelectedValue);
            niños.fechaNac = cldCalendar.SelectedDate;
            niñosDao.registrarNiños(niños);
            cargarGrilla();

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            PanelRegistro.Visible = true;
            PanelConsulta.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PanelRegistro.Visible = false;
            PanelConsulta.Visible = true;
        }
        public void limpiarCampos() {
            txtNombre.Text = String.Empty;
            txtIdentificacion.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtTelefono.Text = String.Empty;
        }

     

        protected void gdvNiños_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow fila = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int index = fila.RowIndex;

            if (e.CommandName == "eliminar") {
                modelo.NiñosDAO niñosDao = new modelo.NiñosDAO();
                niñosDao.eliminarNiño(int.Parse(gdvNiños.Rows[index].Cells[0].Text));
                cargarGrilla();
            }

            if(e.CommandName == "editar")
            {
                modelo.niños niños = new modelo.niños();
                modelo.NiñosDAO niñosDao = new modelo.NiñosDAO();
                modelo.CiudadDAO ciudadDAO = new modelo.CiudadDAO();
                modelo.EpsDAO epsDao = new modelo.EpsDAO();
                modelo.TipoSangreDao tipoSangreDao = new modelo.TipoSangreDao();
                modelo.UsuarioDAO usuarioDAO = new modelo.UsuarioDAO();
                modelo.RegistroJardinDAO jardinDAO = new modelo.RegistroJardinDAO();

                PanelRegistro.Visible = true;
                idNiño = int.Parse(gdvNiños.Rows[index].Cells[0].Text);
                txtNombre.Text = gdvNiños.Rows[index].Cells[1].Text;
                txtIdentificacion.Text = gdvNiños.Rows[index].Cells[2].Text;
                txtTelefono.Text = gdvNiños.Rows[index].Cells[3].Text;
                txtDireccion.Text = gdvNiños.Rows[index].Cells[4].Text;
                ddlCiudad.SelectedValue = ciudadDAO.consultarId(gdvNiños.Rows[index].Cells[5].Text).ToString();
                ddlEps.SelectedValue = epsDao.obtenerId(gdvNiños.Rows[index].Cells[6].Text);
                ddlTipSangre.SelectedValue = tipoSangreDao.consultarId(gdvNiños.Rows[index].Cells[7].Text);
                ddlAcudiente.SelectedValue = usuarioDAO.consultarId(gdvNiños.Rows[index].Cells[8].Text);
                ddlJardin.SelectedValue = jardinDAO.consultarId(gdvNiños.Rows[index].Cells[9].Text);
                cldCalendar.SelectedDate = DateTime.Parse(gdvNiños.Rows[index].Cells[10].Text);
                PanelConsulta.Visible = false;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            modelo.niños niños = new modelo.niños();
            modelo.NiñosDAO niñosDao = new modelo.NiñosDAO();
            niños.idNiño = idNiño;
            niños.nombre = txtNombre.Text;
            niños.numIdentificacion = txtIdentificacion.Text;
            niños.telefonoNiño = txtTelefono.Text;
            niños.direccionNiño = txtDireccion.Text;
            niños.fk_idCiudad = int.Parse(ddlCiudad.SelectedValue);
            niños.fk_idEps = int.Parse(ddlEps.SelectedValue);
            niños.fk_idTipSangre = int.Parse(ddlTipSangre.SelectedValue);
            niños.fk_idAcudiente = int.Parse(ddlAcudiente.SelectedValue);
            niños.fk_idJardin = int.Parse(ddlJardin.SelectedValue);
            niños.fechaNac = cldCalendar.SelectedDate;
            niñosDao.editarNiño(niños);
            cargarGrilla();
            PanelRegistro.Visible = false;
            PanelConsulta.Visible = true;
        }
    }
}