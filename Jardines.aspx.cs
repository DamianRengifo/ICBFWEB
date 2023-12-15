using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICBFWEB2
{
    public partial class Jardines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((Session["idUsuario"] != null && Session["fk_idRol"].Equals(3))) {
                if (!IsPostBack)
                {
                    modelo.EstadosDAO estDAO = new modelo.EstadosDAO();
                    ddlEstado.DataSource = estDAO.consultarTodos();
                    ddlEstado.DataValueField = "idEstado";
                    ddlEstado.DataTextField = "nomEstado";
                    ddlEstado.DataBind();
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
            modelo.RegistroJardinDAO jardinDAO = new modelo.RegistroJardinDAO();
            gdvJardines.DataSource = jardinDAO.consultarTodos();
            gdvJardines.DataBind();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            modelo.registro_jardin reg_jardin = new modelo.registro_jardin();
            modelo.RegistroJardinDAO registroJardinDAO = new modelo.RegistroJardinDAO();

            reg_jardin.nomJardin = tbNombre.Text;
            reg_jardin.direccionJardin = tbDireccion.Text;
            reg_jardin.fk_idEstado = int.Parse(ddlEstado.SelectedValue);

            registroJardinDAO.registrar(reg_jardin);
            cargarTabla();
            panelFormulario.Visible = false;
            PanelConsulta.Visible = true;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            panelFormulario.Visible = true;
            PanelConsulta.Visible = false;
            btnRegistrar.Visible = true;
            btnEditar.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            panelFormulario.Visible = false;
            PanelConsulta.Visible = true;
        }

        protected void gdvJardines_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow fila = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int index = fila.RowIndex;
            if (e.CommandName == "Eliminar")
            {
                modelo.RegistroJardinDAO registroJardinDAO = new modelo.RegistroJardinDAO();
                registroJardinDAO.eliminar(int.Parse(gdvJardines.Rows[index].Cells[0].Text));
                cargarTabla();
            } else if (e.CommandName == "Editar")
            {
                panelFormulario.Visible = true;
                PanelConsulta.Visible = false;
                btnRegistrar.Visible = false;
                btnEditar.Visible = true;

                tbIdJardin.Text = gdvJardines.Rows[index].Cells[0].Text;
                tbNombre.Text = gdvJardines.Rows[index].Cells[1].Text;
                tbDireccion.Text = gdvJardines.Rows[index].Cells[2].Text;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            modelo.registro_jardin reg_jardin = new modelo.registro_jardin();
            modelo.RegistroJardinDAO registroJardinDAO = new modelo.RegistroJardinDAO();

            reg_jardin.idJardin = int.Parse(tbIdJardin.Text);
            reg_jardin.nomJardin = tbNombre.Text;
            reg_jardin.direccionJardin = tbDireccion.Text;
            reg_jardin.fk_idEstado = int.Parse(ddlEstado.SelectedValue);

            registroJardinDAO.editar(reg_jardin);
            cargarTabla();
            panelFormulario.Visible = false;
            PanelConsulta.Visible = true;
            limpiarCajas();
        }

        public void limpiarCajas()
        {
            tbIdJardin.Text = "";
            tbNombre.Text = "";
            tbDireccion.Text = "";
        }
    }
}