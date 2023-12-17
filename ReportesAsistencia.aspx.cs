using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICBFWEB2
{
    public partial class ReportesAsistencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] != null && Session["fk_idRol"].Equals(2)) {
                modelo.RegistroAsistenciaDAO asistenciaDAO = new modelo.RegistroAsistenciaDAO();
                gdvTablaEnfermedad.DataSource = asistenciaDAO.asistenciaEnfermedad();
                gdvTablaEnfermedad.DataBind();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSemanal_Click(object sender, EventArgs e)
        {
            PanelSemanal.Visible = true;
            Panel1.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PanelSemanal.Visible = false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            DateTime Desde = cldDesde.SelectedDate;
            DateTime Hasta = cldHasta.SelectedDate;

            modelo.RegistroAsistenciaDAO asistenciaDAO = new modelo.RegistroAsistenciaDAO();
            
            gdvTablaSemanal.DataSource = asistenciaDAO.asistenciaSemanal(Desde, Hasta);
            gdvTablaSemanal.DataBind();
        }

        protected void btnEnfermedad_Click(object sender, EventArgs e)
        {
            
            Panel1.Visible = true;
            PanelSemanal.Visible = false;
        }
    }
}