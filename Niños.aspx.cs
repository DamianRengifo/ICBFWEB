using ICBFWEB2.modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                    cargarJardin(ddlJardin);
                    cargarJardin(ddlFiltroJardin);
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

        public void cargarJardin(DropDownList ddlJardin)
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
            niños.fechaNac =DateTime.Parse(txtFecNacimiento.Text);
            DateTime fechaNacimiento = DateTime.ParseExact(txtFecNacimiento.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            if (
                    
                    niñosDao.validarNombreNiño(niños.nombre, niños.numIdentificacion) &&
                    niñosDao.validarAños(fechaNacimiento)
                ) 
            {
                niñosDao.registrarNiños(niños);
                cargarGrilla();
                limpiarCampos();

            }
            else
            {
                string mensajeError = "Error: ";

                if (!niñosDao.validarNombreNiño(niños.nombre, niños.numIdentificacion))
                    mensajeError += "El nombre del niño ya existe. ";

                if (!niñosDao.validarAños(fechaNacimiento))
                    mensajeError += "La edad del niño no es válida (debe ser menor o igual a 6 años). ";

                string script = @"
            <script type='text/javascript'>
                alert('" + mensajeError + @"');
            </script>";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, false);

            }

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
            txtNombre.Text = "";
            txtIdentificacion.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtFecNacimiento.Text = "";
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
                modelo.CiudadDAO ciudadDAO = new modelo.CiudadDAO();
                modelo.EpsDAO epsDao = new modelo.EpsDAO();
                modelo.TipoSangreDao tipoSangreDao = new modelo.TipoSangreDao();
                modelo.UsuarioDAO usuarioDAO = new modelo.UsuarioDAO();
                modelo.RegistroJardinDAO jardinDAO = new modelo.RegistroJardinDAO();
                string fechaGridView = gdvNiños.Rows[index].Cells[10].Text; 
                
                DateTime fechaConvertida = DateTime.ParseExact(fechaGridView, "dd/MM/yyyy", CultureInfo.InvariantCulture);

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
                txtFecNacimiento.Text = fechaConvertida.ToString("yyyy-MM-dd");
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
            niños.fechaNac = DateTime.Parse(txtFecNacimiento.Text);
            niñosDao.editarNiño(niños);
            cargarGrilla();
            PanelRegistro.Visible = false;
            PanelConsulta.Visible = true;
            limpiarCampos();
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            PanelRegistro.Visible = false;
            PanelFormFiltro.Visible = true;
        }

        protected void btnCancelarFiltro_Click(object sender, EventArgs e)
        {
            PanelFormFiltro.Visible = false;
            PanelRegistro.Visible = true;
            limpiarCampos();
        }

        public void cargarFiltros(int jardin) {
            modelo.NiñosDAO niñosDAO = new modelo.NiñosDAO();
            gdvFiltro.DataSource = niñosDAO.reporteNiñoJardin(jardin);
            gdvFiltro.DataBind();
        }

        protected void btnFilrar_Click(object sender, EventArgs e)
        {
            cargarFiltros(int.Parse(ddlFiltroJardin.SelectedValue));
            PanelFiltro.Visible = true;
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            PanelFiltro.Visible = false;
        }
    }
}